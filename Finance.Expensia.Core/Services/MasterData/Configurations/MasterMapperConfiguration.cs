using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.MasterData.Configurations
{
    public class MasterMapperConfiguration : Profile
    {
        public MasterMapperConfiguration()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id));
            CreateMap<BankAlias, BankAliasDto>()
                .ForMember(dest => dest.BankAliasId, opt => opt.MapFrom(src => src.Id));
			CreateMap<Partner, PartnerDto>()
				.ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.Id));
			CreateMap<ChartOfAccount, CoaDto>()
				.ForMember(dest => dest.CoaId, opt => opt.MapFrom(src => src.Id));
			CreateMap<CostCenter, CostCenterDto>()
				.ForMember(dest => dest.CostCenterId, opt => opt.MapFrom(src => src.Id));
            CreateMap<TransactionType, TransactionTypeDto>()
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
