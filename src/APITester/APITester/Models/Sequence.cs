using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class Sequence
    {
        public string Name { get; set; }
        public List<Step> Steps { get; set; }
    }
}
