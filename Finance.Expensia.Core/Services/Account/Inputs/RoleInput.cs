using Finance.Expensia.Core.Services.Account.BaseClasses;

namespace Finance.Expensia.Core.Services.Account.Inputs
{
    public class RoleInput
    {
        public Guid? RoleId { get; set; }
        public string RoleCode { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
        public List<Guid> PermissionIds { get; set; } = [];
    }
}
