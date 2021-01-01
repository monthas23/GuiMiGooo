
using GuiMiGooo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class StartUpViewModel : BaseViewM
    {
        internal Task Initialize()
        {
            throw new NotImplementedException();
        }

        public async Task CheckLogin()
        {
            // should check for valid login instead
            await Task.Delay(2000);

            // only open Login page when no valid login
            await Navigation.NavigateTo($"//{nameof(WelcomeView)}");
            //await Navigation.NavigateTo(nameof(WelcomeView));
        }

        public void  CheckLoginSync()
        {
            System.Threading.Thread.Sleep(10000);

            Shell.Current.GoToAsync($"//{nameof(WelcomeView)}");
        }


    }
}
