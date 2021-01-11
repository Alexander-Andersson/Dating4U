using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating4U.Models
{
    //En klass som används för att ta emot json objekt som skickas med ajax
    public class XmlJson
    {
        public XmlProfile Profile { get; set; }
        public string FileName { get; set; }
    }
}
