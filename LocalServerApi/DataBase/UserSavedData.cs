using System.ComponentModel.DataAnnotations;

namespace IdentityService.DataBase
{
    public class UserSavedData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Granttype { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string ClientId { get; set; }
    }
}
