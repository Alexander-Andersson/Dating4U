using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    [Keyless]
    public class Friends
    {
        public User User1 { get; set; }
        public User User2 { get; set; }
    }
}
