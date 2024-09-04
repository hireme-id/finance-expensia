using AutoMapper;
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
							join ur in _dbContext.UserRoles.Where(d => d.UserId.Equals(userId)) on ibx.ApprovalRoleCode equals ur.Role.RoleCode
							join otp in _dbContext.OutgoingPayments on ibx.TransactionNo equals otp.TransactionNo
							join tt in _dbContext.TransactionTypes on otp.TransactionTypeId equals tt.Id
							join uc in _dbContext.UserCompanies.Where(d => d.UserId.Equals(userId)) on otp.CompanyId equals uc.CompanyId
							where
                                (!input.StartDate.HasValue || otp.RequestDate >= input.StartDate)
								&& (!input.EndDate.HasValue || otp.RequestDate >= input.EndDate)
								&& (!input.RoleId.HasValue || ur.RoleId.Equals(input.RoleId))
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
			var outgoingPayment = await _dbContext.OutgoingPayments.FirstOrDefaultAsync(d => d.TransactionNo.Equals(input.TransactionNo));
			if (approvalDocument == null || outgoingPayment == null)
				return new ResponseBase("Gagal melanjutkan proses, karena data tidak ditemukan", ResponseCode.NotFound);
			#endregion

			var currentRoleApproval = approvalDocument.ApprovalRoleCode;

			#region Cek apakah user memiliki akses untuk approval
			var dataRoles = await _dbContext.UserRoles
											.Include(ur => ur.Role)
											.Where(d => d.UserId.Equals(currentUserAccessor.Id))
											.ToListAsync();
			if (!dataRoles.Any(d => d.Role.RoleCode.Equals(approvalDocument.ApprovalRoleCode, StringComparison.OrdinalIgnoreCase)))
				return new ResponseBase("Gagal melanjutkan proses, karena anda tida memiliki akses", ResponseCode.Forbidden);
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
					return new ResponseBase("Schedule date harus diisi");

				if (input.ExpectedTransfer != null)
				{
					// Cek menggunakan CheckDifferentData untuk ExpectedTransfer antara input dan outgoingPayment, jika berbeda maka tambahkan ke input.Remark
					var diffExpectedTransfer = CheckDifferentData(outgoingPayment.ExpectedTransfer, input.ExpectedTransfer, "Expected Transfer");
					if (!string.IsNullOrEmpty(diffExpectedTransfer))
					{
						input.Remark = $"{input.Remark}<br/><br/>{diffExpectedTransfer}";
						outgoingPayment.ExpectedTransfer = input.ExpectedTransfer.Value;
					}
						
				}

				// Cek menggunakan CheckDifferentData untuk ScheduledDate antara input dan outgoingPayment, jika berbeda maka tambahkan ke input.Remark
				var diffScheduledDate = CheckDifferentData(outgoingPayment.ScheduledDate, input.ScheduledDate, "Scheduled Date");
				if (!string.IsNullOrEmpty(diffScheduledDate))
				{
					input.Remark = $"{input.Remark}<br/><br/>{diffScheduledDate}";
					outgoingPayment.ScheduledDate = input.ScheduledDate;
				}
					

				if (input.FromBankAliasId != null)
				{
					// Cek menggunakan CheckDifferentData untuk FromBankAlias antara input dan outgoingPayment, jika berbeda maka tambahkan ke input.Remark
					var diffFromBankAliasId = CheckDifferentData(outgoingPayment.FromBankAliasId, input.FromBankAliasId, "From Bank Alias");
					if (!string.IsNullOrEmpty(diffFromBankAliasId))
					{
						input.Remark = $"{input.Remark}<br/><br/>{diffFromBankAliasId}";
						outgoingPayment.FromBankAliasId = input.FromBankAliasId.Value;
					}
						
				}

				if (input.BankPaymentType != null)
				{
					// Cek menggunakan CheckDifferentData untuk BankPaymentType antara input dan outgoingPayment, jika berbeda maka tambahkan ke input.Remark
					var diffBankPaymentType = CheckDifferentData(outgoingPayment.BankPaymentType, input.BankPaymentType, "Bank Payment Type");
					if (!string.IsNullOrEmpty(diffBankPaymentType))
					{
						input.Remark = $"{input.Remark}<br/><br/>{diffBankPaymentType}";
						outgoingPayment.BankPaymentType = input.BankPaymentType.Value;
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

			return new ResponseBase("Proses approval berhasil dilakukan", ResponseCode.Ok);
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
			}

			// Jika berbeda maka return string menjelaskan dari value awal diubah menjadi value yang baru, jika sama maka return string kosong
			return !EqualityComparer<T>.Default.Equals(oldValue, newValue) ? $"{fieldName} diubah dari {oldValueString} menjadi {newValueString}" : string.Empty;
		}
	}
}
