using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Payload
{
    public class Request
    {
        public deductible[] Deductibles { get; set; }
        public Issue[] Issues { get; set; }
    }
}
