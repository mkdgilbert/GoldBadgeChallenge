using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repo
{
    public class MenuMethodRepo
    {
        private readonly List<MealContent> _listOfMeals = new List<MealContent>();

        //Create
        public void AddToMenu(MealContent mealContent)
        {
            _listOfMeals.Add(mealContent);
        }

        //Read
        public List<MealContent> DisplayAllMeals()
        {
            return _listOfMeals;
        }

        //Update
        public bool UpdateExistingMenu(string existingMeal, MealContent updatedMeal)
        {
            MealContent oldMeal = GetMealByName(existingMeal);

            if (oldMeal != null)
            {
                oldMeal.MealName = updatedMeal.MealName;
                oldMeal.MealNumber = updatedMeal.MealNumber;
                oldMeal.Description = updatedMeal.Description;
                oldMeal.Price = updatedMeal.Price;
                oldMeal.ListOfIngredients = updatedMeal.ListOfIngredients;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Delte
        public bool RemoveMealFromList(string meal)
        {
            MealContent mealContent = GetMealByName(meal); 
            if (mealContent == null)
            {
                return false;
            }

            int initialCount = _listOfMeals.Count();
            _listOfMeals.Remove(mealContent);

            if (initialCount > _listOfMeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public MealContent GetMealByName(string mealName)
        {
            foreach (MealContent content in _listOfMeals)
            {
                if (content.MealName.ToLower() == mealName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
    }
}
