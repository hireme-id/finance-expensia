using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public class ApprovalRule : EntityBase
    {
        public string TransactionTypeCode { get; set; } = string.Empty;
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Level { get; set; }
        public string RoleCode { get; set; } = string.Empty;
    }
}
