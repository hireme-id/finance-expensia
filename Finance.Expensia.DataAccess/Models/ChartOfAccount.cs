using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class ChartOfAccount : EntityBase
    {
        public Guid CompanyId { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
