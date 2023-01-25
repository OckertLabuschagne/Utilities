using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class GetInspectionRequests : Command
    {

        public GetInspectionRequests()
        {
            Name = "Get Inspections";
            Action = ActionType.Get;
        }

        public GetInspectionRequests(string baseUrl, string tpa, string claimNumber)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims/{claimNumber}/inspections";
        }
    }
}
