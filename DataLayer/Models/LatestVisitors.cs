using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    //Klass för att lagra de senaste besökarna av en profil i databasen
    public class LatestVisitors
    {
        public int Id { get; set; }
        public User ProfileVisited { get; set; }
        public User VisitedBy { get; set; }
    }
}
