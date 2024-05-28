using System.ComponentModel;

namespace Finance.Expensia.Shared.Enums
{
	public enum ApprovalStatus
    {
        Draft,
        [Description("Waiting Approval")]
        WaitingApproval,
        Approved,
        Reject,
        Submitted,
        Cancelled
    }
}
