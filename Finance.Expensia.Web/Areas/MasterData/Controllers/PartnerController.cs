using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.Core.Services.OutgoingPayment;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Finance.Expensia.Core.Services.MasterData.Inputs;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public class PartnerController(PartnerService partnerService) : BaseController
    {
        private readonly PartnerService _partnerService = partnerService;

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost("ddlpartner")]
        [AppAuthorize(PermissionConstants.MasterData.PartnerView)]
        public async Task<ResponseObject<List<PartnerDto>>> RetrievePartner()
        {
            return await _partnerService.RetrievePartner();
        }

        [HttpPost("partner/list")]
        [AppAuthorize(PermissionConstants.MasterData.PartnerView)]
        public async Task<ResponsePaging<PartnerDto>> GetListPartner([FromBody] ListPartnerInput input)
        {
            return await _partnerService.GetListPartner(input);
        }

        [AppAuthorize(PermissionConstants.MasterData.PartnerView)]
        [HttpPost("partner/detail")]
		public async Task<ResponseObject<PartnerDto>> GetDetailPartner([FromQuery] Guid partnertId)
		{
			return await _partnerService.GetDetailPartner(partnertId);
		}

        [Mutation]
        [AppAuthorize(PermissionConstants.MasterData.PartnerView)]
        [HttpPost("partner/create")]
        public async Task<ResponseBase> CreatePartner([FromBody] UpsertPartnerInput input)
        {
            return await _partnerService.UpsertPartner(input);
        }
    }
}
