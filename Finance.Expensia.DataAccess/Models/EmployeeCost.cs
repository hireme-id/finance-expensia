using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
    public class EmployeeCost : EntityBase
    {
        public Guid CompanyId { get; set; }
        public Guid CostCenterId { get; set; }
        public DateTime OfferingDate { get; set; }
        public Guid EmployeeId { get; set; }
        public string JobPosition { get; set; } = string.Empty;
        public EmployeeStatus EmployeeStatus { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public NonTaxableIncome NonTaxableIncome { get; set; }
        public EffectiveTaxCategory EffectiveTaxCategory { get; set; }
        public int WorkingDay { get; set; }
        public string Remark { get; set; } = string.Empty;

        public virtual Company Company { get; set; } = null!;
        public virtual CostCenter CostCenter { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual List<EmployeeCostComponent> EmployeeCostComponents { get; set; } = [];
    }
}
