using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityService.DataBase
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsRevoked { get; set; }

        [ForeignKey("UserRegisterData")]
        public int UserId { get; set; } // Klucz obcy do UserRegisterData
        public UserRegisterData User { get; set; } // Nawigacja do użytkownika
    }
}
