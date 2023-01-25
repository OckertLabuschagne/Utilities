using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class GetInspectionPartners : Command
    {
        public GetInspectionPartners()
        {
            Name = "Get Inspection Partners";
            Action = ActionType.Get;
        }

        public GetInspectionPartners(string baseUrl, string tpa)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims/inspection_partners";
        }
    }
}
