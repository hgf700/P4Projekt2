using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityService.DataBase
{
    public class ChatData
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Timestamp { get; set; }

        [Required]
        public string SenderEmail { get; set; }

        // Email of the recipient
        [Required]
        public string ReceiverEmail { get; set; }

        // Navigation property to sender
        [ForeignKey("SenderEmail")]
        public UserLoginData Sender { get; set; }

        // Navigation property to receiver
        [ForeignKey("ReceiverEmail")]
        public UserLoginData Receiver { get; set; }
    }
}
