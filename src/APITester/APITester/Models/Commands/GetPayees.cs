using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class GetPayees : Command
    {
        public GetPayees()
        {
            Name = "Get Payees";
            Action = ActionType.Get;
        }

        public GetPayees(string baseUrl, string tpa, string claimNumber)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims/{claimNumber}/payees";
        }
    }
}
