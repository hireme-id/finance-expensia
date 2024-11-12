using AutoMapper;
using Finance.Expensia.Core.Services.Employee.Dtos;

namespace Finance.Expensia.Core.Services.MasterData.Configurations
{
    public class EmployeeMapperConfiguration : Profile
    {
        public EmployeeMapperConfiguration()
        {
            #region Transform Entity into Dto
            CreateMap<DataAccess.Models.Employee, EmployeeDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id));
            #endregion

            #region Transform Input into Entity

            #endregion
        }
    }
}
