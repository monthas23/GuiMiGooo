//using Android.Accounts;
using GuiMiGooo.Views;
using System;
using System.Linq;
using System.Net.Http;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuiMiGooo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage( new MainPage());
            //MainPage = new NavigationPage(new LoginPage()); //registration page

            MainPage = new NavigationPage(new OAuthIdentityTestPage());
        }


        public static Account AuthAccount { get; set; }
        public static HttpClient Client = new HttpClient();

        protected override void OnStart()
        {
            /*
            var oAuth = new OAuth2Authenticator("xamarin-client", "offline_access values-api",
                new Uri("http://ipaddress:5000/connect/authorize"), new Uri("http://ipaddress:5000/grants"))
            {
                AccessTokenUrl = new Uri("http://ipaddress:5000/connect/token"),
                ShouldEncounterOnPageLoading = false
            };
            var account = AccountStore.Create().FindAccountsForService("AuthServer");
            if (account != null && account.Any())
            {
                AuthAccount = account.First();
                Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AuthAccount.Properties["access_token"]}");
                MainPage = new ValuesPage();
            }
            else
            {
                var presenter = new OAuthLoginPresenter();
                presenter.Completed += Presenter_Completed;
                presenter.Login(oAuth);
            }*/

        }
        private void Presenter_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            /*
            if (e.IsAuthenticated)
            {

                AuthAccount = e.Account;
                Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AuthAccount.Properties["access_token"]}");
                //    await AccountStore.Create().SaveAsync(e.Account, "AuthServer");
                MainPage = new ValuesPage();
            }*/
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
