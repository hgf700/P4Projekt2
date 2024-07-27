using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityService.DataBase
{
    public class UserLoginData
    {
        [Key]
        public int IdLogin { get; set; }

        [Required]
        public string Granttype { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string ClientId { get; set; }

        // Navigation property
        public virtual UserLoginRegister UserLoginRegister { get; set; }
    }
}
