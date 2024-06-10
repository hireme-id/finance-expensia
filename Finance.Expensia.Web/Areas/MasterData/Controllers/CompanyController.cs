using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    [Route("[controller]")]
    public class CompanyController(CompanyService companyService, CurrentUserAccessor currentUserAccessor) : BaseController
    {
        private readonly CompanyService _companyService = companyService;
        private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

        [HttpPost("ddlcompanies")]
        [AppAuthorize(PermissionConstants.MasterData.CompanyView)]
        public async Task<ResponseObject<List<CompanyDto>>> RetrieveCompanyDatas()
        {
            return await _companyService.RetrieveCompanyDatas(_currentUserAccessor.Id);
        }
    }
}
