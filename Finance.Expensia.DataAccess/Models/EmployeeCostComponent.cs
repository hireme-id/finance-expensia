using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
    public class EmployeeCostComponent : EntityBase
    {
        public Guid EmployeeCostId { get; set; }
        public Guid CostComponentId { get; set; }
        public int CostComponentNo { get; set; }
        public string CostComponentName { get; set; } = string.Empty;
        public CostComponentType CostComponentType { get; set; }
        public CostComponentCategory CostComponentCategory { get; set; }
        public string Remark { get; set; } = string.Empty;
        public bool IsCalculated { get; set; }
        public string CalculateFormula { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public int CostComponentAmount { get; set; }
		public int CostComponentTotalAmount { get; set; }

		public virtual EmployeeCost EmployeeCost { get; set; } = null!;
        public virtual CostComponent CostComponent { get; set; } = null!;
    }
}
