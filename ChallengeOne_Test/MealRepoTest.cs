using System;
using System.Collections.Generic;
using ChallengeOne_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOne_Test
{
    [TestClass]
    public class MealRepoTest
    {
        private MealContent _mealContent;
        private MenuMethodRepo _repo; 

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuMethodRepo();
            _mealContent = new MealContent(5, "gyoza", "pork based dumpling", 5.99m, 
                new List<string> {"gyoza", "onion"});

            _repo.AddToMenu(_mealContent);
        }

        [TestMethod]
        public void AddToList_ShouldNotGetNull()
        {
            MealContent content = new MealContent();
            content.MealName = "Gyoza";
            MenuMethodRepo repository = new MenuMethodRepo();

            repository.AddToMenu(content);
            MealContent contentFromDirectory = repository.GetMealByName("Gyoza");

            Assert.IsNotNull(contentFromDirectory);
        }

        [TestMethod]
        public void UpdateToList_ShouldReturnTrue()
        {
            //Arrange


            //TestInitialize
            MealContent newContent = new MealContent(5, "Gyoza",
                "is a pork based dumpling with vegetable steamed and finished off with a sear",
                5.99m, new List<string> {"gyoza", "onion"});

            //Act
            bool updateResult = _repo.UpdateExistingMenu("gyoza", newContent);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("Gyoza", true)]
        [DataRow("Shumai", false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalMeal, bool shouldUpdate)
        {
            //TestInitialize
            MealContent newContent = new MealContent(5, "Gyoza",
                "is a pork based dumpling with vegetable steamed and finished off with a sear",
                5.99m, new List<string> { "gyoza", "onion" });

            //Act
            bool updateResult = _repo.UpdateExistingMenu(originalMeal, newContent);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange


            //Act
            bool deleteResult = _repo.RemoveMealFromList(_mealContent.MealName);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
