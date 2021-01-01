using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiMiGooo
{
    public static class MyResolver
    {
        public static IContainer container;

        public static void Initialize(IContainer _container)
        {
            MyResolver.container = _container;        
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

    }
}
