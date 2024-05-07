using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
    public class ApprovalHistory : EntityBase
    {
        public string TransactionNo { get; set; } = string.Empty;
        public ApprovalStatus ApprovalStatus { get; set; }
        public string ExecutorRoleCode { get; set; } = string.Empty;
        public string ExecutorRoleDesc { get; set; } = string.Empty;
        public Guid ApprovalUserId { get; set; }
        public string ExecutorName { get; set; } = string.Empty;
        public int ApprovalLevel { get; set; }
        public string Remark { get; set; } = string.Empty;
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
    }
}
