namespace Finance.Expensia.Core.Services.MasterData.Inputs
{
    public class UpsertCoaInput
    {
        public Guid? Id { get; set; }
        public Guid CompanyId { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public bool IsCostCenterMandatory { get; set; }
    }
}
