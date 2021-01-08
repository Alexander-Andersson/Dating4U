using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating4U.Models
{
    //Klass för att hjälpa vid Json-konvertering av LatestVisitor-objekt
    //Används för att metod i LatestVisitorsController behöver int-värden som parameter
    public class LatestVisitorJson
    {
        public int ProfileVisited { get; set; }
        public int VisitedBy { get; set; }
    }
}
