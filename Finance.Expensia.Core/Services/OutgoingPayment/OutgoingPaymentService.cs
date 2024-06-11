using AutoMapper;
using Finance.Expensia.Core.Services.DocumentNumbering;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Finance.Expensia.Core.Services.OutgoingPayment
{
    public partial class OutgoingPaymentService(
		ApplicationDbContext dbContext, IMapper mapper, ILogger<OutgoingPaymentService> logger, DocumentNumberingService documentNumberingService)
		: BaseService<OutgoingPaymentService>(dbContext, mapper, logger)
	{
		private readonly DocumentNumberingService _documentNumberingService = documentNumberingService;

		public async Task<ResponsePaging<ListOutgoingPaymentDto>> GetListOfOutgoingPayment(ListOutgoingPaymentFilterInput input, 
			CurrentUserAccessor currentUserAccessor, bool onlyMyDocument = false)
		{
			var retVal = new ResponsePaging<ListOutgoingPaymentDto>();

			var userCompanyIds = await _dbContext.UserCompanies.Where(d => d.UserId.Equals(currentUserAccessor.Id)).Select(d => d.CompanyId).ToListAsync();

			var dataOutgoingPayments = _dbContext.OutgoingPayments
												 .Where(d => userCompanyIds.Contains(d.CompanyId))
												 .Where(d => !input.CompanyId.HasValue || input.CompanyId.Equals(d.CompanyId))
												 .Where(d => !input.ApprovalStatus.HasValue || input.ApprovalStatus.Equals(d.ApprovalStatus))
												 .Where(d => !input.StartDate.HasValue || d.RequestDate >= input.StartDate)
												 .Where(d => !input.EndDate.HasValue || d.RequestDate <= input.EndDate)
												 .Where(d =>
													EF.Functions.Like(d.TransactionNo, $"%{input.SearchKey}%")
													|| EF.Functions.Like(d.Requestor, $"%{input.SearchKey}%")
													|| EF.Functions.Like(d.Remark, $"%{input.SearchKey}%")
													|| d.OutgoingPaymentTaggings.Any(t => EF.Functions.Like(t.TagValue, $"%{input.SearchKey}%")))
												 .Where(d => !onlyMyDocument || EF.Functions.Like(d.CreatedBy, $"{currentUserAccessor.Id}"))
												 .Include(x => x.OutgoingPaymentTaggings.OrderBy(d => d.Created))
												 .OrderByDescending(d => d.Modified ?? d.Created)
												 .Select(d => _mapper.Map<ListOutgoingPaymentDto>(d));

			retVal.ApplyPagination(input.Page, input.PageSize, dataOutgoingPayments);

			return await Task.FromResult(retVal);
		}

		public async Task<ResponseObject<OutgoingPaymentDto>> GetDetailOutgoingPayment(Guid outgoingPaymentId, CurrentUserAccessor currentUserAccessor)
		{
			var result = new ResponseObject<OutgoingPaymentDto>();
			var dataOutgoingPay = await _dbContext.OutgoingPayments
												  .Include(x => x.OutgoingPaymentTaggings.OrderBy(d => d.Created))
												  .Include(x => x.OutgoingPaymentDetails.OrderBy(d => d.Created))
												  .ThenInclude(x => x.OutgoingPaymentDetailAttachments)
												  .FirstOrDefaultAsync(x => x.Id == outgoingPaymentId);

			if (dataOutgoingPay == null)
                return await Task.FromResult(new ResponseObject<OutgoingPaymentDto>("Data outgoing payment tidak ditemukan", ResponseCode.NotFound));

            var dataOutgoingPayDto = _mapper.Map<OutgoingPaymentDto>(dataOutgoingPay);
            if (dataOutgoingPayDto.CreatedBy != currentUserAccessor.Id.ToString())
                dataOutgoingPayDto.IsBtnCancelHidden = true;

            var dataUserCompany = await _dbContext.UserCompanies.Where(d => d.UserId.Equals(currentUserAccessor.Id) && d.CompanyId.Equals(dataOutgoingPayDto.CompanyId)).FirstOrDefaultAsync();
            if (dataUserCompany != null)
                dataOutgoingPayDto.AllowApproval = dataUserCompany.AllowApproval;

            return await Task.FromResult(new ResponseObject<OutgoingPaymentDto>(responseCode: ResponseCode.Ok)
            {
                Obj = dataOutgoingPayDto,
            });
        }

		public async Task<ResponseObject<List<OutgoingPaymentTaggingDto>>> RetrieveOutgoingPaymentTagging(PagingSearchInputBase input)
		{
			var dataOutgoingPayments = await _dbContext.OutgoingPaymentTaggings
													   .Where(d => EF.Functions.Like(d.TagValue, $"%{input.SearchKey}%"))
													   .Select(d => d.TagValue)
													   .Distinct()
													   .Skip((input.Page - 1) * input.PageSize)
													   .Take(input.PageSize)
													   .ToListAsync();

			var dataOutgoingPaymentsDto = dataOutgoingPayments.Select(tagValue => _mapper.Map<OutgoingPaymentTaggingDto>(new OutgoingPaymentTagging { TagValue = tagValue }))
															  .ToList();

			return new ResponseObject<List<OutgoingPaymentTaggingDto>>(responseCode: ResponseCode.Ok)
			{
				Obj = dataOutgoingPaymentsDto
			};
		}

		public async Task<ResponseBase> CreateOutgoingPayment(CreateOutgoingPaymentInput input, CurrentUserAccessor currentUserAccessor)
		{
			var (validateInputStatus, validateInputMessage) = ValidateUpsertOutgoingPaymentInput(input, input.OutgoingPaymentDetails.Select(_mapper.Map<BaseOutgoingPaymentDetailInput>).ToList());
			if (validateInputStatus != ResponseCode.Ok)
				return new ResponseBase(validateInputMessage, validateInputStatus);

            var (validateDataStatus, validateDataMessage, dataCompany, dataFromBankAlias, dataToBankAlias, dataTransactionType) = 
				await ValidateUpsertOutgoingPaymentReferenceData(input);
            if (validateDataStatus != ResponseCode.Ok)
                return new ResponseBase(validateDataMessage, validateDataStatus);

            var dateNow = DateTime.Now;
			var runningNumberConfig = await _documentNumberingService.GetRunningNumberDocument(dataTransactionType.TransactionTypeCode, dataCompany.CompanyCode, dateNow);

            #region set data entity => OutgoingPayment
            var dataOutgoingPayment = _mapper.Map<DataAccess.Models.OutgoingPayment>(input);

			dataOutgoingPayment.TransactionNo = $"{dataCompany.CompanyCode}-{dataTransactionType.TransactionTypeCode}-{dateNow:ddMMyy}-{(runningNumberConfig.RunningNumber).ToString().PadLeft(4, '0')}";
			dataOutgoingPayment.Requestor = currentUserAccessor.FullName;
			dataOutgoingPayment.RequestDate = dateNow.Date;
			dataOutgoingPayment.CompanyName = dataCompany.CompanyName;
			dataOutgoingPayment.TransactionTypeCode = dataTransactionType.TransactionTypeCode;
			dataOutgoingPayment.ApprovalStatus = input.IsSubmit ? ApprovalStatus.WaitingApproval : ApprovalStatus.Draft;

			dataOutgoingPayment.FromBankAliasName = dataFromBankAlias.AliasName;
			dataOutgoingPayment.FromBankName = dataFromBankAlias.BankName;
			dataOutgoingPayment.FromAccountNo = dataFromBankAlias.AccountNo;
			dataOutgoingPayment.FromAccountName = dataFromBankAlias.AccountName;

			dataOutgoingPayment.ToBankAliasName = dataToBankAlias.AliasName;
			dataOutgoingPayment.ToBankName = dataToBankAlias.BankName;
			dataOutgoingPayment.ToAccountNo = dataToBankAlias.AccountNo;
			dataOutgoingPayment.ToAccountName = dataToBankAlias.AccountName;

			dataOutgoingPayment.TotalAmount = input.OutgoingPaymentDetails.Sum(d => d.Amount);
			#endregion

			#region set data entity => OutgoingPaymentDetail & OutgoingPaymentDetailAttachment
			foreach (var outgoingPaymentDetailInput in input.OutgoingPaymentDetails)
			{
				var (validateDetailDataStatus, validateDetailDataMessage, dataPartner, dataCoa, dataCostCenter, dataPostingAccount) = 
					await ValidateUpsertOutgoingPaymentReferenceDetailData(outgoingPaymentDetailInput, input.CompanyId);
                if (validateDetailDataStatus != ResponseCode.Ok)
                    return new ResponseBase(validateDetailDataMessage, validateDetailDataStatus);

                var dataOutgoingPaymentDetail = _mapper.Map<OutgoingPaymentDetail>(outgoingPaymentDetailInput);

				dataOutgoingPaymentDetail.PartnerName = dataPartner.PartnerName;
				dataOutgoingPaymentDetail.ChartOfAccountNo = dataCoa.AccountCode;
				dataOutgoingPaymentDetail.ChartOfAccountName = dataCoa.AccountName;
				dataOutgoingPaymentDetail.CostCenterCode = dataCostCenter?.CostCenterCode ?? string.Empty;
				dataOutgoingPaymentDetail.CostCenterName = dataCostCenter?.CostCenterName ?? string.Empty;
				dataOutgoingPaymentDetail.PostingAccountName = dataPostingAccount.CompanyName;
				dataOutgoingPaymentDetail.OutgoingPaymentDetailAttachments.AddRange(outgoingPaymentDetailInput.OutgoingPaymentDetailAttachments.Select(d => _mapper.Map<OutgoingPaymentDetailAttachment>(d)));

				dataOutgoingPayment.OutgoingPaymentDetails.Add(dataOutgoingPaymentDetail);
			}
			#endregion

			await _dbContext.AddAsync(dataOutgoingPayment);
            await _dbContext.SaveChangesAsync();

            if (input.IsSubmit)
			{
				(var isSuccessWorkflow, string roleCode) = await CreateApprovalWorkflow(dataOutgoingPayment, currentUserAccessor);

				if (!isSuccessWorkflow)
					return new ResponseBase("Gagal membuat workflow approval", ResponseCode.Error);

                var dataSendEmail = new SendEmailDto
                {
                    DocumentId = dataOutgoingPayment.Id,
                    ExecutorName = dataOutgoingPayment.Requestor,
                    TransactionNo = dataOutgoingPayment.TransactionNo,
                    RoleCodeReceiver = roleCode,
                    Remark = dataOutgoingPayment.Remark,
                    ScheduleDate = dataOutgoingPayment.ScheduledDate
                };

                await SendEmailToApprover(dataSendEmail, ApprovalStatus.Submitted);
            }

			return new ResponseBase($"Data outgoing payment berhasil {(input.IsSubmit ? "disubmit" : "disimpan sebagai draft")}", ResponseCode.Ok);
		}

		public async Task<ResponseBase> EditOutgoingPayment(EditOutgoingPaymentInput input, CurrentUserAccessor currentUserAccessor)
		{
            var (validateInputStatus, messageValidateInput) = ValidateUpsertOutgoingPaymentInput(input, input.OutgoingPaymentDetails.Select(_mapper.Map<BaseOutgoingPaymentDetailInput>).ToList());
            if (validateInputStatus != ResponseCode.Ok)
                return new ResponseBase(messageValidateInput, validateInputStatus);

            var (validateDataStatus, messageValidateData, dataCompany, dataFromBankAlias, dataToBankAlias, dataTransactionType) = await ValidateUpsertOutgoingPaymentReferenceData(input);
            if (validateDataStatus != ResponseCode.Ok)
                return new ResponseBase(messageValidateData, validateDataStatus);

            var existOutgoing = await _dbContext.OutgoingPayments.Include(x => x.OutgoingPaymentDetails)
				.ThenInclude(x => x.OutgoingPaymentDetailAttachments)
				.FirstOrDefaultAsync(x => x.Id == input.Id);

			if (existOutgoing == null)
				return await Task.FromResult(new ResponseObject<OutgoingPaymentDto>("Data outgoing payment tidak ditemukan", ResponseCode.NotFound));

			#region edit data outgoing payment
			existOutgoing.CompanyName = dataCompany.CompanyName;
			existOutgoing.TransactionTypeId = dataTransactionType.Id;
			existOutgoing.TransactionTypeCode = dataTransactionType.TransactionTypeCode;
			existOutgoing.ApprovalStatus = input.IsSubmit ? ApprovalStatus.WaitingApproval : ApprovalStatus.Draft;

			existOutgoing.FromBankAliasName = dataFromBankAlias.AliasName;
			existOutgoing.FromBankName = dataFromBankAlias.BankName;
			existOutgoing.FromAccountNo = dataFromBankAlias.AccountNo;
			existOutgoing.FromAccountName = dataFromBankAlias.AccountName;

			existOutgoing.ToBankAliasName = dataToBankAlias.AliasName;
			existOutgoing.ToBankName = dataToBankAlias.BankName;
			existOutgoing.ToAccountNo = dataToBankAlias.AccountNo;
			existOutgoing.ToAccountName = dataToBankAlias.AccountName;
			existOutgoing.ExpectedTransfer = input.ExpectedTransfer;
			existOutgoing.BankPaymentType = input.BankPaymentType;
			existOutgoing.Remark = input.Remark;
			existOutgoing.ScheduledDate = input.ScheduledDate;

			existOutgoing.TotalAmount = input.OutgoingPaymentDetails.Sum(d => d.Amount);
			#endregion

			#region edit data outgoing payment detail
			//delete outgoing detail
			var deleteOutgoingDetails = await _dbContext.OutgoingPaymentDetails
														.Include(x => x.OutgoingPaymentDetailAttachments)
														.Where(x =>
															x.OutgoingPaymentId == input.Id
															&& !input.OutgoingPaymentDetails.Select(d => d.Id).Contains(x.Id))
														.ToListAsync();

			if (deleteOutgoingDetails.Count != 0)
			{
				foreach (var deleteOutgoingDetail in deleteOutgoingDetails)
				{
					deleteOutgoingDetail.RowStatus = 1;
					foreach (var attachment in deleteOutgoingDetail.OutgoingPaymentDetailAttachments)
					{
						attachment.RowStatus = 1;
					}
					_dbContext.Update(deleteOutgoingDetail);
				}
			}

			// add / edit outgoing payment detail
			foreach (var outgoingPaymentDetailInput in input.OutgoingPaymentDetails)
			{
                var (validateDetailDataStatus, validateDetailDataMessage, dataPartner, dataCoa, dataCostCenter, dataPostingAccount) =
                    await ValidateUpsertOutgoingPaymentReferenceDetailData(outgoingPaymentDetailInput, input.CompanyId);
                if (validateDetailDataStatus != ResponseCode.Ok)
                    return new ResponseBase(validateDetailDataMessage, validateDetailDataStatus);

                var existOutgoingDetail = existOutgoing.OutgoingPaymentDetails.FirstOrDefault(x => x.Id == outgoingPaymentDetailInput.Id);
				if (existOutgoingDetail != null)
				{
					//Edit data yang sudah ada
					existOutgoingDetail.InvoiceDate = outgoingPaymentDetailInput.InvoiceDate;
					existOutgoingDetail.Description = outgoingPaymentDetailInput.Description;
					existOutgoingDetail.PartnerId = outgoingPaymentDetailInput.PartnerId;
					existOutgoingDetail.PartnerName = dataPartner.PartnerName;
					existOutgoingDetail.ChartOfAccountId = outgoingPaymentDetailInput.ChartOfAccountId ?? Guid.Empty;
					existOutgoingDetail.ChartOfAccountNo = dataCoa.AccountCode;
					existOutgoingDetail.ChartOfAccountName = dataCoa.AccountName;
					existOutgoingDetail.CostCenterId = outgoingPaymentDetailInput.CostCenterId;
					existOutgoingDetail.CostCenterCode = dataCostCenter?.CostCenterCode ?? string.Empty;
					existOutgoingDetail.CostCenterName = dataCostCenter?.CostCenterName ?? string.Empty;
					existOutgoingDetail.PostingAccountId = outgoingPaymentDetailInput.PostingAccountId;
					existOutgoingDetail.PostingAccountName = dataPostingAccount.CompanyName;
					existOutgoingDetail.Amount = outgoingPaymentDetailInput.Amount;

					//delete attachment
					var deletedAttachments = existOutgoingDetail.OutgoingPaymentDetailAttachments
																.Where(x =>
																	!outgoingPaymentDetailInput.OutgoingPaymentDetailAttachments.Select(d => d.Id).Contains(x.Id));

					if (deletedAttachments.Any())
					{
						foreach (var deletedAttachment in deletedAttachments)
						{
							deletedAttachment.RowStatus = 1;
							_dbContext.Update(deletedAttachment);
						}
					}

					//add attachment
					foreach (var outgoingPaymentDetailAttachmentInput in outgoingPaymentDetailInput.OutgoingPaymentDetailAttachments.Where(d => !d.Id.HasValue))
					{
						var newOutgoingDetailAttachment = _mapper.Map<OutgoingPaymentDetailAttachment>(outgoingPaymentDetailAttachmentInput);
						newOutgoingDetailAttachment.OutgoingPaymentDetailId = existOutgoingDetail.Id;

						await _dbContext.AddAsync(newOutgoingDetailAttachment);
					}

					_dbContext.Update(existOutgoingDetail);
				}
				else
				{
					//Add data baru
					var dataOutgoingPaymentDetail = _mapper.Map<OutgoingPaymentDetail>(outgoingPaymentDetailInput);

					dataOutgoingPaymentDetail.OutgoingPaymentId = existOutgoing.Id;
					dataOutgoingPaymentDetail.PartnerName = dataPartner.PartnerName;
					dataOutgoingPaymentDetail.ChartOfAccountNo = dataCoa.AccountCode;
					dataOutgoingPaymentDetail.ChartOfAccountName = dataCoa.AccountName;
					dataOutgoingPaymentDetail.CostCenterCode = dataCostCenter?.CostCenterCode ?? string.Empty;
					dataOutgoingPaymentDetail.CostCenterName = dataCostCenter?.CostCenterName ?? string.Empty;
					dataOutgoingPaymentDetail.PostingAccountName = dataPostingAccount.CompanyName;
					dataOutgoingPaymentDetail.OutgoingPaymentDetailAttachments.AddRange(outgoingPaymentDetailInput.OutgoingPaymentDetailAttachments.Select(d => _mapper.Map<OutgoingPaymentDetailAttachment>(d)));

					await _dbContext.AddAsync(dataOutgoingPaymentDetail);
				}
			}

			//delete outgoing tagging
			var deleteOutgoingTaggings = await _dbContext.OutgoingPaymentTaggings
														.Where(x =>
															x.OutgoingPaymentId == input.Id
															&& !input.OutgoingPaymentTaggings.Select(d => d.Id).Contains(x.Id))
														.ToListAsync();

			if (deleteOutgoingTaggings.Count != 0)
			{
				foreach (var deleteOutgoingTagging in deleteOutgoingTaggings)
				{
					deleteOutgoingTagging.RowStatus = 1;
					_dbContext.Update(deleteOutgoingTagging);
				}
			}

			// add outgoing tagging
			foreach (var outgoingPaymentTaggingInput in input.OutgoingPaymentTaggings)
			{
				var existOutgoingTagging = existOutgoing.OutgoingPaymentTaggings.FirstOrDefault(x => x.Id == outgoingPaymentTaggingInput.Id);
				if (existOutgoingTagging == null)
				{
					//Add data baru
					var dataOutgoingPaymentTagging = _mapper.Map<OutgoingPaymentTagging>(outgoingPaymentTaggingInput);

					dataOutgoingPaymentTagging.OutgoingPaymentId = existOutgoing.Id;
					dataOutgoingPaymentTagging.TagValue = outgoingPaymentTaggingInput.TagValue;

					await _dbContext.AddAsync(dataOutgoingPaymentTagging);
				}
			}
			#endregion

			_dbContext.OutgoingPayments.Update(existOutgoing);
            await _dbContext.SaveChangesAsync();

            if (input.IsSubmit)
			{
				(var isSuccessWorkflow, string roleCode) = await CreateApprovalWorkflow(existOutgoing, currentUserAccessor);

				if (!isSuccessWorkflow)
					return new ResponseBase("Gagal membuat workflow approval", ResponseCode.Error);

                var dataSendEmail = new SendEmailDto
                {
                    DocumentId = existOutgoing.Id,
                    ExecutorName = existOutgoing.Requestor,
                    TransactionNo = existOutgoing.TransactionNo,
                    RoleCodeReceiver = roleCode,
                    Remark = existOutgoing.Remark,
                    ScheduleDate = existOutgoing.ScheduledDate
                };

                await SendEmailToApprover(dataSendEmail, ApprovalStatus.Submitted);
            }

			return new ResponseBase($"Data outgoing payment berhasil {(input.IsSubmit ? "disubmit" : "disimpan sebagai draft")}", ResponseCode.Ok);
		}

		public async Task<ResponseBase> DeleteOutgoingPayment(Guid outgoingPaymentId)
		{
			var outgoingPayment = await _dbContext.OutgoingPayments.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentId));
			if (outgoingPayment == null)
				return new ResponseBase("Gagal hapus data, karena data tidak ditemukan", ResponseCode.NotFound);

			if (outgoingPayment.ApprovalStatus != ApprovalStatus.Draft)
				return new ResponseBase("Gagal hapus data, dokumen yang dapat dihapus hanya dokumen berstatus draft", ResponseCode.Error);

			outgoingPayment.RowStatus = 1;

			_dbContext.Update(outgoingPayment);
			await _dbContext.SaveChangesAsync();

			return new ResponseBase("Berhasil menghapus data", ResponseCode.Ok);
		}



		// Need Refactoring

		public async Task<ResponseBase> CancelOutgoingPayment(Guid outgoingPaymentId, CurrentUserAccessor currentUserAccessor)
		{
			var outgoingPayment = await _dbContext.OutgoingPayments.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentId));
			if (outgoingPayment == null)
				return new ResponseBase("Gagal membatalkan dokumen, karena dokumen tidak ditemukan", ResponseCode.NotFound);

			if (outgoingPayment.ApprovalStatus != ApprovalStatus.WaitingApproval)
				return new ResponseBase("Gagal membatalkan dokumen, dokumen yang dapat dibatalkan hanya dokumen berstatus waiting approval", ResponseCode.Error);

			if (outgoingPayment.CreatedBy != currentUserAccessor.Id.ToString())
				return new ResponseBase("Gagal membatalkan dokumen, dokumen yang dapat dibatalkan hanya bisa dibatalkan oleh requestor", ResponseCode.Error);

			outgoingPayment.ApprovalStatus = ApprovalStatus.Cancelled;
			_dbContext.Update(outgoingPayment);

			var cancelApproval = await CancelInboxApproval(outgoingPayment, currentUserAccessor);

			if (!cancelApproval)
				return new ResponseBase("Gagal membatalkan approval untuk dokumen ini");

			await _dbContext.SaveChangesAsync();

			return new ResponseBase("Berhasil membatalkan dokumen", ResponseCode.Ok);
		}

		public async Task<bool> UpdateApprovalStatusOutgoingPayment(string transactionNo, ApprovalStatus approvalStatus)
		{
			var outgoingPayment = await _dbContext.OutgoingPayments.FirstOrDefaultAsync(d => d.TransactionNo.Equals(transactionNo));
			if (outgoingPayment == null) return false;

			outgoingPayment.ApprovalStatus = approvalStatus;
			_dbContext.Update(outgoingPayment);
			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task SendEmailToApprover(SendEmailDto input, ApprovalStatus status)
		{
			var dataUsers = await _dbContext.UserRoles.Include(x => x.User).Include(x => x.Role).AsNoTracking()
				.Where(x => x.Role.RoleCode == input.RoleCodeReceiver).ToListAsync();

			if (dataUsers != null)
			{
				var dataEmailConfigs = _dbContext.AppConfigs.AsNoTracking()
					.Where(x => x.StartDate <= DateTime.Now && x.Modul.Equals("EmailNotification"))
					.AsEnumerable()
					.GroupBy(x => x.Key)
					.SelectMany(g => g
						.OrderByDescending(x => x.StartDate)
						.Take(1))
					.ToList();

				var generalConfig = _dbContext.AppConfigs.AsNoTracking()
					.Where(x => x.StartDate <= DateTime.Now && x.Modul.Equals("General"))
					.AsEnumerable()
					.GroupBy(x => x.Key)
					.SelectMany(g => g
						.OrderByDescending(x => x.StartDate)
						.Take(1))
					.ToList();

				if (dataEmailConfigs != null && generalConfig != null)
				{
					var fromEmail = dataEmailConfigs.FirstOrDefault(x => x.Key.Equals("FromEmail"))!.Value;
					var fromEmailDisplay = dataEmailConfigs.FirstOrDefault(x => x.Key.Equals("FromEmailDisplay"))!.Value;
					var emailPass = dataEmailConfigs.FirstOrDefault(x => x.Key.Equals("FromEmailPassword"))!.Value;
					var templateBody = dataEmailConfigs.FirstOrDefault(x => x.Key.Equals("BodyTemplate"))!.Value;

					var baseUrl = generalConfig.FirstOrDefault(x => x.Key.Equals("BaseUrl"))!.Value;
					string linkDocument = $"{baseUrl}Core/Mailbox/Approval/{input.DocumentId}";

					var body = templateBody
							.Replace("{{toName}}", input.RoleCodeReceiver)
							.Replace("{{linkDocument}}", linkDocument)
							.Replace("{{documentNo}}", input.TransactionNo)
							.Replace("{{action}}", status.ToString())
							.Replace("{{executorName}}", input.ExecutorName);

					if (!string.IsNullOrEmpty(input.Remark))
						body = body.Replace("{{remark}}", $"untuk <strong>{input.Remark}</strong>");
					else
						body = body.Replace("{{remark}}", $"");

					if (input.ScheduleDate != null)
						body = body.Replace("{{scheduledate}}", $"Transaksi perlu dilakukan pada tanggal : <strong>{input.ScheduleDate.Value:dd-MMM-yyyy}</strong>");
					else
						body = body.Replace("{{scheduledate}}", $"");

					var emailDataInput = new EmailData
					{
						BodyEmail = body,
						FromDisplayName = fromEmailDisplay,
						FromEmail = fromEmail,
						PasswordEmail = emailPass,
						SubjectEmail = "Outgoing Payment Notification",
						MultiRecievers = []
					};

					foreach (var user in dataUsers)
					{
						emailDataInput.MultiRecievers.Add(new MailAddress(user.User.Email, user.User.FullName));
					}

					try
					{
						EmailHelper.SendEmailMultiReceiver(emailDataInput);

						await _dbContext.EmailHistories.AddAsync(new EmailHistory
						{
							Sender = emailDataInput.FromEmail,
							Receiver = string.Join("; ", emailDataInput.MultiRecievers.Select(x => x.Address)),
							Subject = emailDataInput.SubjectEmail,
							Content = emailDataInput.BodyEmail,
							Error = string.Empty,
							Status = EmailStatus.Sended
						});
					}
					catch (Exception ex)
					{
						await _dbContext.EmailHistories.AddAsync(new EmailHistory
						{
							Sender = emailDataInput.FromEmail,
							Receiver = string.Join("; ", emailDataInput.MultiRecievers.Select(x => x.Address)),
							Subject = emailDataInput.SubjectEmail,
							Content = emailDataInput.BodyEmail,
							Error = ex.Message,
							Status = EmailStatus.Failed
						});
					}
					finally
					{
						await _dbContext.SaveChangesAsync();
					}
				}
			}
		}

		private async Task<(bool, string)> CreateApprovalWorkflow(DataAccess.Models.OutgoingPayment input, CurrentUserAccessor currentUserAccessor)
		{
			var dataRoleCodes = await _dbContext.UserRoles.Include(ur => ur.Role).Where(d => d.UserId.Equals(currentUserAccessor.Id)).Select(d => d.Role.RoleCode).ToListAsync();
			var workflowRule = await _dbContext.ApprovalRules.AsNoTracking()
				.FirstOrDefaultAsync(x =>
					x.MinAmount <= input.TotalAmount
					&& input.TotalAmount <= x.MaxAmount
					&& x.Level == 1);

			if (workflowRule == null)
				return (false, string.Empty);

			var firstRoleApprover = await _dbContext.ApprovalRules.AsNoTracking()
				.FirstOrDefaultAsync(x => x.TransactionTypeCode == input.TransactionTypeCode && x.MinAmount == workflowRule.MinAmount && x.MaxAmount == workflowRule.MaxAmount && x.Level == 2);

			if (firstRoleApprover == null)
				return (false, string.Empty);

			var dataInbox = new ApprovalInbox
			{
				ApprovalLevel = 2,
				ApprovalRoleCode = firstRoleApprover.RoleCode,
				ApprovalStatus = ApprovalStatus.WaitingApproval,
				TransactionTypeCode = input.TransactionTypeCode,
				TransactionNo = input.TransactionNo,
				MinAmount = workflowRule.MinAmount,
				MaxAmount = workflowRule.MaxAmount
			};

			await _dbContext.ApprovalInboxes.AddAsync(dataInbox);

			var dataHistory = new ApprovalHistory
			{
				ApprovalLevel = 1,
				ExecutorName = input.Requestor,
				ExecutorRoleCode = string.Empty,
				ExecutorRoleDesc = string.Empty,
				ApprovalStatus = ApprovalStatus.Submitted,
				ApprovalUserId = currentUserAccessor.Id,
				TransactionNo = input.TransactionNo,
				MinAmount = workflowRule.MinAmount,
				MaxAmount = workflowRule.MaxAmount
			};

			await _dbContext.ApprovalHistories.AddAsync(dataHistory);
            await _dbContext.SaveChangesAsync();

            return (true, firstRoleApprover.RoleCode);
		}

		private async Task<bool> CancelInboxApproval(DataAccess.Models.OutgoingPayment input, CurrentUserAccessor currentUserAccessor)
		{
			var dataInbox = await _dbContext.ApprovalInboxes.FirstOrDefaultAsync(x => x.TransactionNo == input.TransactionNo);

			if (dataInbox == null)
				return false;

			var dataRole = await _dbContext.UserRoles.Include(x => x.Role).AsNoTracking().FirstOrDefaultAsync(x => x.UserId == currentUserAccessor.Id);

			if (dataRole == null)
				return false;

			dataInbox.ApprovalStatus = ApprovalStatus.Cancelled;
			dataInbox.ApprovalRoleCode = string.Empty;

			_dbContext.Update(dataInbox);


			var dataHistory = new ApprovalHistory
			{
				ApprovalLevel = dataInbox.ApprovalLevel,
				ExecutorName = input.Requestor,
				ExecutorRoleCode = dataRole.Role.RoleCode,
				ExecutorRoleDesc = dataRole.Role.RoleDescription,
				ApprovalStatus = ApprovalStatus.Cancelled,
				ApprovalUserId = currentUserAccessor.Id,
				TransactionNo = input.TransactionNo,
				MinAmount = dataInbox.MinAmount,
				MaxAmount = dataInbox.MaxAmount
			};

			await _dbContext.ApprovalHistories.AddAsync(dataHistory);

			return true;
		}
	}
}
