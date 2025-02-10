namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class RecruiterDto
	{
        public Guid RecruiterId { get; set; }
		public string RecruiterCode { get; set; } = string.Empty;
		public Guid UserId { get; set; }
		public string FullName { get; set; } = string.Empty;
	}
}
