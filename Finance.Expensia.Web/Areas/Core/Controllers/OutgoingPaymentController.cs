using Finance.Expensia.Core.Services.OutgoingPayment;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.Core.Controllers
{
	public class OutgoingPaymentController(OutgoingPaymentService outgoingPaymentService, CurrentUserAccessor currentUserAccessor) : BaseController
	{
		private readonly OutgoingPaymentService _outgoingPaymentService = outgoingPaymentService;
		private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Create()
		{
			return View();
		}

        [AllowAnonymous]
        public IActionResult Edit()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Approval()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Detail()
        {
            return View();
        }

        [Mutation]
		[AppAuthorize(PermissionConstants.OutgoingPayment.OutgoingPaymentUpsert)]
		[HttpPost("outgoingpayment/create")]
		public async Task<ResponseBase> CreateOutgoingPayment([FromBody] CreateOutgoingPaymentInput input)
		{
			return await _outgoingPaymentService.CreateOutgoingPayment(input, _currentUserAccessor);
		}

		[AppAuthorize([PermissionConstants.OutgoingPayment.OutgoingPaymentView, PermissionConstants.OutgoingPayment.OutgoingPaymentViewMyDocument])]
		[HttpPost("outgoingpayment/getlist")]
		public async Task<ResponsePaging<ListOutgoingPaymentDto>> GetListOutgoingPayment([FromBody] ListOutgoingPaymentFilterInput input)
		{
			if (_currentUserAccessor.Permissions!.Any(d => d == PermissionConstants.OutgoingPayment.OutgoingPaymentView))
				return await _outgoingPaymentService.GetListOfOutgoingPayment(input);
			else
                return await _outgoingPaymentService.GetListOfOutgoingPaymentMyDocument(input, _currentUserAccessor);
        }

        [AppAuthorize([PermissionConstants.OutgoingPayment.OutgoingPaymentView, PermissionConstants.OutgoingPayment.OutgoingPaymentViewMyDocument])]
        [HttpGet("outgoingpayment/detail")]
		public async Task<ResponseObject<OutgoingPaymentDto>> GetDetailOutgoingPayment([FromQuery] Guid outgoingPaymentId)
		{
            return await _outgoingPaymentService.GetDetailOutgoingPayment(outgoingPaymentId);
        }

        [Mutation]
        [AppAuthorize(PermissionConstants.OutgoingPayment.OutgoingPaymentUpsert)]
        [HttpPost("outgoingpayment/edit")]
        public async Task<ResponseBase> EditOutgoingPayment([FromBody] EditOutgoingPaymentInput input)
        {
            return await _outgoingPaymentService.EditOutgoingPayment(input, _currentUserAccessor);
        }

		[Mutation]
		[AppAuthorize(PermissionConstants.OutgoingPayment.OutgoingPaymentUpsert)]
		[HttpPost("outgoingpayment/delete")]
		public async Task<ResponseBase> DeleteOutgoingPayment([FromQuery] Guid outgoingPaymentId)
		{
			return await _outgoingPaymentService.DeleteOutgoingPayment(outgoingPaymentId);
		}
	}
}
