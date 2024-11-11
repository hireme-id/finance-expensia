using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.MasterData.Configurations
{
    public class MasterMapperConfiguration : Profile
    {
        public MasterMapperConfiguration()
        {
            #region Transform Entity into Dto
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id));

            CreateMap<BankAlias, BankAliasDto>()
                .ForMember(dest => dest.BankAliasId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.CompanyName : string.Empty));

            CreateMap<Partner, PartnerDto>()
                .ForMember(dest => dest.PartnerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ChartOfAccount, CoaDto>()
                .ForMember(dest => dest.CoaId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CostCenter, CostCenterDto>()
                .ForMember(dest => dest.CostCenterId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.CompanyName : string.Empty));

            CreateMap<TransactionType, TransactionTypeDto>()
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.Id));

            CreateMap<EffectiveTaxRate, EffectiveTaxRateDto>()
                .ForMember(dest => dest.EffectiveTaxRateId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CostComponent, CostComponentDto>()
                .ForMember(dest => dest.CostComponentId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CostComponentCompany, CostComponentCompanyDto>()
                .ForMember(dest => dest.CostComponentCompanyId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company == null ? string.Empty : src.Company.CompanyName));
            #endregion

            #region Transform Input into Entity
            CreateMap<UpsertPartnerInput, Partner>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpsertBankAliasInput, BankAlias>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpsertCostCenterInput, CostCenter>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpsertCoaInput, ChartOfAccount>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateEffectiveTaxRateInput, EffectiveTaxRate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpsertCostComponentInput, CostComponent>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CostComponentCompanies, opt => opt.Ignore());

            CreateMap<UpsertCostComponentCompanyInput, CostComponentCompany>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .AfterMap((src, dest, context) =>
                {
                    if (context.TryGetItems(out var items) && items.TryGetValue("IsCreate", out object? value) && (bool)value)
                    {
                        dest.CompanyId = src.CompanyId; // Saat create, tetap mapping CompanyId
                    }
                }); ;
            #endregion
        }
    }
}
