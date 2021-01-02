using Autofac;
using GuiMiGooo.Services;
using GuiMiGooo.ViewModels;
using GuiMiGooo.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiMiGooo
{
    public static class MyBoostrapper
    {
        public static void InitializeAutoFac()
        {
            var _containerBuilder = new ContainerBuilder();
            _containerBuilder.RegisterType<TokenService>();
            _containerBuilder.RegisterType<GuiMiGoommaServices>();
            _containerBuilder.RegisterType<MainShell>();            
            _containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly).Where(x => x.IsSubclassOf(typeof(BaseViewM)));

            var container = _containerBuilder.Build();

            MyResolver.Initialize(container);
        
        }
    }
}
