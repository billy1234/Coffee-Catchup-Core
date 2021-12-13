using CoffeeCatchup.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCatchup.Services
{
    
    public class UsersDataAPIService {

        HttpClient client;
        DataContractJsonSerializer serializer;

        public UsersDataAPIService(string serviceUrl) {
            this.client = new HttpClient();
            client.BaseAddress = new Uri(serviceUrl);

            this.serializer = new DataContractJsonSerializer(typeof(UserModel));

        }

        public async Task<HttpResponseMessage> postUser(UserModel user) {
            MemoryStream data = new MemoryStream();

            serializer.WriteObject(data, user);
            StringContent content = new StringContent(Encoding.UTF8.GetString(data.ToArray()), Encoding.UTF8, "application/json");
            data.Close();

            return await client.PostAsync(
                "api/users",
                content);
        }



    }
}
