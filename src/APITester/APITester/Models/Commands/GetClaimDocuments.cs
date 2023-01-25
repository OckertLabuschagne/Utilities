using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class GetClaimDocuments : Command
    {
        public GetClaimDocuments()
        {
            Name = "Get Claim Documents";
            Action = ActionType.Get;
        }

        public GetClaimDocuments(string baseUrl, string tpa,string claimNumber)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims/{claimNumber}/documents";
        }
    }
}
