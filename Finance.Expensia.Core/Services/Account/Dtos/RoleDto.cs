namespace Finance.Expensia.Core.Services.Account.Dtos
{
    public class RoleDto
    {
        public Guid RoleId { get; set; }
        public string RoleCode { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
    }
}
