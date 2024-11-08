using Finance.Expensia.Shared.Enums;
using Newtonsoft.Json;

namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class EffectiveTaxDto
    {
        public List<NonTaxableIncome> NonTaxableIncomes { get; set; } = [];
        public List<EffectiveTaxRateDto> EffectiveTaxRates { get; set; } = [];
	}

    public class EffectiveTaxRateDto
    {
        public Guid EffectiveTaxRateId { get; set; }
        public int IncomeLowerLimit { get; set; }
        public int? IncomeUpperLimit { get; set; }
        [JsonIgnore]
        public decimal TaxRate { get; set; }
        public decimal TaxRateInPercent => TaxRate * 100;
    }
}
