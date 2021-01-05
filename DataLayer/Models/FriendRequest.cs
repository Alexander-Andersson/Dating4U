using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
