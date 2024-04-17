using Finance.Expensia.Shared.Enums;
using Newtonsoft.Json;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Inputs
{
    public class EditOutgoingPaymentInput
    {
        public Guid Id { get; set; }
        [JsonProperty("companyId")]
        public Guid CompanyId { get; set; }
        public ExpectedTransfer ExpectedTransfer { get; set; }
        public string Remark { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }
        public Guid FromBankAliasId { get; set; }
        public Guid ToBankAliasId { get; set; }

        public bool IsSubmit { get; set; }

        public List<EditOutgoingPaymentDetailInput> OutgoingPaymentDetails { get; set; } = [];
    }

    public class EditOutgoingPaymentDetailInput
    {
        public Guid? Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid PartnerId { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid ChartOfAccountId { get; set; }
        public Guid CostCenterId { get; set; }
        public decimal Amount { get; set; }

        public List<EditOutgoingPaymentDetailAttachmentInput> OutgoingPaymentDetailAttachments { get; set; } = [];
    }

    public class EditOutgoingPaymentDetailAttachmentInput
    {
        public Guid? Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public int FileSize { get; set; }
        public string FileUrl { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}
