using Claims_Content;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClaimsTesting
{
    [TestClass]
    public class UnitTest1
    {

        private ClaimsProp _content;
        private ClaimsRepo _repo;
        private readonly Queue<ClaimsProp> _queueOfClaims = new Queue<ClaimsProp>();
        //declared here so that it can be initialized each time its called upon

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _content = new ClaimsProp(1, "car collision", 400.00m, new DateTime(2019 / 4 / 18), new DateTime(2019 / 4 / 20), true, ClaimType.Car);

            _repo.AddToClaimsQueue(_content);
        }
        [TestMethod]
        public void AddToClaimsQueue_ShouldNotGetNull()
        {
            //arrange
            ClaimsProp content = new ClaimsProp();
            content.ClaimID = 1;
            ClaimsRepo repository = new ClaimsRepo();

            //act
            repository.AddToClaimsQueue(content);
            ClaimsProp contentFromRepo = repository.GetClaimById(1);

            //Assert
            Assert.IsNotNull(contentFromRepo);
        }

        [TestMethod]
        public void ReadQueue_ShouldReturnQueue()
        {
            Queue<ClaimsProp> claimsProps = _repo.ViewAllClaims();
            int initial = claimsProps.Count;

            int expected = 1;

            Console.WriteLine($"{initial} expected: {expected}");
            Assert.AreEqual(expected, initial);
        }
    }
}

