using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Projekt2.API.User
{
    public class UserAddFriend
    {
        public string RequesterEmail { get; set; } // User who sends the friend request
        public string FriendEmail { get; set; } // User who receives the friend request
        public DateTime RequestedAt { get; set; }
        public bool IsAccepted { get; set; }
    }
}
