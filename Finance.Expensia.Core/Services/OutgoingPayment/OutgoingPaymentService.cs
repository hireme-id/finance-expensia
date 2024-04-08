using AutoMapper;
using Finance.Expensia.Core.Services.Account;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.OutgoingPayment
{
    public class OutgoingPaymentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<OutgoingPaymentService> logger) 
        : BaseService<OutgoingPaymentService>(dbContext, mapper, logger)
    {
        #region Query
        public async Task<ResponsePaging<ListOutgoingPaymentDto>> GetListOfOutgoingPayment(ListOutgoingPaymentFilterInput input, string userId)
        {
            var retVal = new ResponsePaging<ListOutgoingPaymentDto>();

            var dataOutgoingPayments = _dbContext.OutgoingPayments
                .Where(d =>
                    EF.Functions.Like(d.ApprovalStatus.ToString(), $"%{input.SearchKey}%")
                )
                .Where(d => !input.StartDate.HasValue || d.RequestDate >= input.StartDate)
                .Where(d => !input.EndDate.HasValue || d.RequestDate <= input.EndDate)
                .Where(d => d.CreatedBy == userId)
                .OrderByDescending(d => d.RequestDate)
                .Select(d => _mapper.Map<ListOutgoingPaymentDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, dataOutgoingPayments);

            return await Task.FromResult(retVal);
        }

        #endregion
    }
}
