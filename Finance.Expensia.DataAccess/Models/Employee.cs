using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public class Employee : EntityBase
    {
        public string EmployeeNo { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;

        public List<EmployeeCost> EmployeeCosts { get; set; } = [];
    }
}
