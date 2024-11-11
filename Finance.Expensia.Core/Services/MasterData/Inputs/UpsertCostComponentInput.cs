using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;

namespace Finance.Expensia.Core.Services.MasterData.Inputs
{
    public class UpsertCostComponentInput
    {
        private string _calculateFormula = string.Empty;

        public Guid? CostComponentId { get; set; }
        public int CostComponentNo { get; set; }
        public string CostComponentName { get; set; } = string.Empty;
        public CostComponentType CostComponentType { get; set; }
        public CostComponentCategory CostComponentCategory { get; set; }
        public string Remark { get; set; } = string.Empty;
        public bool IsCalculated { get; set; }
        public string CalculateFormula
        {
            get => _calculateFormula;
            set => _calculateFormula = IsCalculated ? value : string.Empty;
        }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }

        public List<UpsertCostComponentCompanyInput> CostComponentCompanies { get; set; } = [];
    }

    public class UpsertCostComponentCompanyInput
    {
        public Guid? CostComponentCompanyId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid ChartOfAccountId { get; set; }
    }
}
