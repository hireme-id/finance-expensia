namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class PartnerDto
	{
        public Guid PartnerId { get; set; }
		public string PartnerName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public Guid CompanyId { get; set; }
	}
}
