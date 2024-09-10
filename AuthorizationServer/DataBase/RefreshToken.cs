using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class RefreshToken
{
    [Key]
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public bool IsRevoked { get; set; }

    [ForeignKey("UserRegisterData")]
    public string UserEmail { get; set; } // Klucz obcy do UserRegisterData
    public UserRegisterData User { get; set; } // Nawigacja do UserRegisterData
}
