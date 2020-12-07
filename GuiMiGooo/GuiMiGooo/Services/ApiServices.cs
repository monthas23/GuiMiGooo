using GuiMiGooo.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace GuiMiGooo.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string Username, string PhoneNumber, string CompagnyCode)
        {
            var client = new HttpClient();
            

            var model = new RegisterNewMiniGommaUserRequest()
            {

                UserEmail = email,
                Password = password,
                UserName = Username,
                CompagniesData = new List<CompagnyRequest>()
                {  
                    new CompagnyRequest()
                    {
                    CompagnyCode = CompagnyCode,
                    PhoneNumber = PhoneNumber
                    }
                }

            };

            var myModelInJson = JsonConvert.SerializeObject(model);

            HttpContent RegistrationContent = new StringContent(myModelInJson);
            ///api/Register/RegisterNewMiniGommaUser
            ///

            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsImtpZCI6IjgxQTQwMkQyRDI1MDRCN0IzNzY1REFBMTVCNEExNzJBIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MDczNTQwMTksImV4cCI6MTYwNzM1NzYxOSwiaXNzIjoiaHR0cDovL21vbnRoYXMubm9ydGhldXJvcGUuY2xvdWRhcHAuYXp1cmUuY29tOjgwMjMiLCJhdWQiOiJodHRwOi8vbW9udGhhcy5ub3J0aGV1cm9wZS5jbG91ZGFwcC5henVyZS5jb206ODAyMy9yZXNvdXJjZXMiLCJjbGllbnRfaWQiOiJtMm0uY2xpZW50IiwianRpIjoiMkYzQkQzNkExQkY3ODI1MzFFM0MzMDUyQTdFQTc1RTQiLCJpYXQiOjE2MDczNTQwMTksInNjb3BlIjpbInNjb3BlMSJdfQ.g1f9D0Mk8kDBBx-r7AN2SJmZazUyJET9cqHQJQkZJ8yUSrFPpKT1TVqqRAqdgPavjtQ4hs54khM9YqhhsmIZ7xwrTBCyVHxQQ8OFI1tsBDbOxmyC7Zg72pXR0DfDbHTH9-BNmec2-HMSNDHJXvr2VGJwWqH8bLiOTHp_hafQaVPo38cxaYh_Ed6Rj5dU4ouhg6K8bIf9GTROLVIiOYdX092bKQJH7lRu-6ccO18Aovz-ly3hCKtAx6UjL86Jmrhb1tB69msabd14aPOzrIyhH0044wklr_NKZxes-eURbd_o1IXvDVjytXTdQML_RyBr-hJHbO-rI4JvCUlp3LIhIA");
            //client.SetBearerToken("eyJhbGciOiJSUzI1NiIsImtpZCI6IjgxQTQwMkQyRDI1MDRCN0IzNzY1REFBMTVCNEExNzJBIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MDczNTQwMTksImV4cCI6MTYwNzM1NzYxOSwiaXNzIjoiaHR0cDovL21vbnRoYXMubm9ydGhldXJvcGUuY2xvdWRhcHAuYXp1cmUuY29tOjgwMjMiLCJhdWQiOiJodHRwOi8vbW9udGhhcy5ub3J0aGV1cm9wZS5jbG91ZGFwcC5henVyZS5jb206ODAyMy9yZXNvdXJjZXMiLCJjbGllbnRfaWQiOiJtMm0uY2xpZW50IiwianRpIjoiMkYzQkQzNkExQkY3ODI1MzFFM0MzMDUyQTdFQTc1RTQiLCJpYXQiOjE2MDczNTQwMTksInNjb3BlIjpbInNjb3BlMSJdfQ.g1f9D0Mk8kDBBx-r7AN2SJmZazUyJET9cqHQJQkZJ8yUSrFPpKT1TVqqRAqdgPavjtQ4hs54khM9YqhhsmIZ7xwrTBCyVHxQQ8OFI1tsBDbOxmyC7Zg72pXR0DfDbHTH9-BNmec2-HMSNDHJXvr2VGJwWqH8bLiOTHp_hafQaVPo38cxaYh_Ed6Rj5dU4ouhg6K8bIf9GTROLVIiOYdX092bKQJH7lRu-6ccO18Aovz-ly3hCKtAx6UjL86Jmrhb1tB69msabd14aPOzrIyhH0044wklr_NKZxes-eURbd_o1IXvDVjytXTdQML_RyBr-hJHbO-rI4JvCUlp3LIhIA");


            var clientRestsh = new RestClient("http://monthas.northeurope.cloudapp.azure.com:8023/api/Register/RegisterNewMiniGommaUser");
            clientRestsh.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", myModelInJson);
            //request.AddParameter("application/json", "{\r\n  \"CompagniesData\": [\r\n    {\r\n      \"PhoneNumber\": \"00237s77844\",\r\n      \"CompagnyCode\": \"MTN\"\r\n    },\r\n    {\r\n      \"PhoneNumber\": \"0023777865\",\r\n      \"CompagnyCode\": \"ORANGE\"\r\n    },\r\n    {\r\n      \"PhoneNumber\": \"0023777999\",\r\n      \"CompagnyCode\": \"EXPRESSUNION\"\r\n    }\r\n  ],\r\n  \"UserEmail\": \"defsdscoq73@yasdsdhoo.fr\",\r\n  \"UserName\": \"sdss\",\r\n  \"Password\": \"pipPssdsdo@12020\"\r\n\r\n}", ParameterType.RequestBody);
            IRestResponse response = clientRestsh.Execute(request);
            Console.WriteLine(response.Content);




            //RegistrationContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            //var Response = await client.PostAsync("http://monthas.northeurope.cloudapp.azure.com:8023/connect/token", RegistrationContent);


            return response.IsSuccessful;
        }
    }
}
;