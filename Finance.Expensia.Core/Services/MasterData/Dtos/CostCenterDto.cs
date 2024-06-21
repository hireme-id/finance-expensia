namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class CostCenterDto
	{
        public Guid CostCenterId { get; set; }
		public string CostCenterCode { get; set; } = string.Empty;
		public string CostCenterName { get; set; } = string.Empty;
		public Guid CompanyId { get; set; }
		public string CompanyName { get; set;} = string.Empty;
	}
}
