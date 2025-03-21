﻿using Finance.Expensia.Core.Services.OutgoingPayment;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
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
				return await _outgoingPaymentService.GetListOfOutgoingPayment(input, _currentUserAccessor, false);
			else
                return await _outgoingPaymentService.GetListOfOutgoingPayment(input, _currentUserAccessor, true);
        }

		[AppAuthorize([PermissionConstants.OutgoingPayment.OutgoingPaymentView, PermissionConstants.OutgoingPayment.OutgoingPaymentViewMyDocument])]
		[HttpGet("outgoingpayment/detail")]
		public async Task<ResponseObject<OutgoingPaymentDto>> GetDetailOutgoingPayment([FromQuery] Guid outgoingPaymentId)
		{
			return await _outgoingPaymentService.GetDetailOutgoingPayment(outgoingPaymentId, _currentUserAccessor);
		}

		[AppAuthorize([PermissionConstants.OutgoingPayment.OutgoingPaymentView, PermissionConstants.OutgoingPayment.OutgoingPaymentViewMyDocument])]
		[HttpPost("outgoingpayment/getoutgoingtagging")]
		public async Task<ResponseObject<List<OutgoingPaymentTaggingDto>>> RetrieveOutgoingPaymentTagging([FromBody] PagingSearchInputBase input)
		{
			return await _outgoingPaymentService.RetrieveOutgoingPaymentTagging(input);
		}

		[Mutation]
		[AppAuthorize([PermissionConstants.OutgoingPayment.OutgoingPaymentView, PermissionConstants.OutgoingPayment.OutgoingPaymentViewMyDocument])]
		[HttpPost("outgoingpayment/downloadoutgoingpayment")]
		public async Task<IActionResult> GetDownloadOutgoingPayment([FromBody] DownloadOutgoingPaymentInput input)
		{
			byte[] fileContents = await _outgoingPaymentService.GetFileExcelOutgoingPayment(input, _currentUserAccessor);
			string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
			return File(fileContents, contentType);
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

		[Mutation]
		[AppAuthorize(PermissionConstants.OutgoingPayment.OutgoingPaymentUpsert)]
		[HttpPost("outgoingpayment/cancel")]
		public async Task<ResponseBase> CancelOutgoingPayment([FromQuery] Guid outgoingPaymentId, [FromQuery] string remark)
		{
			return await _outgoingPaymentService.CancelOutgoingPayment(outgoingPaymentId, remark, _currentUserAccessor);
		}
	}
}
