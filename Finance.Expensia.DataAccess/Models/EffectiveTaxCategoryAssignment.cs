using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
	public class EffectiveTaxCategoryAssignment : EntityBase
	{
        public NonTaxableIncome NonTaxableIncome { get; set; }
        public EffectiveTaxCategory EffectiveTaxCategory { get; set; }
    }
}
