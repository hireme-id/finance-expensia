using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using static Finance.Expensia.Shared.Constants.PermissionConstants.MasterData;
using Finance.Expensia.Shared.Objects.Inputs;

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
        [AppAuthorize(Partner.PartnerView)]
        public async Task<ResponseObject<List<PartnerDto>>> RetrievePartner()
        {
            return await _partnerService.RetrievePartner();
        }

        [HttpPost("partner/list")]
        [AppAuthorize(Partner.PartnerView)]
        public async Task<ResponsePaging<PartnerDto>> GetListPartner([FromBody] PagingSearchInputBase input)
        {
            return await _partnerService.GetListPartner(input);
        }

        [AppAuthorize(Partner.PartnerView)]
        [HttpPost("partner/detail")]
		public async Task<ResponseObject<PartnerDto>> GetDetailPartner([FromQuery] Guid partnertId)
		{
			return await _partnerService.GetDetailPartner(partnertId);
		}

        [Mutation]
        [AppAuthorize(Partner.PartnerUpsert)]
        [HttpPost("partner/upsert")]
        public async Task<ResponseBase> UpsertPartner([FromBody] UpsertPartnerInput input)
        {
            return await _partnerService.UpsertPartner(input);
        }

        [Mutation]
        [AppAuthorize(Partner.PartnerDelete)]
        [HttpPost("partner/delete")]
        public async Task<ResponseBase> DeletePartner([FromQuery] Guid partnerId)
        {
            return await _partnerService.DeletePartner(partnerId);
        }
    }
}
