using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Commands
{
    public class CreateClaim : Command
    {
        public CreateClaim()
        {
            Name = "Create Claim";
            Action = ActionType.Post;
        }
        public CreateClaim(string baseUrl, string tpa)
            : this()
        {
            URL = $"{baseUrl}/{tpa}/claims";
        }
    }
}
