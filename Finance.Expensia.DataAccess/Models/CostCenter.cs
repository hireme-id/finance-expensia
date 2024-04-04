using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class CostCenter : EntityBase
    {
        public string CostCenterCode { get; set; } = string.Empty;
        public string CostCenterName { get; set; } = string.Empty;
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
