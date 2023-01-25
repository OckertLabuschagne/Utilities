using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class TPALoadTestSuite : TPATestSuite
    {
        public int NumberOfCalls { get; set; }
        public int Duration { get; set; }
        public int TimeBetweenCalls { get; set; }
        public int StartLoad { get; set; } = 2;
        public int EndLoad { get; set; } = 20;
        public int LoadIncrement { get; set; } = 1;
        public TestMode TestMode { get; set; }
    }

    public enum TestMode
    {
        NumberOfCalls,
        Duration,
        MultiLoad
    }
}
