using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace APITester.Models
{
    public class Credentials
    {
        public string UserId { get; set; }
        public string Secret { get => Encryption.Encrypt(Password); set => Password = Encryption.Decrypt(value); }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
