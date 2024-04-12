namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class BankAliasDto
    {
        public Guid BankAliasId { get; set; }
        public string AliasName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
