using System.ComponentModel;

namespace Finance.Expensia.Shared.Enums
{
	public enum EmployeeStatus
    {
        [Description("Mitra")]
        Freelance,
        [Description("PKWT")]
        Contract,
        [Description("PKWTT")]
        Permanent
    }
}
