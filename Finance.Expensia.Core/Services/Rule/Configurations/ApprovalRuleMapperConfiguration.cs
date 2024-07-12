using AutoMapper;
using Finance.Expensia.Core.Services.Rule.Dtos;
using Finance.Expensia.Core.Services.Rule.Inputs;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.Rule.Configurations
{
    public class ApprovalRuleMapperConfiguration : Profile
    {
        public ApprovalRuleMapperConfiguration()
        {
            CreateMap<ApprovalRule, ApprovalRuleDto>()
                .ForMember(dest => dest.ApprovalRuleId, opt => opt.MapFrom(src => src.Id));

            CreateMap<UpsertApprovalRuleInput, ApprovalRule>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
