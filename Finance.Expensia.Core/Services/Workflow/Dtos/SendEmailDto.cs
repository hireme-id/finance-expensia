namespace Finance.Expensia.Core.Services.Workflow.Dtos
{
	public class SendEmailDto
	{
		public Guid DocumentId { get; set; }
		public string TransactionNo { get; set; } = string.Empty;
		public string ExecutorName { get; set; } = string.Empty;
		public string RoleCodeReceiver { get; set; } = string.Empty;
		public string Remark { get; set; } = string.Empty;
		public DateTime? ScheduleDate { get; set; }
	}
}
