namespace Finance.Expensia.Core.Services.Account.Dtos
{
    public class MyPermissionDto
    {
        public string RoleCode { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = [];
    }
}
