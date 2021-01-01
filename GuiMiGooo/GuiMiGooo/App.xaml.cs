using System;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuiMiGooo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MyBoostrapper.InitializeAutoFac();
            MainPage = MyResolver.Resolve<MainShell>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
