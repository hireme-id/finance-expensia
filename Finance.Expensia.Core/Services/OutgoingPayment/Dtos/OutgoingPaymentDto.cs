using Finance.Expensia.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Dtos
{
    public class OutgoingPaymentDto
    {
        public Guid OutgoingPaymentId { get; set; }
        public string TransactionNo { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
        public string Requestor { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; } = string.Empty;
        public string FromBankAlias { get; set; } = string.Empty;
        public string ToBankAlias { get; set; } = string.Empty;
        public ApprovalStatus ApprovalStatus { get; set; }

        public List<OutgoingPaymentDetailDto> OutgoingPaymentDetails { get; set; } = [];
    }

    public class OutgoingPaymentDetailDto
    {
        public Guid Id { get; set; }
        public Guid OutgoingPaymentId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid PartnerId { get; set; }
        public string PartnerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ChartOfAccountId { get; set; }
        public string ChartOfAccountNo { get; set; } = string.Empty;
        public Guid CostCenterId { get; set; }
        public string CostCenterCode { get; set; } = string.Empty;
        public string CostCenterName { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public List<OutgoingPaymentDetailAttachmentDto> OutgoingPaymentDetailAttachments { get; set; } = [];
    }

    public class OutgoingPaymentDetailAttachmentDto
    {
        public Guid Id { get; set; }
        public Guid OutgoingPaymentDetailId { get; set; }
        public Guid FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}
