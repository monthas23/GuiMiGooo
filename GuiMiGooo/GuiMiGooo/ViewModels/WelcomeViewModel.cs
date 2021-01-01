using GuiMiGooo.Services;
using GuiMiGooo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class WelcomeViewModel : BaseViewM
    {

        public Command LoginCommand { get; private set; }
        public Command RegisterCommand { get; private set; }
        public Command TokenCommand { get; private set; }
        private Command backProva { get; set; }

        public WelcomeViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);

            //TokenCommand
            TokenCommand = new Command(OnTokenCommandClicked);


        }

        private async void OnTokenCommandClicked()
        {
            GuiMiGoommaServices _UtilsService = new GuiMiGoommaServices();

            var response = await _UtilsService.GetUserInfo();
            var sb = new StringBuilder(128);
            foreach (var claim in response.Claims)
            {
                sb.AppendFormat("{0}: {1}\n", claim.Type, claim.Value);
            }

            string test = sb.ToString();

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
