namespace Finance.Expensia.Core.Services.Account.Dtos
{
    public class LoginDto : TokenDto
    {
        public string DisplayName { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
    }
}
