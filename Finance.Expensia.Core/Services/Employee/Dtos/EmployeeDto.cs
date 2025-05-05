namespace Finance.Expensia.Core.Services.Employee.Dtos
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeNo { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public List<EmployeeCostDto> EmployeeCosts { get; set; } = [];
    }
}
