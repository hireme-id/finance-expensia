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
    public class CostCenterController(CostCenterService costCenterService) : BaseController
    {
        private readonly CostCenterService _costCenterService = costCenterService;

        [HttpPost("ddlcostcenter")]
        [AppAuthorize(PermissionConstants.MasterData.CostCenterView)]
        public async Task<ResponseObject<List<CostCenterDto>>> RetrieveCostCenter(Guid companyId)
        {
            return await _costCenterService.RetrieveCostCenter(companyId);
        }
    }
}
