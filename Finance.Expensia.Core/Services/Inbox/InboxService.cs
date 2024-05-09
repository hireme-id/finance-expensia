using AutoMapper;
using Finance.Expensia.Core.Services.Inbox.Dtos;
using Finance.Expensia.Core.Services.Inbox.Inputs;
using Finance.Expensia.Core.Services.OutgoingPayment;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.Inbox
{
    public class InboxService(ApplicationDbContext dbContext, IMapper mapper, ILogger<InboxService> logger, OutgoingPaymentService outgoingPaymentService)
        : BaseService<InboxService>(dbContext, mapper, logger)
    {
        private readonly OutgoingPaymentService _outgoingPaymentService = outgoingPaymentService;

        public async Task<ResponsePaging<ListInboxDto>> GetListOfActiveInbox(ListInboxFilterInput input, Guid userId)
        {
            var retVal = new ResponsePaging<ListInboxDto>();

            var dataInbox = from ibx in _dbContext.ApprovalInboxes
							join ur in _dbContext.UserRoles.Where(d => d.UserId.Equals(userId)) on ibx.ApprovalRoleCode equals ur.Role.RoleCode
                            join otp in _dbContext.OutgoingPayments on ibx.TransactionNo equals otp.TransactionNo
							join tt in _dbContext.TransactionTypes on otp.TransactionTypeId equals tt.Id
                            where
                                (!input.StartDate.HasValue || otp.RequestDate >= input.StartDate)
                                && (!input.EndDate.HasValue || otp.RequestDate >= input.EndDate)
                                && (!input.CompanyId.HasValue || input.CompanyId.Equals(otp.CompanyId))
                                && (!input.TransactionTypeId.HasValue || input.TransactionTypeId.Equals(otp.TransactionTypeId))
                                && (!input.FromBankAliasId.HasValue || input.FromBankAliasId.Equals(otp.FromBankAliasId))
								&& ibx.ApprovalStatus == ApprovalStatus.WaitingApproval
                            orderby otp.TotalAmount descending
                            select new ListInboxDto
                            {
								TransactionTypeDescription = tt.Description,
                                OutgoingPaymentId = otp.Id,
                                TransactionNo = ibx.TransactionNo,
                                CompanyName = otp.CompanyName,
                                RequestDate = otp.RequestDate,
                                Requestor = otp.Requestor,
                                TotalAmount = otp.TotalAmount,
                                Remark = otp.Remark,
                                BankPaymentType = string.Empty,
                                FromBankAliasName = otp.FromBankAliasName,
                                ToBankAliasName = otp.ToBankAliasName,
                                ApprovalStatus = otp.ApprovalStatus
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
			var approvalDocument = await _dbContext.ApprovalInboxes.FirstOrDefaultAsync(d => d.TransactionNo.Equals(input.TransactionNo));
			var outgoingPayment = await _dbContext.OutgoingPayments.FirstOrDefaultAsync(d => d.TransactionNo.Equals(input.TransactionNo));
			if (approvalDocument == null || outgoingPayment == null)
				return new ResponseBase("Gagal melanjutkan proses, karena data tidak ditemukan", ResponseCode.NotFound);

			var dataRoles = await _dbContext.UserRoles
											.Include(ur => ur.Role)
											.Where(d => d.UserId.Equals(currentUserAccessor.Id))
											.ToListAsync();

			if (!dataRoles.Any(d => d.Role.RoleCode.Equals(approvalDocument.ApprovalRoleCode, StringComparison.OrdinalIgnoreCase)))
				return new ResponseBase("Gagal melanjutkan proses, karena anda tida memiliki akses", ResponseCode.Forbidden);

			var nextApprover = await _dbContext.ApprovalRules
											   .FirstOrDefaultAsync(x =>
													x.TransactionTypeCode == approvalDocument.TransactionTypeCode
													&& x.MinAmount == approvalDocument.MinAmount
													&& x.MaxAmount == approvalDocument.MaxAmount
													&& x.Level == approvalDocument.ApprovalLevel + 1);

			var statusApprove = input.WorkflowAction == WorkflowAction.Approve ? ApprovalStatus.Approved : ApprovalStatus.Reject;

			var dataHistory = new ApprovalHistory
			{
				ApprovalLevel = approvalDocument.ApprovalLevel,
				ExecutorName = currentUserAccessor.FullName,
				ExecutorRoleCode = approvalDocument.ApprovalRoleCode,
				ExecutorRoleDesc = dataRoles.First(d => d.Role.RoleCode.Equals(approvalDocument.ApprovalRoleCode)).Role.RoleDescription,
				ApprovalStatus = statusApprove,
				ApprovalUserId = currentUserAccessor.Id,
				TransactionNo = approvalDocument.TransactionNo,
				MinAmount = approvalDocument.MinAmount,
				MaxAmount = approvalDocument.MaxAmount,
				Remark = input.Remark
			};
			await _dbContext.ApprovalHistories.AddAsync(dataHistory);

			var approvalStatusForApprove = nextApprover == null ? ApprovalStatus.Approved : ApprovalStatus.WaitingApproval;
			approvalDocument.ApprovalStatus = input.WorkflowAction == WorkflowAction.Reject ? ApprovalStatus.Reject : approvalStatusForApprove;
			approvalDocument.ApprovalRoleCode = nextApprover?.RoleCode ?? string.Empty;
			approvalDocument.ApprovalLevel = nextApprover?.Level ?? 0;
			_dbContext.Update(approvalDocument);

			if (approvalDocument.ApprovalStatus != ApprovalStatus.WaitingApproval)
			{
				await _outgoingPaymentService.UpdateApprovalStatusOutgoingPayment(approvalDocument.TransactionNo, approvalDocument.ApprovalStatus);
			}

			await _dbContext.SaveChangesAsync();
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
    }
}
