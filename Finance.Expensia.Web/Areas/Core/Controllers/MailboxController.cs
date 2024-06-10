using Finance.Expensia.Core.Services.Inbox;
using Finance.Expensia.Core.Services.Inbox.Dtos;
using Finance.Expensia.Core.Services.Inbox.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.Core.Controllers
{
	public class MailboxController(InboxService inboxService, CurrentUserAccessor currentUserAccessor) : Controller
	{
		private readonly InboxService _inboxService = inboxService;
		private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Approval()
		{
			return View();
		}

		[AppAuthorize(PermissionConstants.ApprovalInbox.ApprovalInboxView)]
		[HttpPost("inbox/getlist")]
		public async Task<ResponsePaging<ListInboxDto>> GetListInbox([FromBody] ListInboxFilterInput input)
		{
			return await _inboxService.GetListOfActiveInbox(input, _currentUserAccessor.Id);
		}

		[AppAuthorize([PermissionConstants.ApprovalInbox.ApprovalInboxView, PermissionConstants.OutgoingPayment.OutgoingPaymentView, PermissionConstants.OutgoingPayment.OutgoingPaymentViewMyDocument])]
		[HttpPost("inbox/getlistHistory")]
		public async Task<ResponseObject<List<ListApprovalHistoryDto>>> GetListApprovalHistory([FromBody] ListApprovalHistoryFilterInput input)
		{
			return await _inboxService.GetHistoryApproval(input);
		}

		[AppAuthorize(PermissionConstants.ApprovalInbox.ApprovalInboxUpdate)]
		[Mutation]
		[HttpPost("inbox/doaction")]
		public async Task<ResponseBase> DoActionApproval([FromBody] DoActionWorkflowInput input)
		{
			return await _inboxService.DoActionWorkflow(input, _currentUserAccessor);
		}

		[AppAuthorize(PermissionConstants.ApprovalInbox.ApprovalInboxUpdate)]
		[Mutation]
		[HttpPost("inbox/doactions")]
		public async Task<ResponseBase> DoActionApprovals([FromBody] List<DoActionWorkflowInput> input)
		{
			return await _inboxService.DoActionWorkflows(input, _currentUserAccessor);
		}
	}
}
