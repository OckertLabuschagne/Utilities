using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Payload
{
    public class Issue
    {
        public string Identifier { get; set; }
        public miscellaneous[] Miscellaneous { get; set; }
    }
}
