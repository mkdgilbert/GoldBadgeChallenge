using ChallengeThree_Content;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree_Testing
{
    [TestClass]
    public class ChallengeThreeTest
    {
        private BadgeContent _content;
        private BadgeRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _content = new BadgeContent(new List<string> { "a1", "a2", "a3" }, 1102);
        }

        [TestMethod]
        public void AddToMenuTest_ShouldBeNotNull()
        {
            BadgeContent content = new BadgeContent();
            content.BadgeID = 1102;

            BadgeRepo repo = new BadgeRepo();

            repo.AddBadgeToList(content);
            BadgeContent directory = repo.GetBadgeById(1101);

            Assert.IsNotNull(directory);
        }
        public void UpdateDoorsOnBadge()
        {
            BadgeContent newContent = new BadgeContent(new List<string> { "a2", "a4", "a5", "a7" }, 1101);

            bool updateResult = _repo.UpdateDoorsOnBadge(1101, newContent);

            Assert.IsTrue(updateResult);
        }

        public void DeleteExistingBadge_ShouldNotBeBool()
        {
            BadgeContent newBadge = new BadgeContent(new List<string> { "a1", "a3" }, 1103);

            bool wasDeleted = _repo.DeleteExistingBadge(1103);

            Assert.IsTrue(wasDeleted);
        }
    }
}
