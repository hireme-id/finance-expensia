using Finance.Expensia.Shared.Objects.Inputs;

namespace Finance.Expensia.Core.Services.Inbox.Inputs
{
    public class ListInboxFilterInput : PagingSearchInputBase
    {
        public Guid? FromBankAliasId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
