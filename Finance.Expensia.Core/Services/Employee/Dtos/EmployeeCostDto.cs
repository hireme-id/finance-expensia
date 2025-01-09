using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Finance.Expensia.Core.Services.Employee.Dtos
{
	public class EmployeeCostDto
    {
        public Guid EmployeeCostId { get; set; }
        [DataType(DataType.Date)]
        public DateTime OfferingDate { get; set; }
        public string JobPosition { get; set; } = string.Empty;
        public EmployeeStatus EmployeeStatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public NonTaxableIncome NonTaxableIncome { get; set; }
        public string NonTaxableIncomeDescription => NonTaxableIncome.GetDescription();
        public EffectiveTaxCategory EffectiveTaxCategory { get; set; }
        public string EffectiveTaxCategoryDescription => EffectiveTaxCategory.GetDescription();
        public int WorkingDay { get; set; }
        public LaptopOwnership LaptopOwnership { get; set; }
        public string Remark { get; set; } = string.Empty;

        public CompanyDto Company { get; set; } = null!;
        public CostCenterDto CostCenter { get; set; } = null!;
        public EmployeeDto Employee { get; set; } = null!;

        public List<EmployeeCostComponentDto> EmployeeCostComponents { get; set; } = [];
    }

    public class EmployeeCostComponentDto
    {
		public Guid? EmployeeCostComponentId { get; set; }
		public Guid CostComponentId { get; set; }
		public int CostComponentNo { get; set; }
		public string CostComponentName { get; set; } = string.Empty;
		public CostComponentType CostComponentType { get; set; }
        public string CostComponentTypeDescription => CostComponentType.GetDescription();
		public CostComponentCategory CostComponentCategory { get; set; }
		public string CostComponentCategoryDescription => CostComponentCategory.GetDescription();
		public string Remark { get; set; } = string.Empty;
		public bool IsCalculated { get; set; }
		public string CalculateFormula { get; set; } = string.Empty;
		public bool IsVisible { get; set; }
		public int CostComponentAmount { get; set; }
		public int CostComponentTotalAmount { get; set; }
	}
}
