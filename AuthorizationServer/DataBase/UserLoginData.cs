using IdentityService.DataBase;
using P4Projekt2.API.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class UserLoginData
{
    [Key]
    public int IdLogin { get; set; }

    public string ResponseType { get; set; }

    public string Email1 { get; set; }
    public string Email2 { get; set; }

    public string Password { get; set; }

    public string ClientId { get; set; }

    // Klucz obcy do tabeli UserRegisterData, na podstawie emaila
    [ForeignKey("UserRegisterData")]
    public string UserRegisterEmail { get; set; }

    // Właściwość nawigacyjna do UserRegisterData
    public UserRegisterData Userregisterdata { get; set; }

    // Relacja do ChatData (wiadomości wysłane i otrzymane)
    public ICollection<ChatData> SentMessages { get; set; }
    public ICollection<ChatData> ReceivedMessages { get; set; }

    // Relacja do AddToFriendList (zaproszenia do znajomych wysłane i otrzymane)
    public ICollection<AddToFriendList> SentFriendRequests { get; set; }
    public ICollection<AddToFriendList> ReceivedFriendRequests { get; set; }
}