using ChallengeOne_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Console
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedMethod();
            Menu();
        }
        
        private MenuMethodRepo _mealRepo = new MenuMethodRepo();
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select a menu option: \n" +
                    "1. Add a new meal to the menu item\n" +
                    "2. Update the menu list\n" +
                    "3. Delete a meal from the menu\n" +
                    "4. View all menu items\n" +
                    "5. exit");
                string asString = Console.ReadLine();
                int input = int.Parse(asString);

                switch (input)
                {
                    case 1:
                        AddMealToMenu();
                        break;
                    case 2:
                        UpdateMenuList();
                        break;
                    case 3:
                        DeleteMealFromMenu();
                        break;
                    case 4:
                        ViewAllMeals();
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using Cafe Express!\n" +
                            "Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Unable to process {0} input", input);
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddMealToMenu()
        {
            Console.Clear();

            MealContent newMeal = new MealContent();
            List<string> listOfIngredients = new List<string>();

            Console.WriteLine("Please enter a meal number");
            string numberString = Console.ReadLine();
            int mealNumber = int.Parse(numberString);
            newMeal.MealNumber = mealNumber;

            Console.WriteLine("Please enter the name of the meal");
            string mealName = Console.ReadLine();
            newMeal.MealName = mealName;

            Console.WriteLine("Please eneter a description of the meal.");
            string mealScript = Console.ReadLine();
            newMeal.Description = mealScript;

        Ingredient:
            Console.WriteLine("Please enter a ingredient.");
            string ingredient = Console.ReadLine();
            listOfIngredients.Add(ingredient);

            Console.WriteLine("Would you like to add another ingredient? yes or no");
            string anotherAnswer = Console.ReadLine();
            if (anotherAnswer == "yes")
            {
                goto Ingredient;
            }

            Console.WriteLine("Please enter the price of the meal");
            decimal mealPrice = Convert.ToDecimal(Console.ReadLine());
            newMeal.Price = mealPrice;

            _mealRepo.AddToMenu(newMeal);

        }
        private void UpdateMenuList()
        {
            Console.Clear();

            MealContent newMeal = new MealContent();
            List<string> listOfIngredients = new List<string>();

            //Display
            ViewAllMeals();

            //Get input
            Console.WriteLine("Please enter the meal name to be updated");
            string oldMeal = Console.ReadLine();

            //Update
            Console.WriteLine("Please enter a meal number");
            string numberString = Console.ReadLine();
            int mealNumber = int.Parse(numberString);
            newMeal.MealNumber = mealNumber;

            Console.WriteLine("Please enter the name of the meal");
            string mealName = Console.ReadLine();
            newMeal.MealName = mealName;


            Console.WriteLine("Please eneter a description of the meal.");
            string mealScript = Console.ReadLine();
            newMeal.Description = mealScript;

        Ingredient:
            Console.WriteLine("Please enter a ingredient.");
            string ingredient = Console.ReadLine();
            listOfIngredients.Add(ingredient);

            Console.WriteLine("Would you like to add another ingredient? yes or no");
            string anotherAnswer = Console.ReadLine();
            if (anotherAnswer == "yes")
            {
                goto Ingredient;
            }

            Console.WriteLine("Please enter the price of the meal");
            decimal mealPrice = Convert.ToInt32(Console.ReadLine());
            newMeal.Price = mealPrice;

            bool wasUpdated = _mealRepo.UpdateExistingMenu(oldMeal, newMeal);
            if (wasUpdated)
            {
                Console.WriteLine("Content was succesfully updated");
            }
            else
            {
                Console.WriteLine("Could not update the content");
            }
        }
        private void DeleteMealFromMenu() 
        {
            ViewAllMeals();

            Console.WriteLine("Please enter the name of meal");
            string mealAnswer = Console.ReadLine();

            bool wasDeleted = _mealRepo.RemoveMealFromList(mealAnswer);
            if (wasDeleted)
            {
                Console.WriteLine("The meal was removed from the menu.");
            }
            else
            {
                Console.WriteLine("The meal could not be removed successfully");
            }
        }
        private void ViewAllMeals()
        {
            List<MealContent> listOfMeals = _mealRepo.DisplayAllMeals();
            foreach (MealContent meal in listOfMeals)
            {
                Console.WriteLine("Meal Number: {0}\n Meal Name {1}", meal.MealNumber, meal.MealName);
            }            
        }
        private void SeedMethod()
        {
            MealContent gyoza = new MealContent(1, "gyoza", "japanese dumpling with pork and veggies", 5.99m, new List<string> {"pork", "green onions", "cornstarch", "sake", "soy sauce", "ginger", "sesame oil"});
            MealContent ramen = new MealContent(2, "Shoyu Ramen", "japanese noodle soup with pork base broth", 8.99m, new List<string> { "pork brother", "egg", "menma", "green onions", "ramen noodles", "pork"});
            MealContent shushi = new MealContent(3, "Rainbow Roll", "raw fish rolled in seedweed paper with steamed rice", 10.99m, new List<string> { "salmon", "seedweed paper", "rice", "sesame seeds", "rice vinegar" });

            
            _mealRepo.AddToMenu(gyoza);
            _mealRepo.AddToMenu(ramen);
            _mealRepo.AddToMenu(shushi);
        }

    }
}
