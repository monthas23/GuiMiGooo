using GuiMiGooo.Services;
using GuiMiGooo.Views;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class LoginViewModel : BaseViewM
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string OutputText { get; set; }
        

        public bool RememberMe
        {
            get => Preferences.Get(nameof(RememberMe), false);

            set => Preferences.Set(nameof(RememberMe), value);
            
        }

        public Command SaveCommand { get; private set; }

        public LoginViewModel(GuiMiGoommaServices utilServices)
        {
            //backProva = new Command(backProvaComm);
            this.utilServices = utilServices;
            SaveCommand = new Command(SaveCommandClicked);

        }

        
        private async void SaveCommandClicked(object obj)
        {
            UserInfoResponse resp = new UserInfoResponse();
            try
            {

                resp = await utilServices.GetUserInfo(Username, Password, RememberMe);


                var sb = new StringBuilder(128);

                foreach (var claim in resp.Claims)
                {
                    sb.AppendFormat("{0}: {1}\n", claim.Type, claim.Value);
                }

                OutputText = sb.ToString();

            }
            catch (Exception e)
            {
                OutputText = e.Message;

            }

            if (resp != null && resp.HttpResponse != null && resp.HttpResponse.IsSuccessStatusCode)
                //await Navigation.NavigateTo(nameof(HomeView));
                await Navigation.NavigateTo($"//{nameof(HomeView)}");

        }

        internal Task Initialize()
        {
            throw new NotImplementedException();
        }

        public Command BackCommand =>
            new Command(async () =>
            {
                await Navigation.NavigateTo("..");
            });

        public Command backProva { get; set; }
        private async void backProvaComm(object obj)
        {
            await Navigation.NavigateTo($"//{nameof(WelcomeView)}");
        }

    }
}
