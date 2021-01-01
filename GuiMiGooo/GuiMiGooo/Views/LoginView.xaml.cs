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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            Task.Run(async () => await Initialize());

        }


        private async Task Initialize(string argEventual = null)
        {
            var viewModel = MyResolver.Resolve<LoginViewModel>();
            BindingContext = viewModel;
            await viewModel.Initialize();
        }
    }
}