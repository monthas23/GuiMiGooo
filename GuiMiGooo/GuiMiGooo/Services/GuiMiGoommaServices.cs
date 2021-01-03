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
using Xamarin.Essentials;

namespace GuiMiGooo.Services
{
    public class GuiMiGoommaServices
    {
        //public GuiMiGoommaServices(ILogger<TokenService> _logger)
        //{
        //    this.logger = _logger;
        //}


        private readonly ILogger<TokenService> logger;
        private readonly IOptions<IdentityServerSettings> _identityServerSettings;
        private readonly DiscoveryDocumentResponse _discoveryDocument;
        private readonly HttpClient _client;

        public GuiMiGoommaServices()
        {
            _client = new HttpClient();
        }

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
                //logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse;
        }
        public async Task<HttpResponseMessage> GetToken()
        {
            var client = new HttpClient();
            HttpContent MyContent = null;

            var values = new Dictionary<string, string>
            {
                {"client_id", "m2m.client"},
                {"client_secret", "511536EF-F270-4058-80CA-1C89C192F69A"},
                {"grant_type","client_credentials"},
                {"scope", "scope1"}
                //{"UserName", "sdss"},
                //{"Password", "pipPssdsdo@12020"}
            };

            MyContent = new FormUrlEncodedContent(values);

            HttpResponseMessage tokenResponse = new HttpResponseMessage();
            try
            {
                tokenResponse = await client.PostAsync(Settings.TokenEndpoint, MyContent);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return tokenResponse;
        }
        public async Task<bool> UserRegistration(string Username, string Password, string Email, List<CompagniesData> Operatori = null)
        {
            //var client = new HttpClient();

            var model = new NewGuiMiGommaUser()
            {
                UserEmail = Email,
                Password = Password,
                UserName = Username,
                CompagniesData = Operatori
            };
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            try
            {
                httpResponse = await _client.PostAsync(new Uri(Settings.RegistrationEndpoint), content);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }



            return httpResponse.IsSuccessStatusCode;
        }
        public async Task<string> GetAccessToken(bool rememberData, string Username = "sdss", string Password = "pipPssdsdo@12020")
        {
            if (!String.IsNullOrEmpty(Preferences.Get($"CurrentToken_{Username}", string.Empty)) && rememberData)
                return Preferences.Get($"CurrentToken_{Username}", string.Empty);

            TokenResponse tokenResponse = new TokenResponse();

            try
            {
                tokenResponse = await _client.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = Settings.TokenEndpoint,
                    ClientId = Settings.ClientId,
                    ClientSecret = Settings.ClientSecret,
                    //Scope = Settings.ScopeAccessToken,
                    Scope = Settings.Scope,
                    UserName = Username,
                    Password = Password,

                });

                if (rememberData)
                    Preferences.Set($"CurrentToken_{Username}", tokenResponse.AccessToken);

            }
            catch (Exception e)
            {
                //logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
                throw new Exception($"Unable to get Accesst token with : {Username}", tokenResponse.Exception);
            }

            return tokenResponse.AccessToken;
        }

        //public async Task<UserInfoResponseGuimiGomma> GetUserInfo(string Username = "sdss", string Password = "pipPssdsdo@12020")
        public async Task<UserInfoResponse> GetUserInfo(string Username = "sdss", string Password = "pipPssdsdo@12020", bool rememberData = false)
        {

            UserInfoResponse userInfoResult = new UserInfoResponse();

            string CurrentToken = await GetAccessToken(rememberData, Username, Password);

            try
            {
                userInfoResult = await _client.GetUserInfoAsync(new UserInfoRequest
                {
                    Address = Settings.UserinfoEndpoint,
                    Token = CurrentToken

                });
            }
            catch (Exception e)
            {

                //logger.LogError($"Unable to get {Username} info from GuiMiGomma Identity Server 4. Error is: {e.StackTrace}");
                //throw new Exception(e.Message);
                //UserInfoResponseGuimiGomma UserInfError = new UserInfoResponseGuimiGomma() {
                //    ErrorMessageGG =  e.Message,
                //    ActualRespGG = userInfoResult.ActualRespGG

                //};
                //return UserInfError;

                throw new Exception(e.Message);
            }


            return userInfoResult;
        }
    }
}
