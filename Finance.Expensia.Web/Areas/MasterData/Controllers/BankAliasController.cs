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
    public class BankAliasController(BankAliasService bankAliasService) : BaseController
    {
        private readonly BankAliasService _bankAliasService = bankAliasService;

        [HttpPost("ddlbankaliases")]
        [AppAuthorize(PermissionConstants.MasterData.CompanyView)]
        public async Task<ResponseObject<List<BankAliasDto>>> RetrieveBankAlias(Guid? companyId)
        {
            return await _bankAliasService.RetrieveBankAlias(companyId);
        }
    }
}
