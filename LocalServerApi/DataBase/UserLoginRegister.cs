using System.ComponentModel.DataAnnotations;

namespace IdentityService.DataBase
{
    public class UserLoginRegister
    {
        [Key]
        public int IdLoginRegister { get; set; }

        [Required]
        public int IdLogin { get; set; }

        [Required]
        public int IdRegister { get; set; }

        // Navigation properties
        public virtual UserLoginData UserLoginData { get; set; }
        public virtual UserRegisterData UserRegisterData { get; set; }
    }
}
