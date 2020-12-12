using GuiMiGooo.Models;
using Newtonsoft.Json;
//using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;

namespace GuiMiGooo.Services
{
    public  class ApiServices
    {
        private static string  _registrationUrl = "http://monthas.northeurope.cloudapp.azure.com:8023/api/Register/RegisterNewMiniGommaUser";
        private static readonly string _tokenRequest = "http://monthas.northeurope.cloudapp.azure.com:8023/connect/token";
        private static readonly string _tokenScope = "scope1";
        private static readonly string _clientID = "m2m.client";
        private static readonly string _clientSecret = "511536EF-F270-4058-80CA-1C89C192F69A";

        public Uri TokenUri => new Uri(_tokenRequest);

        public  async Task<string> GetTokenAsync()
        {
            var client = new HttpClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = _tokenRequest,
                ClientId = _clientID,
                ClientSecret = _clientSecret,
                Scope = _tokenScope
            });


            if (tokenResponse.IsError)
            {
                //_logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse.AccessToken;
        }
        /*
        public static async Task<string> GetAccessTokenAsync()
        {
            var client = new HttpClient();
            var tokenResponse = await client.(new AuthorizationCodeTokenRequest
            {
                Address = _tokenRequest,

                ClientId = _clientID,
                ClientSecret = _clientSecret,
                
                = _tokenScope
            });


            if (tokenResponse.IsError)
            {
                //_logger.LogError($"Unable to get token. Error is: {tokenResponse.Error}");
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse.AccessToken;
        }*/
        public  async Task<bool> RegisterAsync(string email, string password, string Username, string PhoneNumber, string CompagnyCode)
        {

            var Tok = GetTokenAsync();

            var client = new HttpClient();

            var model = new RegisterNewMiniGommaUserRequest()
            {

                UserEmail = email,
                Password = password,
                UserName = Username,
                CompagniesData = new List<CompagnyRequest>()
                {
                    new CompagnyRequest()
                    {
                    CompagnyCode = CompagnyCode,
                    PhoneNumber = PhoneNumber
                    }
                }

            };
            
            //var myModelInJson = JsonConvert.SerializeObject(model);

            //HttpContent RegistrationContent = new StringContent(myModelInJson);
            //RegistrationContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpContent content = new StringContent( JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            Uri uri = new Uri(string.Format(_registrationUrl, string.Empty));
            client.Timeout = TimeSpan.FromSeconds(200);
            HttpResponseMessage httpResponse = await client.PostAsync(uri, content);
            
            return httpResponse.IsSuccessStatusCode;
            }
        }
    
}