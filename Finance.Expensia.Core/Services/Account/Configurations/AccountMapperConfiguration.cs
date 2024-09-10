using AutoMapper;
using Finance.Expensia.Core.Services.Account.BaseClasses;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.Account.Configurations
{
    public class AccountMapperConfiguration : Profile
    {
        public AccountMapperConfiguration()
        {
            CreateMap<UserCompany, UserCompanyBase>()
                .ForMember(dest => dest.UserCompanyId, opt => opt.MapFrom(src => src.Id));
            CreateMap<UserCompanyRole, UserCompanyRoleBase>()
                .ForMember(dest => dest.UserCompanyRoleId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));
            CreateMap<User, ListUserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UserCompanyRoleBase, UserCompanyRole>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.RoleId))
                .ForMember(dest => dest.UserCompany, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore());
        }
    }
}
