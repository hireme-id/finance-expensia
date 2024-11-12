using Finance.Expensia.Core.Services.Employee;
using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Finance.Expensia.Shared.Constants.PermissionConstants.MasterData;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public class TaxController(TaxService taxService) : BaseController
	{
		private readonly TaxService _taxService = taxService;

		[AllowAnonymous]
		public IActionResult ManageEffectiveTaxCategory()
		{
			return View("ManageEffectiveTaxCategory");
		}

        [AppAuthorize(Tax.EffectiveTaxView)]
        [HttpPost("effectivetax/retrieve/category")]
        public async Task<ResponseObject<EffectiveTaxDto>> RetrieveEffectiveTaxDataByCategory([FromQuery]EffectiveTaxCategory EffectiveTaxCategory)
		{
			return await _taxService.RetrieveEffectiveTaxData(EffectiveTaxCategory);
		}

        [AppAuthorize(Tax.EffectiveTaxUpdate)]
        [HttpPost("effectivetax/update")]
		[Mutation]
        public async Task<ResponseBase> UpdateEffectiveTaxData([FromBody]UpdateEffectiveTaxInput input)
		{
            return await _taxService.UpdateEffectiveTaxData(input);
		}
    }
}
