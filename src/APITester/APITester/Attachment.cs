using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json; 

namespace APITester
{
    public class Attachment
    {
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public string UserId { get; set; }
        public string Notes { get; set; }
    }
}
