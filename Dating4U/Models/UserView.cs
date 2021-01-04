using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating4U.Models
{
    public class UserView
    {
        public List<User> Users { get; set; }

        public List<UserWall> Messages { get; set; }

        public List<Friends> Friends { get; set; }
    }
}
