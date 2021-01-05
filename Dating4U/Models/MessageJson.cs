using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating4U.Models
{
    public class MessageJson
    {
        public int Sender { get; set; }

        public int Receiver { get; set; }

        public string Message { get; set; }
    }
}
