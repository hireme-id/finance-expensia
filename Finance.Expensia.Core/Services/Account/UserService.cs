using AutoMapper;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.Core.Services.Account.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.Account
{
    public class UserService(ApplicationDbContext dbContext, IMapper mapper, ILogger<UserService> logger, TokenService tokenService)
        : BaseService<UserService>(dbContext, mapper, logger)
    {
        private readonly TokenService _tokenService = tokenService;

        #region public method
        public async Task<ResponseObject<LoginDto>> Login(LoginInput input)
        {
            var dataUser = await _dbContext.Users
                                       .FirstOrDefaultAsync(d => d.Username.Equals(input.Username));

            if (dataUser == null)
            {
                dataUser = await AddNewUser(input);
            }

            var token = await GenerateAccessToken(dataUser);

            return new ResponseObject<LoginDto>(responseCode: ResponseCode.Ok)
            {
                Obj = new LoginDto
                {
                    DisplayName = input.FullName,
                    PhotoUrl = input.PhotoUrl,
                    AccessToken = token.AccessToken,
                    ExpiredAt = token.ExpiredAt,
                    RefreshToken = token.RefreshToken,
                    SessionExpiredAt = token.SessionExpiredAt
                }
            };
        }

        public async Task<ResponseObject<TokenDto>> RefreshToken(Guid userId)
        {
            var dataUser = await _dbContext.Users
                                       .FirstOrDefaultAsync(d => d.Id.Equals(userId));

            if (dataUser != null)
            {
                return new ResponseObject<TokenDto>(responseCode: ResponseCode.Ok)
                {
                    Obj = await GenerateAccessToken(dataUser)
                };
            }

            return new ResponseObject<TokenDto>($"Failed to get new token");
        }

        public async Task<ResponseObject<MyPermissionDto>> GetMyPermission(Guid userId)
        {
            var myPermission = new MyPermissionDto();

            var data = await _dbContext.Users
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ThenInclude(r => r.RolePermissions).ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(d => d.Id.Equals(userId));

            if (data != null)
            {
                var dataRole = data.UserRoles.FirstOrDefault();

                if (dataRole != null)
                {
                    myPermission.RoleCode = dataRole.Role.RoleCode;
                    myPermission.Permissions = dataRole.Role.RolePermissions.Select(d => d.Permission.PermissionCode).ToList();
                }
            }

            return new ResponseObject<MyPermissionDto>(responseCode: ResponseCode.Ok)
            {
                Obj = myPermission
            };
        }
        #endregion

        #region private method
        private async Task<User> AddNewUser(LoginInput input)
        {
            var newUser = new User
            {
                Username = input.Username,
                Email = input.Username,
                Description = string.Empty,
                FullName = input.FullName,
                PhotoProfileUrl = input.PhotoUrl
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        private async Task<TokenDto> GenerateAccessToken(User dataUser)
        {
            var dataPermissions = await (from u in _dbContext.Users
                                         join ur in _dbContext.UserRoles on u.Id equals ur.UserId
                                         join r in _dbContext.Roles on ur.RoleId equals r.Id
                                         join rp in _dbContext.RolePermissions on r.Id equals rp.RoleId
                                         join p in _dbContext.Permissions on rp.PermissionId equals p.Id
                                         where u.Username.Equals(dataUser.Username)
                                         select p.PermissionCode).ToListAsync();

            return await _tokenService.GenerateToken(dataUser.Username, dataUser.Id, dataUser.FullName, dataPermissions);
        }
        #endregion
    }
}
