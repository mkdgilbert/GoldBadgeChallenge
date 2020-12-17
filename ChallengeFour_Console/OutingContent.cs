using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_Content
{
    public enum EventType
    {
        Golf = 1,
        AmusementPark,
        Concert
    }
    public class OutingContent
    {
        public int NumberOfPeople { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent 
        {
            get
            { return CalculateEventCost(); }
        }

        public DateTime Date { get; set; }
        public EventType TypeOfEvent { get; set; }

        public OutingContent() { }
        public OutingContent(int numberOfPeople, decimal costPerPerson, DateTime date, EventType typeOfEvent)
        {
            NumberOfPeople = numberOfPeople;
            CostPerPerson = costPerPerson;
            //CostOfEvent = costOfEvent; 
            //must be removed when is readonly
            Date = date;
            TypeOfEvent = typeOfEvent;
        }
        public decimal CalculateEventCost()
        {
            return (NumberOfPeople * CostPerPerson);
        }
    }
}
