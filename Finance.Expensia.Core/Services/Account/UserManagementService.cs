using AutoMapper;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.Account
{
    public class UserManagementService(ApplicationDbContext dbContext, IMapper mapper, ILogger<UserManagementService> logger)
        : BaseService<UserManagementService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<RoleDto>>> RetrieveRole(CurrentUserAccessor currentUserAccessor)
        {
            var dataRoles = await _dbContext.UserCompanyRoles
                                            .Include(ucr => ucr.Role)
                                            .Include(ucr => ucr.UserCompany)
                                            .Where(d => d.UserCompany.UserId == currentUserAccessor.Id)
                                            .Select(d => _mapper.Map<RoleDto>(d.Role))
                                            .Distinct()
                                            .ToListAsync();

            return new ResponseObject<List<RoleDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataRoles
            };
        }
    }
}
