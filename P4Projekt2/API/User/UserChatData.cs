using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Projekt2.API.User
{
    public class UserChatData
    {
        public string Message { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsSentByCurrentUser { get; set; } // Add this property
    }
}
