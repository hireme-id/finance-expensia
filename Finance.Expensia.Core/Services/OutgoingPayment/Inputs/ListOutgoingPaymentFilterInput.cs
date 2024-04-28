using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Inputs;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Inputs
{
    public class ListOutgoingPaymentFilterInput : PagingSearchInputBase
    {
        public Guid? CompanyId { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
    }
}
