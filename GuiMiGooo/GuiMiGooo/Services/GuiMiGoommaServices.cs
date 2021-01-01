using GuiMiGooo.Models;
using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace GuiMiGooo.Services
{
    public class GuiMiGoommaServices
    {

        private readonly ILogger<TokenService> _logger;
        private readonly IOptions<IdentityServerSettings> _identityServerSettings;
        private readonly DiscoveryDocumentResponse _discoveryDocument;

        public async Task<TokenResponse> GetToken(string scope = "scope1")
        {



            var client = new HttpClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = Settings.TokenEndpoint,

                ClientId = Settings.ClientId,
                ClientSecret = Settings.ClientSecret,
                Scope = scope
            });


            if (tokenResponse.IsError)
            {
                _logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse;
        }
        public async Task<HttpResponseMessage> GetToken()
        {
            using var client = new HttpClient();
            HttpContent MyContent = null;

            var values = new Dictionary<string, string>
            {
                {"client_id", "m2m2.client"},
                {"client_secret", "511536EF-F270-4058-80CA-1C89C192F69A"},
                {"grant_type","password"},
                {"scope", "scope1"},
                {"UserName", "sdss"},
                {"Password", "pipPssdsdo@12020"}
            };

            MyContent = new FormUrlEncodedContent(values);

            var tokenResponse = await client.PostAsync(Settings.TokenEndpoint, MyContent);


            if (!tokenResponse.IsSuccessStatusCode)
            {
                _logger.LogError($"Unable to get token. Error is: {tokenResponse.ReasonPhrase}");
                throw new Exception("Unable to get token", null);
            }

            return tokenResponse;
        }
        public async Task<bool> UserRegistration(string Username, string Password, string Email, List<CompagniesData> Operatori = null)
        {
            using var client = new HttpClient();

            var model = new NewGuiMiGommaUser()
            {
                UserEmail = Email,
                Password = Password,
                UserName = Username,
                CompagniesData = Operatori
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await client.PostAsync(new Uri(Settings.RegistrationEndpoint), content);

            return httpResponse.IsSuccessStatusCode;
        }
        public async Task<TokenResponse> GetAccessToken(string Username = "sdss", string Password = "pipPssdsdo@12020")
        {
            HttpClient client = new HttpClient();
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = Settings.TokenEndpoint,
                ClientId = Settings.ClientId,
                ClientSecret = Settings.ClientSecret,
                Scope = Settings.Scope,
                UserName = Username,
                Password = Password,

            });


            if (tokenResponse.IsError)
            {
                _logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse;
        }

        public async Task<UserInfoResponse> GetUserInfo(string Username = "sdss", string Password = "pipPssdsdo@12020")
        {

            using var client = new HttpClient();

            var tk = await GetAccessToken(Username, Password);

            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = Settings.UserinfoEndpoint,
                Token = tk.AccessToken

            });

            return response;
        }
    }
}
