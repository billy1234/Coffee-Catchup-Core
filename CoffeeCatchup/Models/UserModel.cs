using System.ComponentModel.DataAnnotations;


namespace CoffeeCatchup.Models
{
    public class UserModel {
        public string email { get; set; }
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
    }
}
