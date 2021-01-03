using GuiMiGooo.Services;
using GuiMiGooo.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        public string OutputText { get; set; }
        public WelcomeViewModel(GuiMiGoommaServices utilServices)
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);

            //TokenCommand
            TokenCommand = new Command(OnTokenCommandClicked);
            this.utilServices = utilServices;


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
                OutputText = await response.Content.ReadAsStringAsync(); ;

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
