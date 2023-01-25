using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class GetSingleClaim : Command
    {
        public GetSingleClaim()
        {
            Name = "Get Single Claim";
            Action = ActionType.Get;
        }
        public GetSingleClaim(string baseUrl, string tpa, string claimNumber)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims/{claimNumber}";
        }
    }
}
