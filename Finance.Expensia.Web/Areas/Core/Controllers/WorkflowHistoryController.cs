using Finance.Expensia.Core.Services.WorkflowHistory;
using Finance.Expensia.Core.Services.Inbox;
using Finance.Expensia.Core.Services.Inbox.Dtos;
using Finance.Expensia.Core.Services.Inbox.Inputs;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;

namespace Finance.Expensia.Web.Areas.Core.Controllers
{
	public class WorkflowHistoryController(WorkflowHistoryService workflowHistoryService, CurrentUserAccessor currentUserAccessor) : Controller
	{
		private readonly WorkflowHistoryService _workflowHistoryService1 = workflowHistoryService;
		private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

        [AppAuthorize(PermissionConstants.WorkflowHistory.WorkflowHistoryView)]
        [HttpPost("workflowhistory/getlist")]
        public async Task<ResponsePaging<object>> GetListWorkflowHistory([FromBody] PagingSearchInputBase input)
        {
            return await _workflowHistoryService1.GetListWorkflowHistory(input, _currentUserAccessor);
        }
    }
}
