using System.ComponentModel.DataAnnotations;

namespace IdentityService.DataBase
{
    public class UserLoginData
    {
        [Key]
        public int IdLogin { get; set; }
        public string ResponseType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }

        public string UserRegisterEmail { get; set; } // Klucz obcy
        public UserRegisterData UserRegisterData { get; set; }
    }
}
