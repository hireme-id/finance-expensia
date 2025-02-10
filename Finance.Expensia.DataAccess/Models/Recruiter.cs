using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
	public class Recruiter : EntityBase
	{
		public Guid UserId { get; set; }
		public string RecruiterCode { get; set; } = string.Empty;

		public virtual User User { get; set; } = null!;
	}
}
