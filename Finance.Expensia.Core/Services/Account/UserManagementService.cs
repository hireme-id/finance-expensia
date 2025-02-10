using AutoMapper;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.Core.Services.Account.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.Account
{
    public class UserManagementService(ApplicationDbContext dbContext, IMapper mapper, ILogger<UserManagementService> logger)
        : BaseService<UserManagementService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<RoleDto>>> GetListRole()
        {
            var dataRoles = await _dbContext.Roles
                                            .Select(d => _mapper.Map<RoleDto>(d))
                                            .Distinct()
                                            .ToListAsync();

            return new ResponseObject<List<RoleDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataRoles
            };
        }

        public async Task<ResponseObject<List<RoleDto>>> RetrieveRoleByUserId(CurrentUserAccessor currentUserAccessor)
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

        public async Task<ResponseObject<List<UserDto>>> RetrieveUsers()
        {
            var dataUsers = await _dbContext.Users
                                            .OrderBy(d => d.FullName)
                                            .Select(d => _mapper.Map<UserDto>(d))
                                            .ToListAsync();

            return new(responseCode: ResponseCode.Ok)
            {
                Obj = dataUsers
            };
        }

        public async Task<ResponsePaging<ListUserDto>> GetListUser(PagingSearchInputBase input)
        {
            var retVal = new ResponsePaging<ListUserDto>();
            var dataUsers = _dbContext.Users
                                      .OrderBy(d => d.FullName)
                                      .Where(d =>
                                        EF.Functions.Like(d.Username, $"%{input.SearchKey}%")
                                        || EF.Functions.Like(d.FullName, $"%{input.SearchKey}%")
                                        || EF.Functions.Like(d.Email, $"%{input.SearchKey}%"))
                                      .Select(d => _mapper.Map<ListUserDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, dataUsers);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponseObject<UserDto>> GetDetailUser(Guid userId)
        {
            var dataUser = await _dbContext.Users
                                           .Include(u => u.UserCompanies)
                                            .ThenInclude(u => u.Company)
                                           .Include(u => u.UserCompanies)
                                            .ThenInclude(uc => uc.UserCompanyRoles)
                                                .ThenInclude(ucr => ucr.Role)
                                           .FirstOrDefaultAsync(d => d.Id.Equals(userId));

            if (dataUser == null)
                return new ResponseObject<UserDto>("Data user tidak ditemukan", ResponseCode.NotFound);

            var retValData = _mapper.Map<UserDto>(dataUser);

            return new ResponseObject<UserDto>(responseCode: ResponseCode.Ok)
            {
                Obj = retValData
            };
        }

        public async Task<ResponseBase> UpdateUser(UserInput input)
        {
            var dataUser = await _dbContext.Users
                                           .Include(u => u.UserCompanies)
                                            .ThenInclude(u => u.Company)
                                           .Include(u => u.UserCompanies)
                                            .ThenInclude(uc => uc.UserCompanyRoles)
                                                .ThenInclude(ucr => ucr.Role)
                                           .FirstOrDefaultAsync(d => d.Id.Equals(input.UserId));

            if (dataUser == null)
                return new ResponseObject<UserDto>("Data user tidak ditemukan", ResponseCode.NotFound);

            #region Edit Data User
            dataUser.Email = input.Email;
            dataUser.FullName = input.FullName;
            dataUser.PhotoProfileUrl = input.PhotoProfileUrl;
            #endregion

            #region Edit Data User Company
            //delete user company
            var deleteUserCompanies = (from d in dataUser.UserCompanies
                                       join i in input.UserCompanies on d.Id equals i.UserCompanyId into ii
                                       from leftI in ii.DefaultIfEmpty()
                                       where leftI == null
                                       select d);
            if (deleteUserCompanies.Any())
            {
                foreach (var deleteUserCompany in deleteUserCompanies)
                {
                    deleteUserCompany.RowStatus = 1;
                    foreach (var userCompanyRole in deleteUserCompany.UserCompanyRoles)
                    {
                        userCompanyRole.RowStatus = 1;
                    }

                    _dbContext.Update(deleteUserCompany);
                }
            }

            //edit user company
            var editUserCompanies = (from d in dataUser.UserCompanies
                                     join i in input.UserCompanies on d.Id equals i.UserCompanyId
                                     select new { d, i });
            if (editUserCompanies.Any())
            {
                foreach (var editUserCompany in editUserCompanies)
                {
                    editUserCompany.d.AllowApproval = editUserCompany.i.AllowApproval;

                    //delete user company role
                    var deleteUserCompanyRoles = (from d in editUserCompany.d.UserCompanyRoles
                                                  join i in editUserCompany.i.UserCompanyRoles on d.Id equals i.UserCompanyRoleId into ii
                                                  from leftI in ii.DefaultIfEmpty()
                                                  where leftI == null
                                                  select d);
                    if (deleteUserCompanyRoles.Any())
                    {
                        foreach (var deleteUserCompanyRole in deleteUserCompanyRoles)
                        {
                            deleteUserCompanyRole.RowStatus = 1;
                            _dbContext.Update(deleteUserCompanyRole);
                        }
                    }

                    _dbContext.Update(editUserCompany.d);

                    //add user company role
                    var addUserCompanyRoles = (from i in editUserCompany.i.UserCompanyRoles
                                               join d in editUserCompany.d.UserCompanyRoles on i.UserCompanyRoleId equals d.Id into dd
                                               from leftD in dd.DefaultIfEmpty()
                                               where leftD == null
                                               select i);
                    if (addUserCompanyRoles.Any())
                    {
                        foreach (var addUserCompanyRole in addUserCompanyRoles)
                        {
                            await _dbContext.AddAsync(new UserCompanyRole
                            {
                                UserCompanyId = editUserCompany.d.Id,
                                RoleId = addUserCompanyRole.Role.RoleId
                            });
                        }
                    }
                }
            }

            //add user company
            var addUserCompanies = (from i in input.UserCompanies
                                    join d in dataUser.UserCompanies on i.UserCompanyId equals d.Id into dd
                                    from leftD in dd.DefaultIfEmpty()
                                    where leftD == null
                                    select i);
            if (addUserCompanies.Any())
            {
                foreach (var addUserCompany in addUserCompanies)
                {
                    await _dbContext.AddAsync(new UserCompany
                    {
                        UserId = input.UserId,
                        CompanyId = addUserCompany.Company.CompanyId,
                        AllowApproval = addUserCompany.AllowApproval,
                        UserCompanyRoles = addUserCompany.UserCompanyRoles.Select(_mapper.Map<UserCompanyRole>).ToList()
                    });
                }
            }
            #endregion

            _dbContext.Update(dataUser);
            await _dbContext.SaveChangesAsync();

            return new ResponseBase("Perubahan user berhasil dilakukan", ResponseCode.Ok);
        }
    }
}
