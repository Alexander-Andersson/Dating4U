using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating4U.Models
{
    public class XmlProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public string Hobby { get; set; }
        public List<XmlFriend> FriendList { get; set; }
    }
}
