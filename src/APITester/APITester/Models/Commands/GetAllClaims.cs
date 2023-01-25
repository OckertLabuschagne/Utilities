using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class GetAllClaims : Command
    {
        public GetAllClaims()
        {
            Name = "Get All Claims";
            Action = ActionType.Get;
        }

        public GetAllClaims(string baseUrl, string tpa)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims";
        }
    }
}
