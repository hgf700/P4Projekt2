using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Projekt2.API.Authorization
{
    public class LoginAccount
    {
        [Required]
        public string Granttype { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ClientId { get; set; }
    }
}

        //public string AccessToken { get; set; }
        //public string TokenType { get; set; }
        //public int ExpiresIn { get; set; }
        //public string RefreshToken { get; set; }
