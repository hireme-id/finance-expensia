using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
	public class OutgoingPaymentDetail : EntityBase
	{
		public Guid OutgoingPaymentId { get; set; }
		public DateTime InvoiceDate { get; set; }
		public Guid PartnerId { get; set; }
		public string PartnerName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public Guid ChartOfAccountId { get; set; }
		public string ChartOfAccountNo { get; set; } = string.Empty;
		public string ChartOfAccountName { get; set; } = string.Empty;
		public Guid CostCenterId { get; set; }
		public string CostCenterCode { get; set; } = string.Empty;
		public string CostCenterName { get; set; } = string.Empty;
		public Guid PostingAccountId { get; set; }
		public string PostingAccountName { get; set; } = string.Empty;
		public decimal Amount { get; set; }

		public virtual OutgoingPayment OutgoingPayment { get; set; } = null!;
		public virtual List<OutgoingPaymentDetailAttachment> OutgoingPaymentDetailAttachments { get; set; } = [];
		public virtual Company PostingAccount { get; set; } = null!;
	}
}
