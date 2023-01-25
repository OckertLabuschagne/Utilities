using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class LoginResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public DateTime Date { get; set; }
        public bool IsTokenurrent { get => Date.AddSeconds(expires_in) > DateTime.Now; }
    }
}
