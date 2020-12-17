using ChallengeThree_Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Console
{
    class ProgramUI
    {
        public void Run()
        {
            SeedMethod();
            Menu();
        }
        BadgeRepo _badgeRepo = new BadgeRepo();
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning == true)
            {
                Console.WriteLine("Please a select a Menu Option:\n" +
                "1. Create a New Badge.\n" +
                "2. Update a Badge.\n" +
                "3. List all available Badges.\n" +
                "4. Exit application ");

                string inputAsString = Console.ReadLine();
                int userInput = int.Parse(inputAsString);
                switch (userInput)
                {
                    case 1:
                        CreateANewBadge();
                        break;
                    case 2:
                        UpdateExistingBadge();
                        break;
                    case 3:
                        ViewExistingBadges();
                        break;
                    case 4:
                        Console.WriteLine("Goodbye, see you next time.");
                        keepRunning = false;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }

        }
        private void CreateANewBadge()
        {
            BadgeContent newBadge = new BadgeContent();
            List<string> listOfDoors = new List<string>();
            Console.Clear();


            Console.WriteLine("Please enter the ID numbers on the badge.");
            string idAsString = Console.ReadLine();
            int badgeId = int.Parse(idAsString);
            newBadge.BadgeID = badgeId;

        AnotherDoor:
            Console.WriteLine("Please enter the door access number.");
            string doorNum = Console.ReadLine();
            listOfDoors.Add(doorNum);

            Console.WriteLine("Would you like to enter another door: yes/no ");
            string doorAnswer = Console.ReadLine();

            switch (doorAnswer)
            {
                case "yes":
                    goto AnotherDoor;
                case "no":
                    newBadge.ListOfDoors.AddRange(listOfDoors);
                    _badgeRepo.AddBadgeToList(newBadge);
                    break;
                default:
                    Console.WriteLine("The answer {0} was invalid", doorAnswer);
                    break;
            }
        }
        private void ViewExistingBadges()
        {
            Console.Clear();
            Dictionary<int, BadgeContent> dictOfBadges = _badgeRepo.ViewAllBadges();

            foreach (KeyValuePair<int, BadgeContent> badgeKeyValue in dictOfBadges)
            {
                Console.WriteLine("Badge ID {0}:", badgeKeyValue.Key); //displays the badge ID
                ViewListOfDoors(badgeKeyValue.Key);// runs method to list all available doors on badge
            }
        }
        private void UpdateExistingBadge()
        {
            List<string> listOfDoors = new List<string>();


            Console.WriteLine("Here is a list of Badges.");
            ViewExistingBadges();
            //Finding the badge ID 
            Console.WriteLine("Please enter the Badge ID to update.");
            string badgeAsString = Console.ReadLine();
            int badgeID = int.Parse(badgeAsString);
            BadgeContent newInfo = _badgeRepo.GetBadgeById(badgeID);

            Console.Clear();
            Console.WriteLine("Badge {0} has the following assigned doors", badgeID);
            ViewListOfDoors(badgeID);


        Selection:
            Console.WriteLine("Do you want to add or remove a door? " +
                "Format* add or remove");
            string answer = Console.ReadLine();
            if (answer == "add")
            {
            Doors:
                Console.WriteLine("Please enter the door access number.");
                string doorNum = Console.ReadLine();
                listOfDoors.Add(doorNum);

                Console.WriteLine("Would you like to enter another door: yes/no ");
                string doorAnswer = Console.ReadLine();

                switch (doorAnswer)
                {
                    case "yes":
                        goto Doors;
                    case "no":
                        newInfo.ListOfDoors.AddRange(listOfDoors);
                        _badgeRepo.UpdateDoorsOnBadge(badgeID, newInfo);
                        break;
                    default:
                        Console.WriteLine("The answer {0} was invalid", doorAnswer);
                        break;
                }
            }
            else if (answer == "remove")
            {
                DeleteDoorOnBadge(newInfo);
            }
            else
            {
                Console.WriteLine("{0} is not a valid input\n" +
                    "please enter valid input", answer);
                goto Selection;
            }

            bool wasUpdated = _badgeRepo.UpdateDoorsOnBadge(badgeID, newInfo);
            if (wasUpdated)
            {
                Console.WriteLine("The badge doors have been updated successfully");
            }
            else
            {
                Console.WriteLine("Could not update the badge doors");
            }
        }
        /*private void DeleteExistingBadge()
         {

         }*/
        private void DeleteDoorOnBadge(BadgeContent oldInfo)
        {
            Console.WriteLine("Please enter a door to remove from the badge.");
            string input = Console.ReadLine();
            oldInfo.ListOfDoors.Remove(input);
        }
        private void SeedMethod()
        {
            BadgeContent badge1 = new BadgeContent(new List<string> { "a1", "a2", "a3", "b4", "b6" }, 1101);
            BadgeContent badge2 = new BadgeContent(new List<string> { "a2", "a3", "a4" }, 1102);
            BadgeContent badge3 = new BadgeContent(new List<string> { "b3", "b4", "c3" }, 1103);
            BadgeContent badge4 = new BadgeContent(new List<string> { "a1", "a2", "b6" }, 1104);

            _badgeRepo.AddBadgeToList(badge1);
            _badgeRepo.AddBadgeToList(badge2);
            _badgeRepo.AddBadgeToList(badge3);
            _badgeRepo.AddBadgeToList(badge4);

        }
        private void ViewListOfDoors(int doorNum)
        {
            List<string> listOfDoors = _badgeRepo.GetBadgeById(doorNum).ListOfDoors;
            //This step is possible because the return type is a badge basesd on the repo method
            Console.WriteLine("Assigned Doors");
            foreach (string doorName in listOfDoors)
            {
                Console.WriteLine(doorName);
            }
        }
    }
}
