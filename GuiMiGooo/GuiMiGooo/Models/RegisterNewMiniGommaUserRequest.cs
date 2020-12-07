using System;
using System.Collections.Generic;
using System.Text;

namespace GuiMiGooo.Models
{
    class RegisterNewMiniGommaUserRequest
    {
        public List<CompagnyRequest> CompagniesData { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public string UserEmail { get; set; }
    }
}
