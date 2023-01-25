using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class GetIncomingDocument: Command
    {
        public GetIncomingDocument()
        {
            Name = "Get Incoming Document";
            Action = ActionType.Get;
        }

        public GetIncomingDocument(string baseUrl, string tpa, string identifier)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims/document/incoming/{identifier}";
        }
    }
}
