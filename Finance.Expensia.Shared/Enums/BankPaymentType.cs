using System.ComponentModel;

namespace Finance.Expensia.Shared.Enums
{
	public enum BankPaymentType
    {
        [Description("Manual Transfer")]
        ManualTransfer,
        [Description("MAT Payroll")]
        MATPayroll,
        Pembayaran
    }
}
