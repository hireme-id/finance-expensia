using Finance.Expensia.Core.Services.OutgoingPayment;
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

		[Mutation]
		[AppAuthorize(PermissionConstants.OutgoingPayment.OutgoingPaymentUpsert)]
		[HttpPost("outgoingpayment/create")]
		public async Task<ResponseBase> CreateOutgoingPayment([FromBody] CreateOutgoingPaymentInput input)
		{
			return await _outgoingPaymentService.CreateOutgoingPayment(input, _currentUserAccessor);
		}
	}
}
