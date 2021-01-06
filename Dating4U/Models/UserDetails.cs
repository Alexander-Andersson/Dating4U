using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating4U.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }

        public List<UserWall> Messages { get; set; }
        public List<User> Users { get; set; }
        public List<FriendRequest> FriendRequests { get; set; }
        public List<Friends> Friends { get; set; }
    }
}
