namespace IdentityService.DataBase
{
    public class Key
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string AuthorizationKey { get; set; }
        public DateTime Expire { get; set; }

        public ICollection<UserRegisterData> Users { get; set; }
    }
}
