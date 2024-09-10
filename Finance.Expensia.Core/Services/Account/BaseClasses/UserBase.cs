using Finance.Expensia.Core.Services.Account.Dtos;
using Finance.Expensia.Core.Services.MasterData.Dtos;

namespace Finance.Expensia.Core.Services.Account.BaseClasses
{
    public class UserBase
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhotoProfileUrl { get; set; } = string.Empty;
        public virtual List<UserCompanyBase> UserCompanies { get; set; } = [];
    }

    public class UserCompanyBase
    {
        public Guid? UserCompanyId { get; set; }
        public bool AllowApproval { get; set; }
        public CompanyDto Company { get; set; } = null!;
        public virtual List<UserCompanyRoleBase> UserCompanyRoles { get; set; } = [];
    }

    public class UserCompanyRoleBase
    {
        public Guid? UserCompanyRoleId { get; set; }
        public RoleDto Role { get; set; } = null!;
    }
}
