using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
	public partial class CostComponentCompany : EntityBase
	{
        public Guid CostComponentId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ChartOfAccountId { get; set; }

        public virtual CostComponent CostComponent { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
        public virtual ChartOfAccount ChartOfAccount { get; set; } = null!;
    }
}
