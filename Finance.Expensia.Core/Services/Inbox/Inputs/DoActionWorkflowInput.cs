using Finance.Expensia.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Finance.Expensia.Core.Services.Inbox.Inputs
{
    public class DoActionWorkflowInput
    {
        public string TransactionNo { get; set; } = string.Empty;
        public WorkflowAction WorkflowAction { get; set; }
        public string Remark { get; set; } = string.Empty;

        public ExpectedTransfer? ExpectedTransfer { get; set; }
		[DataType(DataType.Date)]
		public DateTime? ScheduledDate { get; set; }
		public Guid? FromBankAliasId { get; set; }
		public BankPaymentType? BankPaymentType { get; set; }
	}
}
