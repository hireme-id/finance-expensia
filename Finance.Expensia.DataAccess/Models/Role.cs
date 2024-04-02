using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class Role : EntityBase
    {
        public required string RoleCode { get; set; }
        public required string RoleDescription { get; set; }

        public virtual List<UserRole>? UserRoles { get; set; }
        public virtual List<RolePermission> RolePermissions { get; set; } = [];
    }
}
