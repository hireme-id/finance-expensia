namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class TransactionTypeDto
    {
        public Guid TransactionTypeId { get; set; }
        public string TransactionTypeCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
