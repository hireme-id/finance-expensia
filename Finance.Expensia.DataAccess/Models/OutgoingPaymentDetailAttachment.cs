using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public class OutgoingPaymentDetailAttachment : EntityBase
    {
        public Guid OutgoingPaymentDetailId { get; set; }
        public Guid FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;

        public virtual OutgoingPaymentDetail OutgoingPaymentDetail { get; set; } = null!;
    }
}
