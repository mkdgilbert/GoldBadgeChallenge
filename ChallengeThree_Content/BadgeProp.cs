using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Content
{
    public class BadgeContent
    {
        public List<string> ListOfDoors { get; set; } = new List<string>();
        //with a colleciton of objects must new up
        public int BadgeID { get; set; }
        public BadgeContent() { }
        public BadgeContent(List<string> listOfDoors, int badgeId)
        {
            ListOfDoors = listOfDoors;
            BadgeID = badgeId;
        }
    }
}
