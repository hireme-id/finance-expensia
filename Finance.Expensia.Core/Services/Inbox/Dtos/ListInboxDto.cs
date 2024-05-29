using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.Core.Services.Inbox.Dtos
{
    public class ListInboxDto
    {
        public Guid OutgoingPaymentId { get; set; }
        public string TransactionTypeDescription { get; set; } = string.Empty;
        public string TransactionNo { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public string Requestor { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; } = string.Empty;
        public string BankPaymentType { get; set; } = string.Empty;
        public string FromBankAliasName { get; set; } = string.Empty;
        public string ToBankAliasName { get; set; } = string.Empty;
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}
