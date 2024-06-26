﻿using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;

namespace Finance.Expensia.Core.Services.Inbox.Dtos
{
    public class ListApprovalHistoryDto
    {
        public Guid Id { get; set; }
        public string TransactionNo { get; set; } = string.Empty;
        public ApprovalStatus ApprovalStatus { get; set; }
        public string ExecutorRoleCode { get; set; } = string.Empty;
        public string ExecutorRoleDesc { get; set; } = string.Empty;
        public string ExecutorName { get; set; } = string.Empty;
        public int ApprovalLevel { get; set; }
        public string Remark { get; set; } = string.Empty;
        public string ApprovalStatusText => ApprovalStatus.GetDescription();
        public DateTime Created { get; set; }
	}
}
