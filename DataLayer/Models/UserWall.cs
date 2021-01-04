using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    [Keyless]
    public class UserWall
    {
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public string Message { get; set; }
    }
}
