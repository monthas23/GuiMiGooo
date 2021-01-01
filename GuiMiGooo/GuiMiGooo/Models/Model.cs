using System;
using System.Collections.Generic;
using System.Text;

namespace GuiMiGooo.Models
{
    public class Model
    {

    }


    public class CompagniesData
    {

        public string CompagnyCode { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class NewGuiMiGommaUser
    {

        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public List<CompagniesData> CompagniesData { get; set; }


    }

    public class User
    {
        public string email { get; set; }
        public string sub { get; set; }
        public bool email_verified { get; set; }
        public string phoneNumber { get; set; }
        public string userId { get; set; }
    }
}
