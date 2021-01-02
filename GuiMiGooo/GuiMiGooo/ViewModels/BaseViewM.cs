using GuiMiGooo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public abstract class BaseViewM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigate Navigation { get; set; } = new Navigator() ;
        public  GuiMiGoommaServices utilServices;
    }
}
