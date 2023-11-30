using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FazAcontecerAPI.Models
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }

        public int PrimaryPort { get; set; }

        public string UsernameEmail { get; set; }

        public string UsernamePassword { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string NotificationTo { get; set; }
    }

}
