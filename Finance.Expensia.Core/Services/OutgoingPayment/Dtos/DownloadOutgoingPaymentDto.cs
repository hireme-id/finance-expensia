using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Dtos
{
	public class DownloadOutgoingPaymentDto
	{
		public Guid OutgoingPaymentId { get; set; }
		public string TransactionNo { get; set; } = string.Empty;
		public DateTime RequestDate { get; set; }
		public string Requestor { get; set; } = string.Empty;
		public string CompanyName { get; set; } = string.Empty;
		public decimal TotalAmount { get; set; }
		public string Remark { get; set; } = string.Empty;
		public string FromBankAliasName { get; set; } = string.Empty;
		public string FromBankName { get; set; } = string.Empty;
		public string ToBankAliasName { get; set; } = string.Empty;
		public string ToBankName { get; set; } = string.Empty;
		public string BankPaymentType { get; set; } = string.Empty;
		public string ApprovalStatus { get; set; } = string.Empty;
		public string ExpectedTransfer { get; set; } = string.Empty;
		public DateTime? ScheduledDate { get; set; }
		public string CreatedBy { get; set; } = string.Empty;

		public List<DownloadOutgoingPaymentDetailDto> OutgoingPaymentDetails { get; set; } = [];
	}

	public class DownloadOutgoingPaymentDetailDto
	{
		public Guid Id { get; set; }
		public Guid OutgoingPaymentId { get; set; }
		public DateTime InvoiceDate { get; set; }
		public string PartnerName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ChartOfAccountNo { get; set; } = string.Empty;
		public string ChartOfAccountName { get; set; } = string.Empty;
		public string CostCenterCode { get; set; } = string.Empty;
		public string CostCenterName { get; set; } = string.Empty;
		public string PostingAccountName { get; set; } = string.Empty;
		public decimal Amount { get; set; }

	}

	public class GetDownloadOutgoingPaymentDto
	{
		public string TransactionNo { get; set; } = string.Empty;
        public string Requestor { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
		public string CompanyName { get; set; } = string.Empty;
        public string ApprovalStatus { get; set; } = string.Empty;
        public string ExpectedTransfer { get; set; } = string.Empty;
        public DateTime? ScheduledDate { get; set; }
        public string Remark { get; set; } = string.Empty;
		public string FromBankAliasName { get; set; } = string.Empty;
		public string ToBankAliasName { get; set; } = string.Empty;
		public string BankPaymentType { get; set; } = string.Empty;
		public DateTime? InvoiceDate { get; set; }
        public string Description { get; set; } = string.Empty;
		public string ChartOfAccountNo { get; set; } = string.Empty;
		public string ChartOfAccountName { get; set; } = string.Empty;
        public string PartnerName { get; set; } = string.Empty;
        public string CostCenterCode { get; set; } = string.Empty;
		public string CostCenterName { get; set; } = string.Empty;
		public string PostingAccountName { get; set; } = string.Empty;
		public decimal Amount { get; set; }
	}
}
