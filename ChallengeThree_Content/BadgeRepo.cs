using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Content
{
    public class BadgeRepo
    {
        private Dictionary<int, BadgeContent> _badgeDictionary = new Dictionary<int, BadgeContent>();

        //create
        public void AddBadgeToList(BadgeContent badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge);
        }
        //read
        public Dictionary<int, BadgeContent> ViewAllBadges()
        {
            return _badgeDictionary;
        }
        //update
        public bool UpdateDoorsOnBadge(int userInput, BadgeContent newContent)
        {
            BadgeContent oldContent = GetBadgeById(userInput);

            if (oldContent != null)
            {
                oldContent.BadgeID = newContent.BadgeID;
                oldContent.ListOfDoors = newContent.ListOfDoors;
                return true;
            }
            else
            {
                return false;
            }
        }
        //delete
        public bool DeleteExistingBadge(int badgeID)
        {
            BadgeContent oldContent = GetBadgeById(badgeID);


            if (oldContent != null)
            {
                _badgeDictionary.Remove(badgeID);
                return true;
            }
            else
            {
                return false;
            }
        }
        //helper
        public BadgeContent GetBadgeById(int userInput)
        {
            foreach (KeyValuePair<int, BadgeContent> badge in _badgeDictionary)
            {
                int key = badge.Key;
                BadgeContent value = badge.Value;
                if (key == userInput)
                {
                    return value;
                }
            }
            return null;
        }
    }
}
