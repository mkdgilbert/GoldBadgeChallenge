using ChallengeOne_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne
{

    public class ProgramUI
    {
        private MenuMethodRepo _mealContents = new MenuMethodRepo();


        public void Run()
        {
            SeedMealList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select an option from the Menu:\n" +
                    "1. Add a new meal to the menu\n" +
                    "2. Display all meals on the menu\n" +
                    "3. Display a meal by name" +
                    "4. Update an existing meal on the menu\n" +
                    "5. Delete an existing meal from the menu\n" +
                    "6. Exit the program");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewMeal();
                        break;
                    case "2":
                        DisplayAllMeals();
                        break;
                    case "3":
                        DisplayMealByName();
                        break;
                    case "4":
                        UpdateExistingMeal();
                        break;
                    case "5":
                        DeleteAnExistingMeal();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Please press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewMeal()
        {
            Console.Clear();

            MealContent mealContent = new MealContent();
            List<string> listOfIngredients = new List<string>();

            Console.WriteLine("Please enter a number to associate with the meal:\n" +
                "example: 4 or 10 ");
            string numAsString = Console.ReadLine();
            int mealNum = int.Parse(numAsString);
            mealContent.MealNumber = mealNum;

            Console.WriteLine("Please enter a name for the meal: ");
            mealContent.MealName = Console.ReadLine().ToLower();

            Console.WriteLine("Please enter a description of the meal: ");
            mealContent.Description = Console.ReadLine();

            Console.WriteLine("Please enter a price for the meal:\n" +
                "example: 12.99");
            string doubleAsString = Console.ReadLine();
            double dubNum = double.Parse(doubleAsString);
            mealContent.Price = dubNum;

        IngredientList:
            Console.WriteLine("Please enter an ingredient: ");
            string ingredients = Console.ReadLine();
            listOfIngredients.Add(ingredients);

            Console.WriteLine("Would you like to add another ingredient? yes or no:");
            string ingreAnswer = Console.ReadLine();

            switch (ingreAnswer)
            {
                case "yes":
                    goto IngredientList;
                case "no":
                    mealContent.ListOfIngredients.AddRange(listOfIngredients);
                    _mealContents.AddToMenu(mealContent);
                    break;
                default:
                    break;
            }
        }
        private void DisplayAllMeals()
        {
            Console.Clear();

            List<MealContent> listOfMeals = _mealContents.DisplayAllMeals();
            foreach (MealContent meal in listOfMeals)
            {
                Console.WriteLine($"Name: {meal.MealName}\n" +
                    $"Description: {meal.Description}");
            }
        }
        private void DisplayMealByName()
        {
            Console.Clear();

            Console.WriteLine("Please enter the name of a meal: ");
            string mealName = Console.ReadLine().ToLower();

            MealContent content = _mealContents.GetMealByName(mealName);

            if (content != null)
            {
                Console.WriteLine($"Name: {content.MealName}\n" +
                    $"MealNumber: {content.MealNumber}\n" +
                    $"Description: {content.Description}\n" +
                    $"Price: {content.Price}\n" +
                    $"Ingredients: {content.ListOfIngredients}");
            }
            else
            {
                Console.WriteLine("Could not find the meal by that name");
            }

        }
        private void UpdateExistingMeal()
        {
            Console.Clear();
            List<string> listOfIngredients = new List<string>();

            DisplayAllMeals();

            Console.WriteLine("Please enter the name of a meal to update");
            string oldMeal = Console.ReadLine();

            MealContent mealContent = new MealContent();

            Console.WriteLine("Please enter a number to associate with the meal:\n" +
                "example: 4 or 10 ");
            string numAsString = Console.ReadLine();
            int mealNum = int.Parse(numAsString);
            mealContent.MealNumber = mealNum;

            Console.WriteLine("Please enter a name for the meal: ");
            mealContent.MealName = Console.ReadLine().ToLower();

            Console.WriteLine("Please enter a description of the meal: ");
            mealContent.Description = Console.ReadLine();

            Console.WriteLine("Please enter a price for the meal:\n" +
                "example: 12.99");
            string doubleAsString = Console.ReadLine();
            double dubNum = double.Parse(doubleAsString);
            mealContent.Price = dubNum;

        Ingredient:
            Console.WriteLine("Please enter an ingredients: ");
            string ingredients = Console.ReadLine();
            listOfIngredients.Add(ingredients);

            Console.WriteLine("Would you like to add another ingredient? yes or no:");
            string ingreAnswer = Console.ReadLine();

            switch (ingreAnswer)
            {
                case "yes":
                    goto Ingredient;
                case "no":
                    mealContent.ListOfIngredients.AddRange(listOfIngredients);
                    _mealContents.AddToMenu(mealContent);
                    break;
                default:
                    break;
            }

            bool wasUpdated = _mealContents.UpdateExistingMenu(oldMeal, mealContent);

            if (wasUpdated)
            {
                Console.WriteLine("The meal was successfully updated.");
            }
            else
            {
                Console.WriteLine("Could not update the meal");
            }
        }
        public void DeleteAnExistingMeal()
        {
            DisplayAllMeals();

            Console.WriteLine("Please enter a meal to be removed: ");
            string mealName = Console.ReadLine().ToLower();

            bool wasDeleted = _mealContents.RemoveMealFromList(mealName);

            if (wasDeleted)
            {
                Console.WriteLine("The meal was deleted successfully");
            }
            else
            {
                Console.WriteLine("Could not remove the meal");
            }
        }

        private void SeedMealList()
        {
            MealContent gyoza = new MealContent(1, "gyoza"
                , "pork dumpling thats seared"
                , 5.99
                , new List<string> { "pork", "onions", "cabbage", "sake", "baking powder", "dumpling wrapper" });
            MealContent shumai = new MealContent(2, "shumai"
                , "shrimp based dumpling"
                , 5.99
                , new List<string> { "shrimp", "onion", "cabbage", "mushroom", "sake", "ginger", "dumpling wrapper" });
            MealContent ramen = new MealContent(3, "ramen"
                , "pork based noodle soup dish"
                , 8.99
                , new List<string> { "noodles", "pork broth", "wakame", "egg", "green onions", "chashu", "menma", "kamaboko" });
            MealContent ramune = new MealContent(4, "ramune"
                , "fruit flavored pop drink"
                , 3.99
                , new List<string> { "sugar", "artificial flavor", "carbonation" });

            _mealContents.AddToMenu(gyoza);
            _mealContents.AddToMenu(ramune);
            _mealContents.AddToMenu(ramen);
            _mealContents.AddToMenu(shumai);
        }
    }
}
