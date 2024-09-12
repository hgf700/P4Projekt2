using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Projekt2.API.User
{
    public class AddFriendRequest
    {
        public string RequesterIdLogin { get; set; }
        public string FriendIdLogin { get; set; }
        public DateTime RequestedAt { get; set; }
    }


}
