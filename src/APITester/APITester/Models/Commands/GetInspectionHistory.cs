using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class GetInspectionHistory : Command
    {

        public GetInspectionHistory()
        {
            Name = "Get Inspection History";
            Action = ActionType.Get;
        }

        public GetInspectionHistory(string baseUrl, string tpa, string claimNumber)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims/{claimNumber}/inspections/history";
        }
    }
}
