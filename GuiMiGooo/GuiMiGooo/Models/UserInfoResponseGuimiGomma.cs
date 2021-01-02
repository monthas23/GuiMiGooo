using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuiMiGooo.Models
{
    public class UserInfoResponseGuimiGomma : UserInfoResponse
    {
        public UserInfoResponse ActualRespGG { get; set; }
        public string ErrorMessageGG { get; set; }
        public string ErrorTypeGG { get; set; }
    }
}
