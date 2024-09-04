using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class UserCompanyRole : EntityBase
    {
        public Guid UserCompanyId { get; set; }
        public Guid RoleId { get; set; }

        public virtual UserCompany UserCompany { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
