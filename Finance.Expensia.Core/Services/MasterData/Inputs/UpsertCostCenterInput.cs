namespace Finance.Expensia.Core.Services.MasterData.Inputs
{
    public class UpsertCostCenterInput
    {
        public Guid? Id { get; set; }
        public Guid CompanyId { get; set; }
        public string CostCenterCode { get; set; } = string.Empty;
        public string CostCenterName { get; set; } = string.Empty;
    }
}
