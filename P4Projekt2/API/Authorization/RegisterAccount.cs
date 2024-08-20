using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Projekt2.API.Authorization
{
    public class RegisterAccount
    {
        public string ResponseType { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public string State { get; set; }
        public string RedirectUri { get; set; }
        public string CodeChallenge { get; set; }
        public string CodeChallengeMethod { get; set; }
    }

}
