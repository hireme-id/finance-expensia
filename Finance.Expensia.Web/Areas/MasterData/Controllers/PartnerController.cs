using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    [Route("[controller]")]
    public class PartnerController(PartnerService partnerService) : BaseController
    {
        private readonly PartnerService _partnerService = partnerService;

        [HttpPost("ddlpartner")]
        [AppAuthorize(PermissionConstants.MasterData.PartnerView)]
        public async Task<ResponseObject<List<PartnerDto>>> RetrievePartner(Guid companyId)
        {
            return await _partnerService.RetrievePartner(companyId);
        }
    }
}
