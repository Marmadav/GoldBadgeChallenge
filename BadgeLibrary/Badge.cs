using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeLibrary
{
    public class Badge
    {
        public Badge() { }
        public string BadgeID { get; set; }
        public List<string> Doors { get; set; }

        public Badge(string badgeID, List<string> doors)

        {
            Doors = doors;
            BadgeID = badgeID;
        }

    }


}
