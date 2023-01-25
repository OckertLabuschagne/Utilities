using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
namespace FI.Models
{
    public class PerformanceLog
    {
        public string Method { get; set; }
        public int Level { get; set; }
        public double Duration { get; set; }
        public string Detail { get; set; }
        public string TPA { get; set; }
        public JObject JsonObject { get; set; }
        public string ActionId { get; set; }
    }
}
