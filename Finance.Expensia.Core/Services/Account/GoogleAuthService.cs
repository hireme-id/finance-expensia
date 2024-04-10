using AutoMapper;
using Finance.Expensia.Core.Services.Account.CustomModels;
using Finance.Expensia.Core.Services.Account.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace Finance.Expensia.Core.Services.Account
{
    public class GoogleAuthService(ApplicationDbContext dbContext, IMapper mapper, ILogger<GoogleAuthService> logger, IOptions<GoogleConfig> googleConfig, IHttpClientFactory httpClientFactory)
        : BaseService<GoogleAuthService>(dbContext, mapper, logger)
    {
        private readonly GoogleConfig _googleConfig = googleConfig.Value;
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

        public ResponseObject<string> GetAuthUrl(string host)
        {
            var authUrl = $"https://accounts.google.com/o/oauth2/auth?client_id={_googleConfig.OAuthGoogle.ClientId}&redirect_uri={host}&response_type=code&scope=email%20profile";

            return new ResponseObject<string> { Obj = authUrl } ;
        }

        public async Task<ResponseObject<LoginInput>> GetUserProfile(string host, string authCode)
        {
            var googleUserAccessToken = await GetUserAccessToken(host, authCode);
            
            if (googleUserAccessToken == null)
                return new ResponseObject<LoginInput>("Gagal mendapatkan user access token", ResponseCode.Error);

            var googleUserProfile = await GetUserProfile(googleUserAccessToken.AccessToken);

            if (googleUserProfile == null || googleUserProfile.GoogleUserProfileEmailAddresses.Count == 0 || googleUserProfile.GoogleUserProfileNames.Count == 0)
                return new ResponseObject<LoginInput>("Gagal mendapatkan user profile", ResponseCode.Error);

            return new ResponseObject<LoginInput>(responseCode: ResponseCode.Ok)
            {
                Obj = new LoginInput
                {
                    Username = googleUserProfile.GoogleUserProfileEmailAddresses[0].Value,
                    FullName = googleUserProfile.GoogleUserProfileNames[0].DisplayName,
                    PhotoUrl = googleUserProfile.GoogleUserProfilePhotos.Count > 0 ? googleUserProfile.GoogleUserProfilePhotos[0].Url : string.Empty
                }
            };
        }

        #region Private Methods
        private async Task<GoogleUserAccessToken?> GetUserAccessToken(string host, string authCode)
        {
            var requestBody = new
            {
                code = authCode,
                client_id = _googleConfig.OAuthGoogle.ClientId,
                client_secret = _googleConfig.OAuthGoogle.ClientSecret,
                redirect_uri = host,
                grant_type = "authorization_code"
            };

            var requestBodyMinify = JsonHelper.SerializeObject(requestBody);

            var request = new HttpRequestMessage(HttpMethod.Post, _googleConfig.OAuthGoogle.TokenUrl)
            {
                Content = new StringContent(requestBodyMinify, Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return default;
            
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonHelper.DeserializeObject<GoogleUserAccessToken>(responseBody);
        }

        private async Task<GoogleUserProfile?> GetUserProfile(string userAccessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_googleConfig.UserProfileUrl}?personFields=names%2CemailAddresses%2Cphotos")
            {
                Headers =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", userAccessToken)
                }
            };

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return default;

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonHelper.DeserializeObject<GoogleUserProfile>(responseBody);
        }
        #endregion
    }
}
