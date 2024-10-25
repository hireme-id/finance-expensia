using AutoMapper;
using Finance.Expensia.Core.Services.DocumentNumbering;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.Core.Services.Workflow;
using Finance.Expensia.Core.Services.Workflow.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.OutgoingPayment
{
    public partial class OutgoingPaymentService(
		ApplicationDbContext dbContext, IMapper mapper, ILogger<OutgoingPaymentService> logger, DocumentNumberingService documentNumberingService, WorkflowService workflowService)
		: BaseService<OutgoingPaymentService>(dbContext, mapper, logger)
	{
		private readonly DocumentNumberingService _documentNumberingService = documentNumberingService;
		private readonly WorkflowService _workflowService = workflowService;

		public async Task<ResponsePaging<ListOutgoingPaymentDto>> GetListOfOutgoingPayment(ListOutgoingPaymentFilterInput input, 
			CurrentUserAccessor currentUserAccessor, bool onlyMyDocument = false)
		{
			var retVal = new ResponsePaging<ListOutgoingPaymentDto>();

			var userCompanyIds = await _dbContext.UserCompanies.Where(d => d.UserId.Equals(currentUserAccessor.Id)).Select(d => d.CompanyId).ToListAsync();

			var dataOutgoingPayments = _dbContext.OutgoingPayments
												 .Where(d => userCompanyIds.Contains(d.CompanyId))
												 .Where(d => !input.CompanyId.HasValue || input.CompanyId.Equals(d.CompanyId))
												 .Where(d => !input.FromBankAliasId.HasValue || input.FromBankAliasId.Equals(d.FromBankAliasId))
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
												 .OrderByDescending(d => d.Modified ?? d.Created);

			var dataOutgoingPaymentsPaging = new ResponsePaging<DataAccess.Models.OutgoingPayment>();
			dataOutgoingPaymentsPaging.ApplyPagination(input.Page, input.PageSize, dataOutgoingPayments);

            // Need store temporary in dataOutgoingPaymentsPaging because o => o.Items .... error on LINQ Expression
            var retValData = dataOutgoingPaymentsPaging.Data?.ToList()
															 .AsQueryable()
															 .Select(d => 
																_mapper.Map<ListOutgoingPaymentDto>(d, o => o.Items.Add("UserId", currentUserAccessor.Id)));
            retVal.CopyPaginationInfo(dataOutgoingPaymentsPaging, retValData);

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

            // Cari role yang sedang di assign pada dokumen outgoing payment ini menggunakan method WorkflowService.GetCurrentRoleApproval
			var currentRoleApproval = await _workflowService.GetCurrentRoleApproval(dataOutgoingPayDto.TransactionNo);
            dataOutgoingPayDto.RoleCodeInCharge = currentRoleApproval;

            // Ambil data user berserta relasi sampai dengan data permission
            var dataUser = await _dbContext.Users
										   .Include(d => d.UserCompanies)
											.ThenInclude(d => d.UserCompanyRoles)
												.ThenInclude(d => d.Role)
                                                    .ThenInclude(d => d.RolePermissions)
                                                        .ThenInclude(d => d.Permission)
                                           .FirstOrDefaultAsync(d => d.Id.Equals(currentUserAccessor.Id));

            if (dataUser != null)
			{
				// Ambil semua permission yang dimiliki user
				var dataPermissions = dataUser.UserCompanies.SelectMany(d => d.UserCompanyRoles)
															.Where(d => d.Role.RoleCode == currentRoleApproval)
															.SelectMany(d => d.Role.RolePermissions
															.Select(e => e.Permission.PermissionCode))
															.Distinct();

				// Cek apakah user memiliki permission ApprovalEditInformation
				dataOutgoingPayDto.AllowApprovalEdit = dataPermissions.Contains(PermissionConstants.ApprovalInbox.ApprovalEditInformation);
			}

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
			var (validateInputStatus, validateInputMessage) = 
				ValidateUpsertOutgoingPaymentInput(input, input?.OutgoingPaymentDetails.Select(_mapper.Map<BaseOutgoingPaymentDetailInput>).ToList() ?? []);

			if (validateInputStatus != ResponseCode.Ok)
				return new ResponseBase(validateInputMessage, validateInputStatus);

            var (validateDataStatus, validateDataMessage, dataCompany, dataFromBankAlias, dataToBankAlias, dataTransactionType) = 
				await ValidateUpsertOutgoingPaymentReferenceData(input!);

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
			dataOutgoingPayment.ApprovalStatus = input!.IsSubmit ? ApprovalStatus.WaitingApproval : ApprovalStatus.Draft;

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
				(var isSuccessWorkflow, string roleCode) = await _workflowService.CreateApprovalWorkflow(dataOutgoingPayment, currentUserAccessor);

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

                await _workflowService.SendEmailToApprover(dataSendEmail, ApprovalStatus.Submitted);
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

			existOutgoing.FromBankAliasId = dataFromBankAlias.Id;
			existOutgoing.FromBankAliasName = dataFromBankAlias.AliasName;
			existOutgoing.FromBankName = dataFromBankAlias.BankName;
			existOutgoing.FromAccountNo = dataFromBankAlias.AccountNo;
			existOutgoing.FromAccountName = dataFromBankAlias.AccountName;

			existOutgoing.ToBankAliasId = dataToBankAlias.Id;
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
				(var isSuccessWorkflow, string roleCode) = await _workflowService.CreateApprovalWorkflow(existOutgoing, currentUserAccessor);

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

                await _workflowService.SendEmailToApprover(dataSendEmail, ApprovalStatus.Submitted);
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

		public async Task<ResponseBase> CancelOutgoingPayment(Guid outgoingPaymentId, string remark, CurrentUserAccessor currentUserAccessor)
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

			var cancelApproval = await _workflowService.CancelApprovalWorkflow(outgoingPayment, remark, currentUserAccessor);

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
	}
}
