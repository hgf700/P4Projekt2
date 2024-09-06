using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Projekt2.API.User
{
    public class AddToFriendList
    {
        public int Id {  get; set; }
        public string Firstname { get; set; } = null;
        public string Lastname { get; set; } = null;
        public string FriendEmail { get; set; }
        public string UserEmail { get; set; }
    }
}
