using AutoMapper;
using Finance.Expensia.Core.Services.Inbox.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.Inbox.Configurations
{
    public class InboxMapperConfiguration : Profile
    {
        public InboxMapperConfiguration()
        {
            #region query
            CreateMap<ApprovalHistory, ListApprovalHistoryDto>();
            #endregion

            #region mutation

            #endregion
        }
    }
}
