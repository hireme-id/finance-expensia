using Finance.Expensia.Core.Services.Account;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using static Finance.Expensia.Shared.Constants.PermissionConstants;

namespace Finance.Expensia.Web.Areas.Account.Controllers
{
    public class UserManagementController(UserManagementService userManagementService, CurrentUserAccessor currentUserAccessor) : BaseController
    {
        private readonly UserManagementService _userManagementService = userManagementService;
        private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

        [HttpPost("ddlrole")]
        [AppAuthorize(UserManagement.RoleView)]
        public async Task<ResponseObject<List<RoleDto>>> RetrieveRole()
        {
            return await _userManagementService.RetrieveRole(_currentUserAccessor);
        }
    }
}
