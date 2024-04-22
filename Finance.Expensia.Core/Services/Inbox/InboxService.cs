using AutoMapper;
using Finance.Expensia.Core.Services.Inbox.Dtos;
using Finance.Expensia.Core.Services.Inbox.Inputs;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.Inbox
{
    public class InboxService(ApplicationDbContext dbContext, IMapper mapper, ILogger<InboxService> logger)
        : BaseService<InboxService>(dbContext, mapper, logger)
    {
        #region Query
        public async Task<ResponsePaging<ListInboxDto>> GetListOfActiveInbox(ListInboxFilterInput input, Guid userId)
        {
            var retVal = new ResponsePaging<ListInboxDto>();

            var role = await _dbContext.UserRoles.Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (role == null)
                return new ResponsePaging<ListInboxDto>("Data user tidak memiliki role yang tepat", ResponseCode.NotFound);

            var dataInbox = from ibx in _dbContext.ApprovalInboxes
                            join otp in _dbContext.OutgoingPayments
                            on ibx.TransactionNo equals otp.TransactionNo
                            where ibx.ApprovalRoleCode == role.Role.RoleCode
                            orderby otp.RequestDate descending
                            select new ListInboxDto
                            {
                                OutgoingPaymentId = otp.Id,
                                TransactionNo = ibx.TransactionNo,
                                RequestDate = otp.RequestDate,
                                Requestor = otp.Requestor,
                                TotalAmount = otp.TotalAmount,
                                Remark = otp.Remark,
                                BankPaymentType = string.Empty,
                                FromBankAliasName = otp.ToBankAliasName,
                                ToBankAliasName = otp.ToBankAliasName,
                                ApprovalStatus = otp.ApprovalStatus
                            };

            retVal.ApplyPagination(input.Page, input.PageSize, dataInbox);

            return await Task.FromResult(retVal);
        }
        #endregion
    }
}
