using GuiMiGooo.Models;
using GuiMiGooo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class RegistrationViewModel : BaseViewM
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string CompagnyCode { get; set; }
        public string UserEmail { get; set; }
        public string RegistrationResult { get; set; }
        public string PhoneNumber { get; set; }

        public List<CompagniesData> OperatorData { get; set; } = new List<CompagniesData>();
        public Command RegisterCommand { get; private set; }

        public RegistrationViewModel(GuiMiGoommaServices utilServices)
        {
            this.utilServices = utilServices;
            RegisterCommand = new Command(RegisterCommandClicked);
        }

        private async void RegisterCommandClicked(object obj)
        {
            //Validate();
            try
            {
                OperatorData.Add(new CompagniesData() { CompagnyCode = CompagnyCode, PhoneNumber = PhoneNumber});

                if (await utilServices.UserRegistration(Username, Password, UserEmail, OperatorData))
                {
                    RegistrationResult = $"Mr/Mrs {Username} à été correctement Enregistré sur GuiMiGomma";
                    Username = string.Empty;
                    UserEmail = string.Empty;
                    Password = string.Empty;
                    PhoneNumber = string.Empty;
                    CompagnyCode = string.Empty;
                }

            }
            catch (Exception e)
            {
                RegistrationResult = e.Message;
            }

        }

        private void Validate()
        {
            throw new NotImplementedException();
        }

        internal Task Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
