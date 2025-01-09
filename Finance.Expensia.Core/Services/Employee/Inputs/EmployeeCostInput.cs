using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.Core.Services.Employee.Inputs
{
	public class EmployeeCostInput
	{
		public Guid? EmployeeCostId { get; set; }
		public Guid CompanyId { get; set; }
		public Guid CostCenterId { get; set; }
		public DateTime OfferingDate { get; set; }
		public Guid? EmployeeId { get; set; }
		public string EmployeeNo { get; set; } = string.Empty;
		public string EmployeeName { get; set; } = string.Empty;
		public string JobPosition { get; set; } = string.Empty;
		public EmployeeStatus EmployeeStatus { get; set; }
		public DateTime JoinDate { get; set; }
		public DateTime EndDate { get; set; }
		public NonTaxableIncome NonTaxableIncome { get; set; }
		public int WorkingDay { get; set; }
		public LaptopOwnership LaptopOwnership { get; set; }
		public string Remark { get; set; } = string.Empty;

		public List<EmployeeCostComponentInput> EmployeeCostComponents { get; set; } = [];
	}
}
