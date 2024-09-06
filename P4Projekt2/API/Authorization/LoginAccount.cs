using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Projekt2.API.Authorization
{
    public class LoginAccount
    {
        public string ResponseType { get; set; }   
        public string Email { get; set; }
        public string PasswordHash { get; set; }    
        public string ClientId { get; set; }    

    }
}
