using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuiMiGooo.ViewModels
{
    public class HomeViewModel : BaseViewM
    {
        public HomeViewModel(string txt)
        {
            OutputText = txt;
        }

        public string OutputText { get; private set; }

        internal Task Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
