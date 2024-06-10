using System.ComponentModel;

namespace Finance.Expensia.Shared.Enums
{
	public enum ExpectedTransfer
	{
		[Description("Immediately")]
		Immediately,
		[Description("Approved + 1")]
		ApprovedPlusOne,
		[Description("Scheduled")]
		Scheduled
	}
}
