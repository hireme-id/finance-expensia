namespace Finance.Expensia.Core.Services.MasterData.Inputs
{
    public class UpsertRecruiterInput
	{
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public string RecruiterCode { get; set; } = string.Empty;
    }
}
