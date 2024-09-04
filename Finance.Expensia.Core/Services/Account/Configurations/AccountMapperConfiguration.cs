using AutoMapper;
using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.Account.Configurations
{
    public class AccountMapperConfiguration : Profile
    {
        public AccountMapperConfiguration()
        {
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
