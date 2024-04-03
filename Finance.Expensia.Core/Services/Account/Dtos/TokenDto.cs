namespace Finance.Expensia.Core.Services.Account.Dtos
{
    public class TokenDto
    {
        public Guid UserId { get; set; }
        public required string AccessToken { get; set; }
        public DateTime ExpiredAt { get; set; }
        public required string RefreshToken { get; set; }
        public DateTime SessionExpiredAt { get; set; }
    }
}
