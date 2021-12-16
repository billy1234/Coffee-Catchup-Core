using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;



namespace CoffeeCatchup.Models {
    

    public class UserModel {
        private DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserModel));

        public string email { get; set; }
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }

        public override string ToString() {
            MemoryStream data = new MemoryStream();

            serializer.WriteObject(data, this);
            string json = Encoding.UTF8.GetString(data.ToArray());
            data.Close();
            return json;
        }
    }
}
