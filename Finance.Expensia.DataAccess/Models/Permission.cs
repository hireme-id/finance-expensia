using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class Permission : EntityBase
    {
        public required string PermissionCode { get; set; }
        public required string PermissionDescription { get; set; }
    }
}
