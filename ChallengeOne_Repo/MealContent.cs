using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repo
{
    
    public class MealContent
    {
        
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get ; set; }
        public List<string> ListOfIngredients { get; set; } = new List<string>(); //Will be utilized later on in the CRUD method
        public MealContent() { }
        public MealContent(int mealNumber, string mealName, string description, decimal price,
            List<string> listOfIngredients)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            Description = description;
            Price = price;
            ListOfIngredients = listOfIngredients;
        }
       
    }
}
