using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.DataAccess.Models
{
    public class OutgoingPayment : EntityBase
    {
        public string TransactionNo { get; set; } = string.Empty;
        public string Requestor { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set;} = string.Empty;
        public ApprovalStatus ApprovalStatus { get; set; }
        public ExpectedTransfer ExpectedTransfer { get; set; }
        public string Remark { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }
        public Guid FromBankAliasId { get; set; }
        public string FromBankAliasName { get; set; } = string.Empty;
        public string FromBankName { get; set; } = string.Empty;
        public string FromAccountNo { get; set; } = string.Empty;
        public string FromAccountName { get; set; } = string.Empty;
        public Guid ToBankAliasId { get; set; }
        public string ToBankAliasName { get; set; } = string.Empty;
		public string ToBankName { get; set; } = string.Empty;
		public string ToAccountNo { get; set; } = string.Empty;
		public string ToAccountName { get; set; } = string.Empty;
        public BankPaymentType BankPaymentType { get; set; }
        public Guid TransactionTypeId { get; set; }
        public string TransactionTypeCode { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

        public virtual List<OutgoingPaymentDetail> OutgoingPaymentDetails { get; set; } = [];
    }
}
