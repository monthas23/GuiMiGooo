using GuiMiGooo.Services;
using GuiMiGooo.Views;
using IdentityModel;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class WelcomeViewModel : BaseViewM
    {

        public Command LoginCommand { get; private set; }
        public Command RegisterCommand { get; private set; }
        public Command BrowseLoginCommand { get; private set; }
        public Command TokenCommand { get; private set; }
        private Command backProva { get; set; }
        public string OutputText { get; set; }

        internal async void Login_Clicked(object sender, EventArgs e)
        {
            var _result = await _client.LoginAsync(new LoginRequest());

            if (_result.IsError)
            {
                OutputText = _result.Error;
                return;
            }
            else
            {
                var sb = new StringBuilder(128);
                foreach (var claim in _result.User.Claims)
                {
                    sb.AppendFormat("{0}: {1}\n", claim.Type, claim.Value);
                }

                sb.AppendFormat("\n{0}: {1}\n", "refresh token", _result?.RefreshToken ?? "none");
                sb.AppendFormat("\n{0}: {1}\n", "access token", _result.AccessToken);

                OutputText = sb.ToString();

                _apiClient.Value.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _result?.AccessToken ?? "");
                //await Navigation.NavigateTo($"//{nameof(HomeView)}");
                //await Navigation.NavigateTo($"//{nameof(WelcomeView)}");
                return;
            }
        }

        OidcClient _client { get; set; }
        LoginResult _result { get; set; }
        Lazy<HttpClient> _apiClient = new Lazy<HttpClient>(() => new HttpClient());

        public WelcomeViewModel(GuiMiGoommaServices utilServices)
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            BrowseLoginCommand = new Command(BrowseLoginClicked);
            
            //TokenCommand
            TokenCommand = new Command(OnTokenCommandClicked);
            this.utilServices = utilServices;

            InitializeBrowserLogin();

        }

        private async void BrowseLoginClicked(object obj)
        {
            var _result = await _client.LoginAsync(new LoginRequest());

            if (_result.IsError)
            {
                OutputText = _result.Error;
                return;
            }
            else
            {
                var sb = new StringBuilder(128);
                foreach (var claim in _result.User.Claims)
                {
                    sb.AppendFormat("{0}: {1}\n", claim.Type, claim.Value);
                }

                sb.AppendFormat("\n{0}: {1}\n", "refresh token", _result?.RefreshToken ?? "none");
                sb.AppendFormat("\n{0}: {1}\n", "access token", _result.AccessToken);

                OutputText = sb.ToString();

                _apiClient.Value.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _result?.AccessToken ?? "");
                //await Navigation.NavigateTo($"//{nameof(HomeView)}");
                await Navigation.NavigateTo($"//{nameof(WelcomeView)}");
                return;
            }
        }

        private void InitializeBrowserLogin()
        {
            var browser = DependencyService.Get<IBrowser>();
            //var browser = new ChromeCustomTabsBrowser();

            var options = new OidcClientOptions
            {
                //Authority = "http://monthas.northeurope.cloudapp.azure.com",
                Authority = "https://monthasbjridserver.azurewebsites.net",
                ClientId = "xamarin",
                //ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".ToSha256(),
                //Scope = "openid profile email api offline_access",
                Scope = "openid profile",
                RedirectUri = "xamarinformsclients://callback",
                //RedirectUri = "http://monthas.northeurope.cloudapp.azure.com/xamarinformsclients://callback",
                Browser = browser,



                //BackchannelHandler = new HttpClientHandler() { ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true },
                //Policy = new Policy()
                //{
                //    Discovery = new DiscoveryPolicy() { RequireHttps = false }
                //},
                ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect
            };

            _client = new OidcClient(options);

            _apiClient.Value.BaseAddress = new Uri("https://monthasbjridserver.azurewebsites.net/");
        }


        private async void OnTokenCommandClicked()
        {
            var response = new HttpResponseMessage();

            
            try
            {
                response = await utilServices.GetToken();
            }
            catch (Exception e)
            {

                OutputText = e.Message;
            }
            if(response.IsSuccessStatusCode)
            OutputText = await response.Content.ReadAsStringAsync();
        }

        internal Task Initialize(string arg = null)
        {
            throw new NotImplementedException();
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Navigation.NavigateTo($"//{nameof(LoginView)}");
            //await Navigation.NavigateTo($"//{nameof(LoginView)}");
            await Navigation.NavigateTo(nameof(LoginView));
        }

        private async void OnRegisterClicked(object obj)
        {
            await Navigation.NavigateTo($"{nameof(RegistrationView)}");
        }
    }
}
