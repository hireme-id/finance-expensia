using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.Core.Services.Inbox.Inputs
{
    public class DoActionWorkflowInput
    {
        public string TransactionNo { get; set; } = string.Empty;
        public WorkflowAction WorkflowAction { get; set; }
    }
}
