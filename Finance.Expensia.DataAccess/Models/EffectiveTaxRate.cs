using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
	public class EffectiveTaxRate : EntityBase
	{
        public EffectiveTaxCategory EffectiveTaxCategory { get; set; }
        public int IncomeLowerLimit { get; set; }
        public int? IncomeUpperLimit { get; set; }
        public decimal TaxRate { get; set; }
    }
}
