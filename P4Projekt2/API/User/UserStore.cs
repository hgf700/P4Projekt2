using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Projekt2.API.User
{
    public class UserStore
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
