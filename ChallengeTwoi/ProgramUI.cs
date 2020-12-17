using Claims_Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    class ProgramUI
    {
        public void Run()
        {
            SeedListMethod();
            Menu();
        }
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Menu()
        {
        Start:
            Console.WriteLine("Please select a option:\n" +
                "1. See all available claims.\n" +
                "2. Proceed with next claim.\n" +
                "3. Enter a new claim.\n" +
                "4. Exit applicationl");
            string input = Console.ReadLine().ToLower();
            int userChoice = int.Parse(input);

            switch (userChoice)
            {
                case 1:
                    SeeAllClaims();
                    break;
                case 2:
                    TakeNextClaim();
                    break;
                case 3:
                    EnterNewClaim();
                    break;
                case 4:
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("{0} is not a valid input.\n" +
                        "Please enter a valid number.", userChoice);
                    goto Start;
            }


        SecondDecision:
            Console.WriteLine("Do you want to continue? yes or no");
            string userAnswer = Console.ReadLine().ToLower();
            switch (userAnswer)
            {
                case "yes":
                    goto Start;
                case "no":
                    break;
                default:
                    Console.WriteLine("Your choice {0} is invalid.\n" +
                        "Please try again.", userAnswer);
                    goto SecondDecision;
            }
            Console.Clear();

        }

        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<ClaimsProp> queueOfClaims = _claimsRepo.ViewAllClaims();

            foreach (ClaimsProp claims in queueOfClaims)
            {
                Console.WriteLine($"Claim ID: {claims.ClaimID}\n" +
                    $"Claims Description: {claims.Description}\n" +
                    $"Claims Date: {claims.DateOfClaim}\n" +
                    $"Claim Amount: {claims.ClaimAmount:c}\n" +
                    $"Validation: {claims.IsValid}\n" +
                    $"Claim Type: {claims.TypeOfClaim}");
            }
        }
        private void TakeNextClaim()
        {
            Console.Clear();

            Queue<ClaimsProp> queueItem = _claimsRepo.ViewAllClaims();
            ClaimsProp claimItem = queueItem.Peek();

            Console.WriteLine($"Claim ID: {claimItem.ClaimID}\n" +
                    $"Claims Description: {claimItem.Description}\n" +
                    $"Claims Date: {claimItem.DateOfClaim}\n" +
                    $"Claim Amount: {claimItem.ClaimAmount:c}\n" +
                    $"Validation: {claimItem.IsValid}\n" +
                    $"Claim Type: {claimItem.TypeOfClaim}");

            Console.WriteLine("Do you want to process this claim now? (yes or no)");
            string result = Console.ReadLine().ToLower();
            if (result == "y")
            {
                queueItem.Dequeue();
                Console.Clear();
                Console.WriteLine("Claim removed from queue.");
            }
            else
            {
                Menu();
            }
        }
        private void EnterNewClaim()
        {
            Console.Clear();

            ClaimsProp newClaim = new ClaimsProp();

            Console.WriteLine("Please enter the claim description. ");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Please enter the claim type number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string claimAsString = Console.ReadLine();
            int claimAsInt = int.Parse(claimAsString);
            newClaim.TypeOfClaim = (ClaimType)claimAsInt;
            //must cast () for claimtype to populate

            Console.WriteLine("Please enter the claim amount. ");
            string dubAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(dubAsString);

            Console.WriteLine("Please enter date of accident.\n " +
                "Format: year/month/day");
            string dateAsString = Console.ReadLine();
            DateTime incidentDate = DateTime.Parse(dateAsString);
            newClaim.DateOfIncident = incidentDate;

            Console.WriteLine("Please enter the date of the claim.\n" +
                "Format: year/month/day");
            string dateString = Console.ReadLine();
            DateTime claimDate = DateTime.Parse(dateString);
            newClaim.DateOfClaim = claimDate;

            TimeSpan result = claimDate.Subtract(incidentDate);// best way to subtract after testing multiple techniques
            if (result.Days <= 30 && result.Days >= 1)
            {
                Console.WriteLine("This claim is valid");
                newClaim.IsValid = true;
            }
            else
            {
                Console.WriteLine("This claim is not valid");
                newClaim.IsValid = false;
            }

            _claimsRepo.AddToClaimsQueue(newClaim);

        }
        private void SeedListMethod()
        {
            ClaimsProp claimOne = new ClaimsProp(1, "car accident on 465", 400.00m, new DateTime(4 / 25 / 18), new DateTime(4 / 27 / 18), true, ClaimType.Car);
            ClaimsProp claimTwo = new ClaimsProp(2, "house fire in kitchen", 4000.00m, new DateTime(4 / 11 / 18), new DateTime(4 / 12 / 18), true, ClaimType.Home);
            ClaimsProp claimThree = new ClaimsProp(3, "stolen pancakes", 4.00m, new DateTime(4 / 27 / 18), new DateTime(6 / 01 / 18), false, ClaimType.Theft);

            _claimsRepo.AddToClaimsQueue(claimOne);
            _claimsRepo.AddToClaimsQueue(claimTwo);
            _claimsRepo.AddToClaimsQueue(claimThree);
        }
    }
}
