namespace IdentityService.DataBase
{
    public class ChatData
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public DateTime Timestamp { get; set; } 

    }
}
