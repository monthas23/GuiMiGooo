using System;
using System.Collections.Generic;
using System.Text;

namespace GuiMiGooo
{
    public static class Settings
    {

        public static string RegistrationEndpoint2
        {
            get
            {
                return "https://monthasbjridserver.azurewebsites.net/api/GuiMiGoooServices/Enregistrement";
            }
        }
        public static string RegistrationEndpoint
        {
            get
            {
                return "http://monthas.northeurope.cloudapp.azure.com:8023/api/Register/RegisterNewMiniGommaUser";
            }
        }
        public static string AllUsersinfoEndpoint
        {
            get
            {
                return "http://monthas.northeurope.cloudapp.azure.com:8023/api/Register/GetAllUsers";
            }
        }

        public static string AllUsersinfoEndpoint2
        {
            get
            {
                return "https://monthasbjridserver.azurewebsites.net/api/GuiMiGoooServices/GetAllUsers";
            }
        }
        public static string UserinfoEndpoint2
        {
            get
            {
                return "https://monthasbjridserver.azurewebsites.net/connect/userinfo";
            }
        }
        public static string UserinfoEndpoint
        {
            get
            {
                return "http://monthas.northeurope.cloudapp.azure.com:8023/connect/userinfo";
            }
        }
        public static string TokenEndpoint
        {
            get
            {
                return "http://monthas.northeurope.cloudapp.azure.com:8023/connect/token";
            }
        }

        public static string ClientId
        {
            get
            {
                return "m2m2.client";
            }
        }


        public static string ClientSecret
        {
            get
            {
                return "511536EF-F270-4058-80CA-1C89C192F69A";
            }
        }

        public static string Scope
        {
            get
            {
                return "scope1 openid email";
            }
        }

        public static string ScopeAccessToken
        {
            get
            {
                return "scope1";
            }
        }
    }
}
