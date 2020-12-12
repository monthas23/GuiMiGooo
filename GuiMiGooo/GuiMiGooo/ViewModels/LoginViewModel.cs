using GuiMiGooo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class LoginViewModel
    {
        //ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public string PhoneNumber { get; set; }
        public string CompagnyCode { get; set; }

        public string Message { get; set; }
        public ICommand RegistrationComnand {

            get
            {
               
                return new Command( async () =>
                {
                    ApiServices _apTemp = new ApiServices();
                    var isSuccess = await _apTemp.RegisterAsync(Email, Password, Username, PhoneNumber, CompagnyCode);
                    

                    if (isSuccess) {
                     
                    Message = Username + " has been successfully registered on GuiMiGomma";
                }
                    else
                        Message = "Unfortunetly, somthing went wrong during ur registration " + Username;
                
                });

            }

        
        
        }
    }

}
