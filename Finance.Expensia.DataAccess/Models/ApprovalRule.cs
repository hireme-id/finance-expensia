using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public class ApprovalRule : EntityBase
    {
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Level { get; set; }
        public string RoleCode { get; set; } = string.Empty;
    }
}
