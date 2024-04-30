using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public class TransactionType : EntityBase
    {
        public string TransactionTypeCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
