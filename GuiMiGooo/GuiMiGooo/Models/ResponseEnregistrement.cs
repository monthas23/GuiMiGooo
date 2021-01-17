using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuiMiGooo.Models
{
    public class ResponseEnregistrement : IdentityResult
    {
        public string errorMessage { get; internal set; }
    }
}
