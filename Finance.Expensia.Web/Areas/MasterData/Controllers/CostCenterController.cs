using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Finance.Expensia.Shared.Constants.PermissionConstants.MasterData;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public class CostCenterController(CostCenterService costCenterService, CurrentUserAccessor currentUserAccessor) : BaseController
    {
        private readonly CostCenterService _costCenterService = costCenterService;
        private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("ddlcostcenter")]
        [AppAuthorize(CostCenter.CostCenterView)]
        public async Task<ResponseObject<List<CostCenterDto>>> RetrieveCostCenter(Guid companyId)
        {
            return await _costCenterService.RetrieveCostCenter(companyId);
        }

		[HttpPost("costcenter/list")]
		[AppAuthorize(CostCenter.CostCenterView)]
		public async Task<ResponsePaging<CostCenterDto>> GetListCostCenter([FromBody] PagingSearchInputBase input)
		{
			return await _costCenterService.GetListPartner(input, _currentUserAccessor);
		}

		[AppAuthorize(CostCenter.CostCenterView)]
		[HttpPost("costcenter/detail")]
		public async Task<ResponseObject<CostCenterDto>> GetDetailCostCenter([FromQuery] Guid costCenterId)
		{
			return await _costCenterService.GetDetailCostCenter(costCenterId);
		}

		[Mutation]
		[AppAuthorize(CostCenter.CostCenterUpsert)]
		[HttpPost("costcenter/upsert")]
		public async Task<ResponseBase> UpsertCostCenter([FromBody] UpsertCostCenterInput input)
		{
			return await _costCenterService.UpsertCostCenter(input);
		}

		[Mutation]
		[AppAuthorize(CostCenter.CostCenterDelete)]
		[HttpPost("costcenter/delete")]
		public async Task<ResponseBase> DeleteCostCenter([FromQuery] Guid costCenterId)
		{
			return await _costCenterService.DeleteCostCenter(costCenterId);
		}
	}
}
