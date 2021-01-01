using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuiMiGooo
{
    public interface INavigate
    {
        Task NavigateTo(string route);
        Task PushModal(MainPage page);
        Task PopModal();
    }
}
