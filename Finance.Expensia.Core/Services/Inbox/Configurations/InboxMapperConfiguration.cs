using AutoMapper;
using Finance.Expensia.Core.Services.Inbox.Dtos;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.Inbox.Configurations
{
    public class InboxMapperConfiguration : Profile
    {
        public InboxMapperConfiguration()
        {
            CreateMap<ApprovalHistory, ListApprovalHistoryDto>();
        }
    }
}
