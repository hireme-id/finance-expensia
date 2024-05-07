namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class CompanyDto
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
