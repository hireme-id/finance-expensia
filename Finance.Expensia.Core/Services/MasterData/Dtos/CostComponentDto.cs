using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;

namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class CostComponentDto
    {
        private string _calculateFormula = string.Empty;

        public Guid CostComponentId { get; set; }
        public int CostComponentNo { get; set; }
        public string CostComponentName { get; set; } = string.Empty;
        public CostComponentType CostComponentType { get; set; }
        public string CostComponentTypeDescription => CostComponentType.GetDescription();
        public CostComponentCategory CostComponentCategory { get; set; }
        public string CostComponentCategoryDescription => CostComponentCategory.GetDescription();
        public string Remark { get; set; } = string.Empty;
        public bool IsCalculated { get; set; }
        public string CalculateFormula
        {
            get => _calculateFormula;
            set => _calculateFormula = IsCalculated ? value : string.Empty;
        }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }

        public List<CostComponentCompanyDto> CostComponentCompanies { get; set; } = [];
    }

    public class CostComponentCompanyDto
    {
        public Guid CostComponentCompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public Guid CompanyId { get; set; }
        public Guid ChartOfAccountId { get; set; }
    }
}
