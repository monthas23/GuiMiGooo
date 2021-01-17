using GuiMiGooo.Services;
using GuiMiGooo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class HomeViewModel : BaseViewM
    {
        public HomeViewModel(GuiMiGoommaServices utilServices)
        {
            OutputText = "txt";
            LogoutCommand = new Command(LogoutCommandClicked);
        }

        private async void LogoutCommandClicked(object obj)
        {
            await Navigation.NavigateTo($"//{nameof(WelcomeView)}");
        }

        public string OutputText { get; private set; }
        public Command LogoutCommand { get; private set; }

        internal Task Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
