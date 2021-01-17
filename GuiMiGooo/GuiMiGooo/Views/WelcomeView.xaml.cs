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
    public partial class WelcomeView : ContentPage
    {
        public WelcomeView()
        {
            InitializeComponent();            
            Task.Run(async () => await Initialize());
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        private async Task Initialize(string argEventual = null)
        {
            var viewModel = MyResolver.Resolve<WelcomeViewModel>();
            BindingContext = viewModel;
            //Login.Clicked += viewModel.Login_Clicked;
            await viewModel.Initialize();
        }
    }
}