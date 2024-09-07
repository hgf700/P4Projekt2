using System.ComponentModel.DataAnnotations;

namespace IdentityService.DataBase
{
    public class Key
    {
        [Key]
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string AuthorizationKey { get; set; }
        public DateTime Expire { get; set; }

        public string UserRegisterEmail { get; set; } // Klucz obcy
        public UserRegisterData UserRegisterData { get; set; }
    }
}
