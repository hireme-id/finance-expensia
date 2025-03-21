﻿using AutoMapper;
using Finance.Expensia.Core.Services.Inbox.Dtos;
using Finance.Expensia.Core.Services.Inbox.Inputs;
using Finance.Expensia.Core.Services.OutgoingPayment;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.Workflow;
using Finance.Expensia.Core.Services.Workflow.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.Inbox
{
    public class InboxService(
		ApplicationDbContext dbContext, IMapper mapper, ILogger<InboxService> logger, OutgoingPaymentService outgoingPaymentService, WorkflowService workflowService)
        : BaseService<InboxService>(dbContext, mapper, logger)
    {
        private readonly OutgoingPaymentService _outgoingPaymentService = outgoingPaymentService;
		private readonly WorkflowService _workflowService = workflowService;

		public async Task<ResponsePaging<ListInboxDto>> GetListOfActiveInbox(ListInboxFilterInput input, Guid userId)
        {
            var retVal = new ResponsePaging<ListInboxDto>();
            var userCompanyIds = await _dbContext.UserCompanies.Where(d => d.UserId.Equals(userId)).Select(d => d.CompanyId).ToListAsync();
            var searchKey = string.IsNullOrEmpty(input.SearchKey) ? string.Empty : input.SearchKey.ToLower();

			var dataInbox = from ibx in _dbContext.ApprovalInboxes
							join ucr in _dbContext.UserCompanyRoles.Where(d => d.UserCompany.UserId.Equals(userId)) 
								on ibx.ApprovalRoleCode equals ucr.Role.RoleCode
							join otp in _dbContext.OutgoingPayments 
								on new { ibx.TransactionNo, ucr.UserCompany.CompanyId } equals new { otp.TransactionNo, otp.CompanyId }
							join tt in _dbContext.TransactionTypes on otp.TransactionTypeId equals tt.Id
							join uc in _dbContext.UserCompanies.Where(d => d.UserId.Equals(userId)) on otp.CompanyId equals uc.CompanyId
							where
                                (!input.StartDate.HasValue || otp.RequestDate >= input.StartDate)
								&& (!input.EndDate.HasValue || otp.RequestDate >= input.EndDate)
								&& (!input.RoleId.HasValue || ucr.RoleId.Equals(input.RoleId))
								&& (!input.CompanyId.HasValue || input.CompanyId.Equals(otp.CompanyId))
								&& (!input.TransactionTypeId.HasValue || input.TransactionTypeId.Equals(otp.TransactionTypeId))
								&& (!input.FromBankAliasId.HasValue || input.FromBankAliasId.Equals(otp.FromBankAliasId))
								&& (
									string.IsNullOrEmpty(searchKey)
									|| EF.Functions.Like(tt.Description, $"%{searchKey}%")
									|| EF.Functions.Like(ibx.TransactionNo, $"%{searchKey}%")
									|| EF.Functions.Like(otp.CompanyName, $"%{searchKey}%")
									|| EF.Functions.Like(otp.FromBankAliasName, $"%{searchKey}%")
									|| EF.Functions.Like(otp.ToBankAliasName, $"%{searchKey}%")
									|| EF.Functions.Like(otp.Remark, $"%{searchKey}%")
									|| EF.Functions.Like(otp.Requestor, $"%{searchKey}%")
                                    || otp.OutgoingPaymentTaggings.Any(t => EF.Functions.Like(t.TagValue, $"%{searchKey}%"))
                                )
								&& ibx.ApprovalStatus == ApprovalStatus.WaitingApproval
                            orderby otp.TotalAmount descending
							select new ListInboxDto
							{
                                OutgoingPaymentId = otp.Id,
                                TransactionTypeDescription = tt.Description,
								TransactionNo = ibx.TransactionNo,
								CompanyName = otp.CompanyName,
								RequestDate = otp.RequestDate,
								ScheduledDate = otp.ScheduledDate,
								Requestor = otp.Requestor,
								TotalAmount = otp.TotalAmount,
								Remark = otp.Remark,
								BankPaymentType = otp.BankPaymentType,
								FromBankAliasName = otp.FromBankAliasName,
								ToBankAliasName = otp.ToBankAliasName,
								ApprovalStatus = otp.ApprovalStatus,
								AllowApproval = uc.AllowApproval,
                                RoleCodeInCharge = ibx.ApprovalRoleCode,
                                OutgoingPaymentTaggings = _mapper.Map<List<OutgoingPaymentTaggingDto>>(otp.OutgoingPaymentTaggings.OrderBy(d => d.Created))
                            };

            retVal.ApplyPagination(input.Page, input.PageSize, dataInbox);

            return await Task.FromResult(retVal);
        }

		public async Task<ResponseObject<List<ListApprovalHistoryDto>>> GetHistoryApproval(ListApprovalHistoryFilterInput request)
		{
			var dataApprovalHistory = await _dbContext.ApprovalHistories
													  .Where(x => x.TransactionNo == request.TransactionNo)
													  .OrderByDescending(x => x.Created)
													  .Select(x => _mapper.Map<ListApprovalHistoryDto>(x))
													  .ToListAsync();

			return new ResponseObject<List<ListApprovalHistoryDto>>(responseCode: ResponseCode.Ok)
			{
				Obj = dataApprovalHistory
			};
        }

        public async Task<ResponseBase> DoActionWorkflow(DoActionWorkflowInput input, CurrentUserAccessor currentUserAccessor)
        {
			#region Cek apakah transaksi ada di inbox dan outgoing payment
			var approvalDocument = await _dbContext.ApprovalInboxes.FirstOrDefaultAsync(d => d.TransactionNo.Equals(input.TransactionNo));
			var outgoingPayment = await _dbContext.OutgoingPayments.Include(op => op.OutgoingPaymentDetails)
																   .FirstOrDefaultAsync(d => d.TransactionNo.Equals(input.TransactionNo));
			if (approvalDocument == null || outgoingPayment == null)
				return new("Gagal melanjutkan proses, karena data tidak ditemukan", ResponseCode.NotFound);
			#endregion

			var currentRoleApproval = approvalDocument.ApprovalRoleCode;

			#region Cek apakah user memiliki akses untuk approval
			var dataRoles = await _dbContext.UserCompanyRoles
											.Include(ucr => ucr.Role)
                                            .Include(ucr => ucr.UserCompany)
                                            .Where(d => d.UserCompany.UserId.Equals(currentUserAccessor.Id))
											.ToListAsync();
			if (!dataRoles.Any(d => d.Role.RoleCode.Equals(approvalDocument.ApprovalRoleCode, StringComparison.OrdinalIgnoreCase)))
				return new("Gagal melanjutkan proses, karena anda tida memiliki akses", ResponseCode.Forbidden);
			#endregion

			#region Proses approval document
			var nextApprover = await _dbContext.ApprovalRules
											   .FirstOrDefaultAsync(x =>
													x.TransactionTypeCode == approvalDocument.TransactionTypeCode
													&& x.MinAmount == approvalDocument.MinAmount
													&& x.MaxAmount == approvalDocument.MaxAmount
													&& x.Level == approvalDocument.ApprovalLevel + 1);

			var approvalStatusWhenUserApprove = nextApprover == null ? ApprovalStatus.Approved : ApprovalStatus.WaitingApproval;
			approvalDocument.ApprovalStatus = input.WorkflowAction == WorkflowAction.Reject ? ApprovalStatus.Reject : approvalStatusWhenUserApprove;
			approvalDocument.ApprovalRoleCode = nextApprover?.RoleCode ?? string.Empty;
			approvalDocument.ApprovalLevel = nextApprover?.Level ?? 0;
			_dbContext.Update(approvalDocument);
			#endregion

			#region Create Workflow History
			if (input.WorkflowAction == WorkflowAction.Approve)
			{
				if (input.ExpectedTransfer == ExpectedTransfer.Scheduled && !input.ScheduledDate.HasValue)
					return new("Schedule date harus diisi");

				string breakLine = "<br/><br/>";

                if (input.ExpectedTransfer != null)
				{
					// Cek menggunakan CheckDifferentData untuk ExpectedTransfer antara input dan outgoingPayment, jika berbeda maka tambahkan ke input.Remark
					var diffExpectedTransfer = CheckDifferentData(outgoingPayment.ExpectedTransfer, input.ExpectedTransfer, "Expected Transfer");
					if (!string.IsNullOrEmpty(diffExpectedTransfer))
					{
						input.Remark = $"{input.Remark}{breakLine}{diffExpectedTransfer}";
						outgoingPayment.ExpectedTransfer = input.ExpectedTransfer.Value;

						if (outgoingPayment.ExpectedTransfer != ExpectedTransfer.Scheduled)
							outgoingPayment.ScheduledDate = null;

						breakLine = "<br/>";
					}
				}

				if (input.ScheduledDate != null)
				{
                    // Cek menggunakan CheckDifferentData untuk ScheduledDate antara input dan outgoingPayment, jika berbeda maka tambahkan ke input.Remark
                    var diffScheduledDate = CheckDifferentData(outgoingPayment.ScheduledDate, input.ScheduledDate, "Scheduled Date");
                    if (!string.IsNullOrEmpty(diffScheduledDate))
                    {
                        input.Remark = $"{input.Remark}{breakLine}{diffScheduledDate}";
                        outgoingPayment.ScheduledDate = input.ScheduledDate;

                        breakLine = "<br/>";
                    }
                }
					
				if (input.FromBankAliasId != null)
				{
					// Cek menggunakan CheckDifferentData untuk FromBankAlias antara input dan outgoingPayment, jika berbeda maka tambahkan ke input.Remark
					var diffFromBankAliasId = CheckDifferentData(outgoingPayment.FromBankAliasId, input.FromBankAliasId, "From Bank Alias");
					if (!string.IsNullOrEmpty(diffFromBankAliasId))
					{
						var fromBankAliasData = await _dbContext.BankAliases.FirstOrDefaultAsync(d => d.Id.Equals(input.FromBankAliasId));
						if (fromBankAliasData != null)
						{
							input.Remark = $"{input.Remark}{breakLine}{diffFromBankAliasId}";
							outgoingPayment.FromBankAliasId = input.FromBankAliasId.Value;
							outgoingPayment.FromBankAliasName = fromBankAliasData.AliasName;
							outgoingPayment.FromBankName = fromBankAliasData.BankName;
							outgoingPayment.FromAccountNo = fromBankAliasData.AccountNo;
							outgoingPayment.FromAccountName = fromBankAliasData.AccountName;

							breakLine = "<br/>";
						}
						else
						{
							throw new CustomValidationException(ResponseCode.NotFound, "Data from bank alias tidak valid");
						}
                    }
						
				}

				if (input.BankPaymentType != null)
				{
					// Cek menggunakan CheckDifferentData untuk BankPaymentType antara input dan outgoingPayment, jika berbeda maka tambahkan ke input.Remark
					var diffBankPaymentType = CheckDifferentData(outgoingPayment.BankPaymentType, input.BankPaymentType, "Bank Payment Type");
					if (!string.IsNullOrEmpty(diffBankPaymentType))
					{
						input.Remark = $"{input.Remark}{breakLine}{diffBankPaymentType}";
						outgoingPayment.BankPaymentType = input.BankPaymentType.Value;

                        breakLine = "<br/>";
                    }
				}

				if (input.OutgoingPaymentDetails.Count > 0)
				{
					if (input.OutgoingPaymentDetails.Count != outgoingPayment.OutgoingPaymentDetails.Count)
						return new("Gagal melakukan approval karena data detail tidak valid");

					foreach (var outgoingPaymentDetail in outgoingPayment.OutgoingPaymentDetails)
					{
						var outgoingPaymentDetailId = outgoingPaymentDetail.Id;
						var iOutgoingPaymentDetailData = input.OutgoingPaymentDetails.First(d => d.OutgoingPaymentDetailId.Equals(outgoingPaymentDetailId));
						
						var diffChartOfAccount = 
							CheckDifferentData(
								outgoingPaymentDetail.ChartOfAccountId, 
								iOutgoingPaymentDetailData.ChartOfAccountId, 
								"Chart of Account"
							);

						if (!string.IsNullOrEmpty(diffChartOfAccount))
						{
							var coaData = await _dbContext.ChartOfAccounts.FirstAsync(d => d.Id.Equals(iOutgoingPaymentDetailData.ChartOfAccountId));

							input.Remark = $"{input.Remark}{breakLine}{diffChartOfAccount} ({outgoingPaymentDetail.Description})";
							
							outgoingPaymentDetail.ChartOfAccountId = iOutgoingPaymentDetailData.ChartOfAccountId;
							outgoingPaymentDetail.ChartOfAccountNo = coaData.AccountCode;
							outgoingPaymentDetail.ChartOfAccountName = coaData.AccountName;

							breakLine = "<br/>";
						}

						var diffCostCenter =
							CheckDifferentData(
								outgoingPaymentDetail.CostCenterId,
								iOutgoingPaymentDetailData.CostCenterId,
								"Cost Center"
							);

						if (!string.IsNullOrEmpty(diffCostCenter))
						{
							var costCenterData = await _dbContext.CostCenters.FirstOrDefaultAsync(d => d.Id.Equals(iOutgoingPaymentDetailData.CostCenterId));

							input.Remark = $"{input.Remark}{breakLine}{diffCostCenter} ({outgoingPaymentDetail.Description})";

							outgoingPaymentDetail.CostCenterId = iOutgoingPaymentDetailData.CostCenterId;
							outgoingPaymentDetail.CostCenterCode = costCenterData?.CostCenterCode ?? string.Empty;
							outgoingPaymentDetail.CostCenterName = costCenterData?.CostCenterName ?? string.Empty;

							breakLine = "<br/>";
						}
					}
				}
			}

			var dataHistory = new ApprovalHistory
			{
				ApprovalLevel = approvalDocument.ApprovalLevel,
				ExecutorName = currentUserAccessor.FullName,
				ExecutorRoleCode = currentRoleApproval,
				ExecutorRoleDesc = dataRoles.First(d => d.Role.RoleCode.Equals(currentRoleApproval)).Role.RoleDescription,
				ApprovalStatus = input.WorkflowAction == WorkflowAction.Approve ? ApprovalStatus.Approved : ApprovalStatus.Reject,
				ApprovalUserId = currentUserAccessor.Id,
				TransactionNo = approvalDocument.TransactionNo,
				MinAmount = approvalDocument.MinAmount,
				MaxAmount = approvalDocument.MaxAmount,
				Remark = input.Remark
			};
			await _dbContext.ApprovalHistories.AddAsync(dataHistory);
			#endregion

			await _dbContext.SaveChangesAsync();

			#region Update outgoing payment jika approval status bukan waiting approval dan send email ke requestor
			// if approval status is not waiting approval then update approval status in outgoing payment
			if (approvalDocument.ApprovalStatus != ApprovalStatus.WaitingApproval)
			{
				await _outgoingPaymentService.UpdateApprovalStatusOutgoingPayment(approvalDocument.TransactionNo, approvalDocument.ApprovalStatus);

				// Send email to requestor if action is approve or reject
				var dataSendEmail = new SendEmailDto
				{
					DocumentId = outgoingPayment.Id,
					ExecutorName = currentUserAccessor.FullName,
					RequestorName = outgoingPayment.Requestor,
					TransactionNo = outgoingPayment.TransactionNo,
					RoleCodeReceiver = string.Empty,
					Remark = outgoingPayment.Remark,
					ScheduleDate = outgoingPayment.ScheduledDate,
					RejectReason = approvalDocument.ApprovalStatus == ApprovalStatus.Reject ? input.Remark : string.Empty
				};

				await _workflowService.SendEmailToRequestor(dataSendEmail, approvalDocument.ApprovalStatus, outgoingPayment.CreatedBy);
			}
			#endregion

			// nextApprover != null then there is next approver and send email to next approver if action is approve
			if (nextApprover != null && input.WorkflowAction == WorkflowAction.Approve)
			{
				var dataSendEmail = new SendEmailDto
				{
					DocumentId = outgoingPayment.Id,
					ExecutorName = currentUserAccessor.FullName,
					TransactionNo = outgoingPayment.TransactionNo,
					RoleCodeReceiver = nextApprover.RoleCode,
                    Remark = outgoingPayment.Remark,
					ScheduleDate = outgoingPayment.ScheduledDate
                };

				// Send email to next approver
				await _workflowService.SendEmailToApprover(dataSendEmail, ApprovalStatus.Approved);
			}

			return new("Proses approval berhasil dilakukan", ResponseCode.Ok);
		}

        public async Task<ResponseBase> DoActionWorkflows(List<DoActionWorkflowInput> inputs, CurrentUserAccessor currentUserAccessor)
        {
			foreach (var item in inputs)
			{
				var retVal = await DoActionWorkflow(item, currentUserAccessor);

				if (!retVal.Succeeded)
					return retVal;
			}

			return new ResponseBase("Proses approval berhasil dilakukan", ResponseCode.Ok);
		}

		// Fungsi untuk melakukan pengecekan apakah 2 data berbeda
		// Data dapat memiliki tipe apapun.
		private string CheckDifferentData<T>(T oldValue, T newValue, string fieldName)
		{
			string oldValueString = oldValue?.ToString() ?? "kosong";
			string newValueString = newValue?.ToString() ?? "kosong";

			if (oldValue is Guid oldValueId && newValue is Guid newValueId)
			{
				if (fieldName == "From Bank Alias")
				{
					oldValueString = _dbContext.BankAliases.FirstOrDefault(d => d.Id.Equals(oldValueId))?.AliasName ?? oldValueString;
					newValueString = _dbContext.BankAliases.FirstOrDefault(d => d.Id.Equals(newValueId))?.AliasName ?? newValueString;
				}

				if (fieldName == "Chart of Account")
				{
					oldValueString = _dbContext.ChartOfAccounts.FirstOrDefault(d => d.Id.Equals(oldValueId))?.AccountName ?? oldValueString;
					newValueString = _dbContext.ChartOfAccounts.FirstOrDefault(d => d.Id.Equals(newValueId))?.AccountName ?? newValueString;
				}

				if (fieldName == "Cost Center")
				{
					oldValueString = _dbContext.CostCenters.FirstOrDefault(d => d.Id.Equals(oldValueId))?.CostCenterName ?? oldValueString;
					newValueString = _dbContext.CostCenters.FirstOrDefault(d => d.Id.Equals(newValueId))?.CostCenterName ?? newValueString;
				}
			}

			// Jika berbeda maka return string menjelaskan dari value awal diubah menjadi value yang baru, jika sama maka return string kosong
			return !EqualityComparer<T>.Default.Equals(oldValue, newValue) ? $"{fieldName} diubah dari {oldValueString} menjadi {newValueString}" : string.Empty;
		}
	}
}
