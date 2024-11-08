using System.ComponentModel;

namespace Finance.Expensia.Shared.Enums
{
    public enum CostComponentCategory
    {
        [Description("Benefit Bulanan - Earning")]
        MonthlyEarningBenefit,
        [Description("Benefit Bulanan - Deduction")]
        MonthlyDeductionBenefit,
        [Description("Benefit Tahunan")]
        YearlyBenefit,
        [Description("Benefit Lain")]
        OtherBenefit,
        [Description("Pembayaran Goverment")]
        GovernmentDeduction,
        [Description("Total")]
        Total
    }
}
