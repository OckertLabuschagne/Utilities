using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class Step
    {
        public int Ordinal { get; set; }
        public Command Command { get; set; }
        public string Name => Command.Name;
    }
}
