using ChallengeFour_Console;
using ChallengeFour_Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour_Program
{
    class ProgramUI
    {
        public void Run()
        {
            SeedMethod();
            Menu();
        }
        OutingRepo _outingRepo = new OutingRepo();
        OutingContent _outingContent = new OutingContent();
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select a menu option:\n" +
                    "1. Display all Outings.\n" +
                    "2. Add outing to outing list.\n" +
                    "3. Display total cost for outings\n" +
                    "4. Display total cost by event type.\n" +
                    "5. Exit application.");
                string inputAsString = Console.ReadLine();
                int userSelection = int.Parse(inputAsString);

                switch (userSelection)
                {
                    case 1:
                        DisplayOutings();
                        break;
                    case 2:
                        AddToList();
                        break;
                    case 3:
                        ViewAllOutingCost();
                        break;
                    case 4:
                        ViewEventTypeCost();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using Outing services\n GoodBye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Unable to process {0} selection\n Please try again", userSelection);
                        break;
                }
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void DisplayOutings()
        {
            Console.Clear();

            List<OutingContent> outings = _outingRepo.ListAllOutings();
            foreach (OutingContent events in outings)
            {
                Console.WriteLine($"Event Type: {events.TypeOfEvent}\n" +
                    $"Event Date: {events.Date}\n" +
                    $"Event Cost: {events.CostOfEvent}");
            }
        }
        private void AddToList()
        {
            Console.Clear();

            OutingContent newOuting = new OutingContent();

            Console.WriteLine("Please enter the number of people attending:");
            string intAsString = Console.ReadLine();
            int peopleNum = int.Parse(intAsString);
            newOuting.NumberOfPeople = peopleNum;

            Console.WriteLine("Please enter the cost per person:");
            string personString = Console.ReadLine();
            decimal personDec = decimal.Parse(personString);
            newOuting.CostPerPerson = personDec;

            Console.WriteLine("Please enter the date of the event:");
            string dateAsString = Console.ReadLine();
            DateTime actualDate = DateTime.Parse(dateAsString);
            newOuting.Date = actualDate;

            Console.WriteLine("Please enter the number for the type of event:\n " +
                "1 = Golf\n 2 = Amusement Park\n 3 = Concert");
            string typeAsString = Console.ReadLine();
            int eventType = int.Parse(typeAsString);
            newOuting.TypeOfEvent = (EventType)eventType;

            _outingRepo.CreateOuting(newOuting);
        }
        private void ViewAllOutingCost()
        {
            List<decimal> listOfOutingCost = new List<decimal>();

            List<OutingContent> outingContents = _outingRepo.ListAllOutings();
            foreach (OutingContent outing in outingContents)
            {
                decimal allCosts = outing.CostOfEvent;
                listOfOutingCost.Add(allCosts);
            }
            decimal allOutingCosts = listOfOutingCost.Sum();

            Console.WriteLine(allOutingCosts);
        }
        private void ViewEventTypeCost()
        {
            List<decimal> listOfAllTypeCost = new List<decimal>();

            Console.WriteLine("Please enter the number for the event type:\n" +
                "1. Golf\n" +
                "2. AmusementPark\n " +
                "3. Concert");
            string typAsString = Console.ReadLine();
            int typeInt = int.Parse(typAsString);
            EventType type = (EventType)typeInt;

            List<OutingContent> outingContents = _outingRepo.ListAllOutings();
            foreach (OutingContent outings in outingContents)
            {
                if (outings.TypeOfEvent == type)
                {
                    decimal eventCost = outings.CostOfEvent;
                    listOfAllTypeCost.Add(eventCost);
                }
            }
            decimal allCost = listOfAllTypeCost.Sum();

            Console.WriteLine(allCost);
        }
        private void SeedMethod()
        {
            OutingContent topGolf = new OutingContent(3, 15.99m, new DateTime(3 / 10 / 2020), (EventType.Golf));
            OutingContent circleGolf = new OutingContent(4, 16.99m, new DateTime(4 / 20 / 2020), (EventType.Golf));
            OutingContent sixFlags = new OutingContent(5, 25.99m, new DateTime(7 / 10 / 2020), (EventType.AmusementPark));
            OutingContent lupeFiasco = new OutingContent(7, 35.99m, new DateTime(11 / 10 / 2020), (EventType.Concert));

            _outingRepo.CreateOuting(sixFlags);
            _outingRepo.CreateOuting(lupeFiasco);
            _outingRepo.CreateOuting(topGolf);
            _outingRepo.CreateOuting(circleGolf);
        }
    }
}

