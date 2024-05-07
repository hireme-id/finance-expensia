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
    public class CoaController(CoaService coaService) : BaseController
    {
        private readonly CoaService _coaService = coaService;

        [HttpPost("ddlcoa")]
        [AppAuthorize(PermissionConstants.MasterData.CoaView)]
        public async Task<ResponseObject<List<CoaDto>>> RetrieveCoa(Guid companyId)
        {
            return await _coaService.RetrieveCoa(companyId);
        }
    }
}
