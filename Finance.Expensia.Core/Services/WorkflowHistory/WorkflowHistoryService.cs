using AutoMapper;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.WorkflowHistory
{
	public class WorkflowHistoryService(ApplicationDbContext dbContext, IMapper mapper, ILogger<WorkflowHistoryService> logger)
		: BaseService<WorkflowHistoryService>(dbContext, mapper, logger)
	{
		public async Task<ResponsePaging<object>> GetListWorkflowHistory(PagingSearchInputBase input, CurrentUserAccessor currentUserAccessor)
		{
			var retVal = new ResponsePaging<object>();

			var userId = currentUserAccessor.Id.ToString();
			var dataApprovalHistory = _dbContext.ApprovalHistories
				.Where(x => x.CreatedBy.Equals(userId))
				.Where(x => EF.Functions.Like(x.TransactionNo, $"%{input.SearchKey}%"))
				.OrderByDescending(d => d.Created);

			retVal.ApplyPagination(input.Page, input.PageSize, dataApprovalHistory);

			return await Task.FromResult(retVal);
		}
	}
}
