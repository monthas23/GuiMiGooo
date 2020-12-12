using System;
using System.Collections.Generic;
using System.Text;

namespace GuiMiGooo.Services
{
    public class IdentityServerSettings
    {
        public IdentityServerSettings()
        {
            //DiscoveryUrl = 
        }
        public string DiscoveryUrl { get; set; }
        public string ClientName { get; set; }
        public string ClientPassword  { get; set; }

        public bool UseHttps { get; set; }
    }
}
