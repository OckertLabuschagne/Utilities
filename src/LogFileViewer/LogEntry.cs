using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer
{
    public class LogEntry
    {
        public DateTime Time { get; set; } //"@t": "2021-07-12T19:37:29.5505978Z",
        public string Method { get; set; }// "@mt": "Error handled",
        public string Type { get; set; }// "@l": "Error",
        public string StackTrace { get; set; }//"@x": "
        public string SourceContext { get; set; }
        public string ActionId { get; set; }
        public string ActionName { get; set; }
        public string RequestId { get; set; }
        public string RequestPath { get; set; }
        public string SpanId { get; set; }
        public string TraceId { get; set; }
        public string ParentId { get; set; }
    }
}
