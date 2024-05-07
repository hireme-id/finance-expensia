namespace Finance.Expensia.Shared.Objects
{
    public class GoogleConfig
    {
        public OAuthGoogle OAuthGoogle { get; set; } = default!;
        public string UserProfileUrl { get; set; } = string.Empty;
    }

    public class OAuthGoogle
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string TokenUrl { get; set; } = string.Empty;
    }
}
