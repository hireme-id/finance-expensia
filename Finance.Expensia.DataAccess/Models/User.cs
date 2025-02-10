using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class User : EntityBase
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid? ResetToken { get; set; }
        public DateTime? ResetTokenExpiration { get; set; }
        public string Description { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhotoProfileUrl { get; set; } = string.Empty;

        public virtual List<UserCompany> UserCompanies { get; set; } = [];
        public virtual Recruiter? Recruiter { get; set; }
    }
}
