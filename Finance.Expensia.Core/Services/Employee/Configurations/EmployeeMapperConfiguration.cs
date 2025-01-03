using AutoMapper;
using Finance.Expensia.Core.Services.Employee.Dtos;
using Finance.Expensia.Core.Services.Employee.Inputs;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.MasterData.Configurations
{
    public class EmployeeMapperConfiguration : Profile
    {
        public EmployeeMapperConfiguration()
        {
            #region Transform Entity into Dto
            CreateMap<DataAccess.Models.Employee, EmployeeDto>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id));

            CreateMap<EmployeeCost, EmployeeCostDto>()
                .ForMember(dest => dest.EmployeeCostId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CostComponent, EmployeeCostComponentDto>()
                .ForMember(dest => dest.CostComponentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeCostComponentId, opt => opt.Ignore())
                .ForMember(dest => dest.CostComponentAmount, opt => opt.Ignore());

			CreateMap<EmployeeCostComponent, EmployeeCostComponentDto>();
			#endregion

			#region Transform Input into Entity
			CreateMap<EmployeeInput, DataAccess.Models.Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<EmployeeCostInput, EmployeeCost>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeCostComponents, opt => opt.Ignore());
            #endregion

            #region Transform Dto into Entity
            CreateMap<EmployeeCostComponentDto, EmployeeCostComponent>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            #endregion
        }
	}
}
