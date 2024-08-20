using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.ServerData
{
    public class AuthCode
    {
        public string ClientID { get; set; }
        public string RedirectUri { get; set; }
        public string CodeChallenge { get; set; }
        public string CodeChallengeMethod { get; set; }
        public DateTime Expiry { get; set; }


    }
}
