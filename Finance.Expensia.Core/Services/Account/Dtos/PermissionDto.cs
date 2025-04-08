namespace Finance.Expensia.Core.Services.Account.Dtos
{
    public class PermissionDto
    {
        public Guid PermissionId { get; set; }
        public string PermissionCode { get; set; } = string.Empty;
        public string PermissionDescription { get; set; } = string.Empty;
    }
}
