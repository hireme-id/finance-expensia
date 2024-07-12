namespace Finance.Expensia.Core.Services.Rule.Dtos
{
    public class ApprovalRuleDto
    {
        public Guid ApprovalRuleId { get; set; }
        public string TransactionTypeCode { get; set; } = string.Empty;
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Level { get; set; }
        public string RoleCode { get; set; } = string.Empty;
    }
}
