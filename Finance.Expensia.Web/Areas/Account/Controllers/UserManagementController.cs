using Finance.Expensia.Core.Services.Account;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.Core.Services.Account.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Finance.Expensia.Shared.Constants.PermissionConstants;

namespace Finance.Expensia.Web.Areas.Account.Controllers
{
    public class UserManagementController(UserManagementService userManagementService, CurrentUserAccessor currentUserAccessor) : BaseController
    {
        private readonly UserManagementService _userManagementService = userManagementService;
        private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

        [AllowAnonymous]
        public IActionResult ManageUser()
        {
            return View("ManageUser");
        }

        [HttpPost("ddlrole")]
        [AppAuthorize(UserManagement.RoleView)]
        public async Task<ResponseObject<List<RoleDto>>> GetListRole()
        {
            return await _userManagementService.GetListRole();
        }

        [HttpPost("ddlrolebyuserid")]
        [AppAuthorize(UserManagement.RoleView)]
        public async Task<ResponseObject<List<RoleDto>>> RetrieveRoleByUserId()
        {
            return await _userManagementService.RetrieveRoleByUserId(_currentUserAccessor);
        }

        [HttpPost("ddlusers")]
        [AppAuthorize(PermissionConstants.MasterData.Recruiter.RecruiterUpsert)]
        public async Task<ResponseObject<List<UserDto>>> RetrieveUsers()
        {
            return await _userManagementService.RetrieveUsers();
        }

        [HttpPost("user/list")]
        [AppAuthorize(UserManagement.ManageUser.ManageUserView)]
        public async Task<ResponsePaging<ListUserDto>> GetListUser([FromBody] PagingSearchInputBase input)
        {
            return await _userManagementService.GetListUser(input);
        }

        [HttpPost("user/detail")]
        [AppAuthorize(UserManagement.ManageUser.ManageUserView)]
        public async Task<ResponseObject<UserDto>> GetDetailUser([FromQuery] Guid userId)
        {
            return await _userManagementService.GetDetailUser(userId);
        }

        [HttpPost("user/update")]
        [Mutation]
        [AppAuthorize(UserManagement.ManageUser.ManageUserUpdate)]
        public async Task<ResponseBase> UpdateUser([FromBody] UserInput input)
        {
            return await _userManagementService.UpdateUser(input);
        }
    }
}
