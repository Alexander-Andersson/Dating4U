using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Friends
    {
        public int Id { get; set; }
        public User Friend_1 { get; set; }
        public User Friend_2 { get; set; }
    }
}
