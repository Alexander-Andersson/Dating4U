using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating4U.Models
{
    //En klass för att mappa om user object till xmlFriend när man sparar ned sin profil till XML
    public class XmlFriend
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Hobby { get; set; }
        public string ProfilePicture { get; set; }
    }
}
