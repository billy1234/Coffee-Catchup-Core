using CoffeeCatchup.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCatchup.Services
{
    
    public class UsersDataAPIService {

        HttpClient client;

        public UsersDataAPIService(string serviceUrl) {
            this.client = new HttpClient();
            client.BaseAddress = new Uri(serviceUrl);


        }

        public async Task<HttpResponseMessage> postUser(UserModel user) {
            return await client.PostAsync(
                "api/users",
                new StringContent(user.ToString(), Encoding.UTF8, "application/json"));
        }



    }
}
