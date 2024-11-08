using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.Core.Services.MasterData.Inputs
{
    public class UpdateEffectiveTaxInput
    {
        public EffectiveTaxCategory EffectiveTaxCategory { get; set; }
        public List<NonTaxableIncome> NonTaxableIncomes { get; set; } = [];
        public List<UpdateEffectiveTaxRateInput> EffectiveTaxRates { get; set; } = [];
    }

    public class UpdateEffectiveTaxRateInput
    {
        public Guid? EffectiveTaxRateId { get; set; }
        public int IncomeLowerLimit { get; set; }
        public int? IncomeUpperLimit { get; set; }
        public decimal TaxRateInPercent { get; set; }
        public decimal TaxRate => TaxRateInPercent / 100;
    }
}
