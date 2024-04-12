using AutoMapper;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Core.Services.Account
{
    public class TokenService(ApplicationDbContext dbContext, IMapper mapper, ILogger<TokenService> logger, IOptions<SecurityConfig> securityOption)
        : BaseService<TokenService>(dbContext, mapper, logger)
    {
        private readonly SecurityConfig _securityConfig = securityOption.Value;

        public async Task<TokenDto> GenerateToken(string userName, Guid userId, string givenName, List<string> permissions)
        {
            var secretKey = Encoding.ASCII.GetBytes(_securityConfig.SecretKey);
            var accessTokenExpireAt = DateTime.Now.AddMinutes(_securityConfig.TokenExpired);
            var refreshTokenExpireAt = DateTime.Now.AddDays(_securityConfig.SessionExpired);

            var accessTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, userName),
                    new Claim(JwtRegisteredClaimNames.GivenName, givenName),
                    new Claim(JwtRegisteredClaimNames.Sid, userName)
                }),
                Expires = accessTokenExpireAt,
                Issuer = _securityConfig.Issuer,
                Audience = _securityConfig.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha512Signature),
                Claims = new Dictionary<string, object>
                {
                    { PermissionConstants.TypeCode, permissions }
                }
            };

            var refreshTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, userName),
                    new Claim(JwtRegisteredClaimNames.GivenName, givenName),
                    new Claim(JwtRegisteredClaimNames.Sid, userName)
                }),
                Expires = refreshTokenExpireAt,
                Issuer = _securityConfig.Issuer,
                Audience = _securityConfig.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha512Signature),
                Claims = new Dictionary<string, object>
                {
                    { PermissionConstants.TypeCode, new List<string> { PermissionConstants.RefreshToken } }
                }
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.CreateToken(accessTokenDescriptor);
            var refreshToken = tokenHandler.CreateToken(refreshTokenDescriptor);

            return await Task.FromResult(new TokenDto
            {
                AccessToken = tokenHandler.WriteToken(accessToken),
                ExpiredAt = accessTokenExpireAt,
                RefreshToken = tokenHandler.WriteToken(refreshToken),
                SessionExpiredAt = refreshTokenExpireAt
            });
        }

        public static string? GetUserIdFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenReadResult = tokenHandler.ReadJwtToken(jwtToken);
            var userId = tokenReadResult.Claims.FirstOrDefault(x => x.Type == "sid")?.Value;

            return userId;
        }
    }
}
