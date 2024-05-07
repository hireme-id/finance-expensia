namespace Finance.Expensia.Core.Services.MasterData.Inputs
{
    public class UpsertBankAliasInput
    {
        public Guid? Id { get; set; }
        public Guid? CompanyId { get; set; }
        public string AliasName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
