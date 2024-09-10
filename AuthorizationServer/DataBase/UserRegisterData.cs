using IdentityService.DataBase;
using System.ComponentModel.DataAnnotations;

public class UserRegisterData
{
    [Key]
    public int IdRegister { get; set; }
    public string Email { get; set; } // Klucz unikalny dla relacji z RefreshToken
    public string ResponseType { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string PasswordHash { get; set; }
    public string ClientId { get; set; }
    public string Scope { get; set; }
    public string State { get; set; }
    public string RedirectUri { get; set; }
    public string CodeChallenge { get; set; }
    public string CodeChallengeMethod { get; set; }

    public ICollection<Key> Keys { get; set; }
    public ICollection<UserLoginData> Userlogindata { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }

    // Usunięte relacje z AddToFriendList, bo tylko login ma je obsługiwać
}
