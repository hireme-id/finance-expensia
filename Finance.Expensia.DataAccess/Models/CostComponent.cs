using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
	public class CostComponent : EntityBase
	{
        /// <summary>
        /// Sebagai unique key serta informasi pengurutan penampilan
        /// </summary>
        public int CostComponentNo { get; set; }
        public string CostComponentName { get; set; } = string.Empty;
        public CostComponentType CostComponentType { get; set; }
        public CostComponentCategory CostComponentCategory { get; set; }
        public string Remark { get; set; } = string.Empty;
        public bool IsCalculated { get; set; }
        public string CalculateFormula
        {
            get => _calculateFormula;
            set => _calculateFormula = IsCalculated ? value : string.Empty;
        }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }

        public virtual List<CostComponentCompany> CostComponentCompanies { get; set; } = [];

        private string _calculateFormula = string.Empty;
    }
}
