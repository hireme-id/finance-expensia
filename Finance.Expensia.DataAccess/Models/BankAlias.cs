using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class BankAlias : EntityBase
    {
        public Guid? CompanyId { get; set; }
        public string AliasName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public virtual Company? Company { get; set; }
    }
}
