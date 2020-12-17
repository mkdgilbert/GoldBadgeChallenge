using ChallengeFour_Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_Console
{
    public class OutingRepo
    {
        private readonly List<OutingContent> _outingList = new List<OutingContent>();
        //create
        public void CreateOuting(OutingContent outing)
        {
            _outingList.Add(outing);
        }
        //read
        public List<OutingContent> ListAllOutings()
        {
            return _outingList;
        }
        //update
        public bool UpdateOuting(DateTime oldDate, OutingContent newInfo)
        {
            OutingContent oldOuting = GetOutingByDate(oldDate);
            if (oldOuting != null)
            {
               
                oldOuting.CostPerPerson = newInfo.CostPerPerson;
                oldOuting.Date = newInfo.Date;
                oldOuting.NumberOfPeople = newInfo.NumberOfPeople;
                oldOuting.TypeOfEvent = newInfo.TypeOfEvent;
                return true;
            }
            else
            {
                return false;
            }
        }
        //delete

        //helper
        public OutingContent GetOutingByDate(DateTime eventDate)
        {
            foreach (OutingContent date in _outingList)
            {
                if (date.Date == eventDate)
                {
                    return date;
                }
            }
            return null;
        }
        
    }
}

