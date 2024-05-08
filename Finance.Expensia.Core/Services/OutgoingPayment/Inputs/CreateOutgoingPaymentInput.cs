using Finance.Expensia.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Inputs
{
	public class BaseOutgoingPaymentInput
	{
		public Guid CompanyId { get; set; }
		public ExpectedTransfer ExpectedTransfer { get; set; }
		public string Remark { get; set; } = string.Empty;
		[DataType(DataType.Date)]
		public DateTime? ScheduledDate { get; set; }
		public Guid FromBankAliasId { get; set; }
		public Guid ToBankAliasId { get; set; }
		public BankPaymentType BankPaymentType { get; set; }
		public Guid TransactionTypeId { get; set; }

		public bool IsSubmit { get; set; }
	}

	public class BaseOutgoingPaymentDetailInput
	{
		[DataType(DataType.Date)]
		public DateTime InvoiceDate { get; set; }
		public Guid PartnerId { get; set; }
		public string Description { get; set; } = string.Empty;
		public Guid? ChartOfAccountId { get; set; }
		public Guid CostCenterId { get; set; }
		public Guid PostingAccountId { get; set; }
		public decimal Amount { get; set; }
	}

	public class CreateOutgoingPaymentInput : BaseOutgoingPaymentInput
	{
		public List<CreateOutgoingPaymentDetailInput> OutgoingPaymentDetails { get; set; } = [];
	}

	public class CreateOutgoingPaymentDetailInput : BaseOutgoingPaymentDetailInput
	{
		public List<CreateOutgoingPaymentDetailAttachmentInput> OutgoingPaymentDetailAttachments { get; set; } = [];
	}

	public class CreateOutgoingPaymentDetailAttachmentInput
	{
		public Guid FileId { get; set; }
		public string FileName { get; set; } = string.Empty;
		public int FileSize { get; set; }
		public string FileUrl { get; set; } = string.Empty;
		public string ContentType { get; set; } = string.Empty;
	}
}
