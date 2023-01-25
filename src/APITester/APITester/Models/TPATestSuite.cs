using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class TPATestSuite
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string LoginUrl { get; set; }
        public Credentials Credentials {get;set;}
        public List<Command> Commands { get; set; }
    }
}
