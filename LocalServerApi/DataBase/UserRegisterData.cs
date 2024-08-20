using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityService.DataBase
{
    public class UserRegisterData
    {
        [Key]
        public int IdRegister { get; set; }
        public string ResponseType { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public string State { get; set; }
        public string RedirectUri { get; set; }
        public string CodeChallenge { get; set; }
        public string CodeChallengeMethod { get; set; }
    }
}
