using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class UserCompany : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public bool AllowApproval { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
        public virtual List<UserCompanyRole> UserRoles { get; set; } = [];
    }
}
