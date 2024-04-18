using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
    public class ApprovalInbox : EntityBase
    {
        public Guid ApprovalRuleId { get; set; }
        public string TransactionNo { get; set; } = string.Empty;
        public ApprovalStatus ApprovalStatus { get; set; }
        public string ApprovalRoleCode { get; set; } = string.Empty;
        public int ApprovalLevel { get; set; }
    }
}
