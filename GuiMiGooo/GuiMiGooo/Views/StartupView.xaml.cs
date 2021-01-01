using GuiMiGooo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuiMiGooo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartupView : ContentPage
    {
        public StartupView()
        {
            InitializeComponent();
            Task.Run(async () => await Initialize());

        }


        private async Task Initialize(string argEventual = null)
        {
            var viewModel = MyResolver.Resolve<StartUpViewModel>();
            BindingContext = viewModel;
            await viewModel.Initialize();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (MyResolver.Resolve<StartUpViewModel>()).CheckLogin();
            //_viewModel.CheckLogin();
        }

        public async Task CheckLogin()
        {
            // should check for valid login instead
            await Task.Delay(2000);

            // only open Login page when no valid login
            //await Shell.Current.GoToAsync($"//{nameof(WelcomeView)}");
            await Shell.Current.GoToAsync($"//{nameof(WelcomeView)}");
        }
    }
}