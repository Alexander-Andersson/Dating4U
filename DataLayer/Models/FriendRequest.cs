using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    [Keyless]
    public class FriendRequest
    {
        public User Sender { get; set; }
        public User Reciever { get; set; }
    }
}
