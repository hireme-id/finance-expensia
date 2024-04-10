using Newtonsoft.Json;

namespace Finance.Expensia.Core.Services.Account.CustomModels
{
    public class GoogleUserProfile
    {
        [JsonProperty("resourceName")]
        public string ResourceName { get; set; } = string.Empty;

        [JsonProperty("etag")]
        public string ETag { get; set; } = string.Empty;

        [JsonProperty("names")]
        public List<GoogleUserProfileName> GoogleUserProfileNames { get; set; } = [];

        [JsonProperty("photos")]
        public List<GoogleUserProfilePhoto> GoogleUserProfilePhotos { get; set; } = [];

        [JsonProperty("emailAddresses")]
        public List<GoogleUserProfileEmailAddress> GoogleUserProfileEmailAddresses { get; set; } = [];
    }

    public class GoogleUserProfileName
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; } = string.Empty;
    }

    public class GoogleUserProfilePhoto
    {
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("default")]
        public bool Default { get; set; }
    }

    public class GoogleUserProfileEmailAddress
    {
        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;
    }
}
