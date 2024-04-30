using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public class DocNumberConfig : EntityBase
    {
        public string TransactionTypeCode { get; set; } = string.Empty;
        public string CompanyCode { get; set; } = string.Empty;
        public int Month { get; set; }
        public int Year { get; set; }
        public int RunningNumber { get; set; }
    }
}
