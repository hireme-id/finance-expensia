using Finance.Expensia.Core.Services.Account;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace rapid.Areas.Account.Controllers
{
    public class LoginController(UserService userService, GoogleAuthService googleAuthService, CurrentUserAccessor currentUserAccessor) : BaseController
    {
        private readonly UserService _userService = userService;
        private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;
        private readonly GoogleAuthService _googleAuthService = googleAuthService;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("user/getauthurl")]
        public ResponseObject<string> GetGoogleAuthUrl()
        {
            var host = GetHost(HttpContext);
            return _googleAuthService.GetAuthUrl(host);
        }

        [AllowAnonymous]
        [HttpPost("user/login")]
        [Mutation]
        public async Task<ResponseObject<LoginDto>> Login(string authCode)
        {
            var host = GetHost(HttpContext);
            var input = await _googleAuthService.GetUserProfile(host, authCode);

            if (input.Obj == null)
                return new ResponseObject<LoginDto>("Gagal melakukan login", ResponseCode.UnAuthorized);

            return await _userService.Login(input.Obj);
        }

        [HttpPost("user/refreshtoken")]
        [AppAuthorize([PermissionConstants.RefreshToken])]
        public async Task<ResponseObject<TokenDto>> RefreshToken()
        {
            return await _userService.RefreshToken(_currentUserAccessor.UserName);
        }

        [HttpPost("user/mypermission")]
        [AppAuthorize([PermissionConstants.MyPermission])]
        public async Task<ResponseObject<MyPermissionDto>> GetMyPermission()
        {
            return await _userService.GetMyPermission(_currentUserAccessor.Id);
        }
    }
}
