using Finance.Expensia.Shared.Objects.Inputs;
using Newtonsoft.Json;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Inputs
{
    public class ListOutgoingPaymentFilterInput : PagingSearchInputBase
    {
        public Guid CompanyId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
    }
}
