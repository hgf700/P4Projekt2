namespace IdentityService.DataBase
{
    public class AddToFriendList
    {
        public int Id { get; set; }
        public string RequesterEmail { get; set; }
        public string FriendEmail { get; set; }
        public DateTime RequestedAt { get; set; }
        public UserLoginData Requester { get; set; }
        public UserLoginData Friend { get; set; }
    }
}