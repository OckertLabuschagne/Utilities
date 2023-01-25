using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    class GetOutgoingDocument : Command
    {
        public GetOutgoingDocument()
        {
            Name = "Get Outgoing Document";
            Action = ActionType.Get;
        }

        public GetOutgoingDocument(string baseUrl, string tpa, string documentIdentifier)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims/document/outgoing/{documentIdentifier}";
        }
    }
}
