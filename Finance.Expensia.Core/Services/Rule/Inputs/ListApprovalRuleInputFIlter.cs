using Finance.Expensia.Shared.Objects.Inputs;

namespace Finance.Expensia.Core.Services.Rule.Inputs
{
    public class ListApprovalRuleInputFIlter : PagingSearchInputBase
    {
        public string TransactionTypeCode { get; set; } = string.Empty;
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
    }
}
