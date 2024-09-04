using Finance.Expensia.Shared.Objects.Inputs;

namespace Finance.Expensia.Core.Services.Inbox.Inputs
{
    public class ListInboxFilterInput : PagingSearchInputBase
    {
        public Guid? RoleId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? TransactionTypeId { get; set; }
        public Guid? FromBankAliasId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
