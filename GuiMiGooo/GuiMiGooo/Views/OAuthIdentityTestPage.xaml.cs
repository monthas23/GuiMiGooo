using GuiMiGooo.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuiMiGooo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OAuthIdentityTestPage : ContentPage
    {
        private static string _authorityUrl = "http://monthas.northeurope.cloudapp.azure.com:8023/";
        private static string _registrationUrl = "http://monthas.northeurope.cloudapp.azure.com:8023/api/Register/RegisterNewMiniGommaUser";
        private static readonly string _tokenRequest = "http://monthas.northeurope.cloudapp.azure.com:8023/connect/token";
        private static readonly string _tokenScope = "scope1";
        private static readonly string _clientID = "interactive";
        private static readonly string _clientSecret = "511536EF-F270-4058-80CA-1C89C192F69A";
        private static readonly string _redirectUrls = "http://monthas.northeurope.cloudapp.azure.com:8023/signin-oidc";

        ApiServices _ap = new ApiServices();

        Account account;
        [Obsolete]
        AccountStore store;

        //RedirectUris = {"https://localhost:44309/signin-oidc"},
        //FrontChannelLogoutUri = "https://localhost:44309/signout-oidc",
        //PostLogoutRedirectUris = {"https://localhost:44309/signout-callback-oidc"},


        public OAuthIdentityTestPage()
        {
            InitializeComponent();
            store = AccountStore.Create();
        }

        void OnLoginClicked(object sender, EventArgs e)
        {

            account = store.FindAccountsForService("GuiMiGooo.Android").FirstOrDefault();

            var _authenticator = new OAuth2Authenticator(
                _clientID, _clientSecret, _tokenScope, new Uri(_authorityUrl), new Uri(_redirectUrls), _ap.TokenUri, null);


            _authenticator.Completed += OnAuthCompleted;
            _authenticator.Error += OnAuthError;


            AuthenticationState.Authenticator = _authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(_authenticator);
        }

        private void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;

            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            if (e.IsAuthenticated)
            {
                User user = null;

                var request = new OAuth2Request("POST", new Uri(_registrationUrl), null, e.Account);
                var response = await request.GetResponseAsync();

                if(response != null)
                {

                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (account != null)
                {
                    store.Delete(account, "GuiMiGooo.Android");
                }

                await store.SaveAsync(account = e.Account, "GuiMiGooo.Android");



                Application.Current.Properties.Remove("Id");
                Application.Current.Properties.Remove("FirstName");
                Application.Current.Properties.Remove("LastName");
                Application.Current.Properties.Remove("DisplayName");
                Application.Current.Properties.Remove("EmailAddress");
                Application.Current.Properties.Remove("ProfilePicture");

                Application.Current.Properties.Add("Id", user.Id);
                Application.Current.Properties.Add("FirstName", user.GivenName);
                Application.Current.Properties.Add("LastName", user.FamilyName);
                Application.Current.Properties.Add("DisplayName", user.Name);
                Application.Current.Properties.Add("EmailAddress", user.Email);
                Application.Current.Properties.Add("ProfilePicture", user.Picture);

                await Navigation.PushAsync(new ProfilePage());


            }
        }

        async  void OnEnregistrementClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());


        }
    }
}