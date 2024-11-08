using System.ComponentModel;

namespace Finance.Expensia.Shared.Enums
{
    public enum CostComponentType
    {
        [Description("Harian")]
        Daily,
        [Description("Bulanan")]
        Monthly,
        [Description("Tahunan")]
        Yearly,
        SubTotal,
        Total
    }
}
