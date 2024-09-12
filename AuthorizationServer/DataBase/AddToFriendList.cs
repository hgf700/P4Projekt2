using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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