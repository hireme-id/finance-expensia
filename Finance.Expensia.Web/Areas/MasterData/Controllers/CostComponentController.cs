using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public class CostComponentController(CostComponentService costComponentService) : BaseController
	{
		private readonly CostComponentService _costComponentService = costComponentService;

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[AppAuthorize(PermissionConstants.MasterData.CostComponent.CostComponentView)]
		[HttpPost("costcomponent/paging")]
		public async Task<ResponsePaging<CostComponentDto>> RetrievePagingCostComponent([FromBody] PagingSearchInputBase input)
		{
			return await _costComponentService.RetrievePagingCostComponent(input);
		}

        [AppAuthorize(PermissionConstants.MasterData.CostComponent.CostComponentView)]
        [HttpPost("costcomponent/find/id")]
		public async Task<ResponseObject<CostComponentDto>> RetrieveCostComponentById([FromQuery] Guid costComponentId)
		{
            return await _costComponentService.RetrieveCostComponentById(costComponentId);
		}

        [Mutation]
        [AppAuthorize(PermissionConstants.MasterData.CostComponent.CostComponentUpsert)]
        [HttpPost("costcomponent/upsert")]
        public async Task<ResponseBase> UpsertCostComponent([FromBody] UpsertCostComponentInput input)
        {
            if (!input.CostComponentId.HasValue)
                return await _costComponentService.CreateCostComponent(input);
            else
                return await _costComponentService.UpdateCostComponent(input);
        }
    }
}
