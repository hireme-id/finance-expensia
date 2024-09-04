using AutoMapper;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.Core.Services.Account.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Finance.Expensia.Core.Services.Account
{
    public class AccessControlService(ApplicationDbContext dbContext, IMapper mapper, ILogger<AccessControlService> logger, TokenService tokenService)
        : BaseService<AccessControlService>(dbContext, mapper, logger)
    {
        private readonly TokenService _tokenService = tokenService;

        public async Task<ResponseObject<LoginDto>> Login(LoginInput input)
        {
            var dataUser = await _dbContext.Users.FirstOrDefaultAsync(d => d.Username.Equals(input.Username)) ?? await AddNewUser(input);

            dataUser.FullName = input.FullName;
            dataUser.PhotoProfileUrl = input.PhotoUrl;

            _dbContext.Update(dataUser);
            await _dbContext.SaveChangesAsync();

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
            var dataUser = await _dbContext.Users.FirstOrDefaultAsync(d => d.Id.Equals(userId));

            if (dataUser == null)
				return new ResponseObject<TokenDto>($"Gagal memperbaharui akses token", ResponseCode.Forbidden);

			return new ResponseObject<TokenDto>(responseCode: ResponseCode.Ok)
			{
				Obj = await GenerateAccessToken(dataUser)
			};
		}

        public async Task<ResponseObject<MyPermissionDto>> GetMyPermission(Guid userId)
        {
            var myPermission = new MyPermissionDto();

            var data = await _dbContext.Users
                                       .Include(u => u.UserCompanies)
                                        .ThenInclude(uc => uc.UserRoles)
                                            .ThenInclude(ur => ur.Role)
                                                .ThenInclude(r => r.RolePermissions)
                                                    .ThenInclude(rp => rp.Permission)
                                       .FirstOrDefaultAsync(d => d.Id.Equals(userId));

            if (data == null)
                return new ResponseObject<MyPermissionDto>("Data user tidak valid", ResponseCode.NotFound);

			myPermission.RoleCode = string.Join(",", data.UserCompanies.SelectMany(d => d.UserRoles).Select(d => d.Role.RoleCode).Distinct());
			myPermission.Permissions = [.. data.UserCompanies.SelectMany(d => d.UserRoles).SelectMany(d => d.Role.RolePermissions.Select(e => e.Permission.PermissionCode)).Distinct().OrderBy(d => d)];

			return new ResponseObject<MyPermissionDto>(responseCode: ResponseCode.Ok)
            {
                Obj = myPermission
            };
        }
        
        private async Task<User> AddNewUser(LoginInput input)
        {
            var newUser = new User
            {
                Username = input.Username,
                Email = input.Username,
                Description = string.Empty
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        private async Task<TokenDto> GenerateAccessToken(User dataUser)
        {
            var dataPermissions = await (from u in _dbContext.Users
                                         join uc in _dbContext.UserCompanies on u.Id equals uc.UserId
                                         join ur in _dbContext.UserCompanyRoles on uc.Id equals ur.UserCompanyId
                                         join r in _dbContext.Roles on ur.RoleId equals r.Id
                                         join rp in _dbContext.RolePermissions on r.Id equals rp.RoleId
                                         join p in _dbContext.Permissions on rp.PermissionId equals p.Id
                                         where u.Username.Equals(dataUser.Username)
                                         select p.PermissionCode).Distinct().ToListAsync();

            return await _tokenService.GenerateToken(dataUser.Username, dataUser.Id, dataUser.FullName, dataPermissions);
        }
    }
}
