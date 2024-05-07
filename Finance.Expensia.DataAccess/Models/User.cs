using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class User : EntityBase
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public Guid? ResetToken { get; set; }
        public DateTime? ResetTokenExpiration { get; set; }
        public string Description { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhotoProfileUrl { get; set; } = string.Empty;

        public virtual List<UserRole> UserRoles { get; set; } = [];
    }
}
