using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace IdentityService.DataBase
{
    public class ChatData
    {
        [Key]
        public int MessageId { get; set; }
        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public string SenderEmail { get; set; }

        // Email odbiorcy
        public string ReceiverEmail { get; set; }

        // This property is not mapped to the database
        [NotMapped]
        public bool IsSentByCurrentUser { get; set; }

        // Nawigacja do nadawcy
        [ForeignKey("SenderEmail")]
        public UserLoginData Sender { get; set; }

        // Nawigacja do odbiorcy
        [ForeignKey("ReceiverEmail")]
        public UserLoginData Receiver { get; set; }
    }
}
