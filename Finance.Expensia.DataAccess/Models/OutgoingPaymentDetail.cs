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
        public Guid ChartOfAccountid { get; set; }
        public string ChartOfAccountNo { get; set; } = string.Empty;
        public Guid CostCenterId { get; set; }
        public string CostCenterName { get; set;} = string.Empty;
        public decimal Amount { get; set; }

        public virtual OutgoingPayment OutgoingPayment { get; set; } = null!;
        public virtual List<OutgoingPaymentDetailAttachment>? OutgointPaymentDetailAttachments { get; set; }
    }
}
