using GuiMiGooo.Services;
using GuiMiGooo.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class LoginViewModel : BaseViewM
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string OutputText { get; set; }

        private readonly GuiMiGoommaServices utilServices;

        public Command SaveCommand { get; private set; }

        public LoginViewModel(GuiMiGoommaServices utilServices)
        {
            //backProva = new Command(backProvaComm);
            this.utilServices = utilServices;
            SaveCommand = new Command(SaveCommandClicked);

        }

        private async void SaveCommandClicked(object obj)
        {
            try
            {

                var resp = await utilServices.GetUserInfo(Username, Password);

                if (resp.Error != null)
                {
                    OutputText = resp.HttpErrorReason;
                }
                else
                {
                    var sb = new StringBuilder(128);
                    foreach (var claim in resp.Claims)
                    {
                        sb.AppendFormat("{0}: {1}\n", claim.Type, claim.Value);
                    }

                    OutputText = sb.ToString();
                }

                
            }
            catch (Exception)
            {

                throw;
            }
            
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

        public Command backProva { get;  set; }
        private async void backProvaComm(object obj)
        {
            await Navigation.NavigateTo($"//{nameof(WelcomeView)}");
        }

    }
}
