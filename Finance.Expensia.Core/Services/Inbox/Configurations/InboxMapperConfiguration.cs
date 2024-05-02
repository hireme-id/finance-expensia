using AutoMapper;
using Finance.Expensia.Core.Services.Inbox.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Helpers;

namespace Finance.Expensia.Core.Services.Inbox.Configurations
{
    public class InboxMapperConfiguration : Profile
    {
        public InboxMapperConfiguration()
        {
            #region query
            CreateMap<ApprovalHistory, ListApprovalHistoryDto>()
                .ForMember(dest => dest.ApprovalStatusText, src => src.MapFrom(opt => opt.ApprovalStatus.GetDescription()));
            #endregion

            #region mutation

            #endregion
        }
    }
}
