using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.Core.Services.Employee.Inputs
{
	public class CalculateEmployeeCostInput
	{
		public EmployeeStatus EmployeeStatus { get; set; }
		public NonTaxableIncome NonTaxableIncome { get; set; }
		public LaptopOwnership LaptopOwnership { get; set; }
		public int WorkingDay { get; set; }
		public List<EmployeeCostComponentInput> EmployeeCostComponents { get; set; } = [];
	}

	public class EmployeeCostComponentInput
	{
		public Guid CostComponentId { get; set; }
		public int CostComponentAmount { get; set; }
	}
}
