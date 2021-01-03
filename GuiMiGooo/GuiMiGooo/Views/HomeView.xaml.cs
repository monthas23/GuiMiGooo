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
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            Task.Run(async () => await Initialize());
        }

        private async Task Initialize()
        {
            var viewModel = MyResolver.Resolve<HomeViewModel>();
            BindingContext = viewModel;
            await viewModel.Initialize();
        }
    }
}