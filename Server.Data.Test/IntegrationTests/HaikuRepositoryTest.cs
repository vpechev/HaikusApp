using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Server.Data.Models;
using Server.Data.Test.DataGenerators;
using Server.Data.Repositories.Interfaces;
using Server.Data.Managers;
using FluentAssertions;
using System.Collections.Generic;
using Server.Data.Repositories;
using Microsoft.Practices.Unity;

namespace Server.Data.Test.IntegrationTests
{
    [TestClass]
    public class HaikuRepositoryTest
    {
        private string _publishCode;
        private static long _haikuId;
        private static Haiku _mockHaiku;
        private static User _mockUser;
        
        [TestInitialize]
        public void InitTests()
        {
            _publishCode = "some test publish code";
            if (ConfigurationManager.AppSettings["TestPublishCode"] != null)
                _publishCode = ConfigurationManager.AppSettings["TestPublishCode"].ToString();
        }


        private void SetUpTestData()
        {
            _mockUser = new User()
            {
                IsVip = false,
                PublishCode = "some test publish code",
                Username = "vancho"
            };

            _mockUser = DataManager.GetDataManager().CreateInstance<User>().Add(_mockUser);
            _mockHaiku = RandomDataGenerator.GenerateHaiku();
        }
        
        private IBaseRepository<Haiku> InitializeRepo()
        {
            return DataManager.GetDataManager().CreateInstance<Haiku>();
        }

        [TestMethod]
        public void Insert()
        {
            SetUpTestData();
            IBaseRepository<Haiku> repo = InitializeRepo();

            _mockHaiku = repo.Add(_mockHaiku, _mockUser.Id);



            _mockHaiku.Id.Should().NotBe(0);
            _mockHaiku.Text.Should().NotBeNull();
            _mockHaiku.RatersCount.Should().Be(0);
            _mockHaiku.RatingValue.Should().Be(0);
            _mockHaiku.ActualRating.Should().Be(0);
            _haikuId = (long)_mockHaiku.Id;
        }

        [TestMethod]
        public void Find()
        {
            IBaseRepository<Haiku> repo = InitializeRepo();

            Haiku haiku = repo.Get(_haikuId);

            haiku.Should().NotBeNull();
            haiku.Id.Should().NotBe(0);
            haiku.Text.Should().NotBeNull();
        }

        [TestMethod]
        public void GetAll()
        {
            IBaseRepository<Haiku> repo = InitializeRepo();
            IList<Haiku> haikus = repo.Get(10, 5);
            haikus.Should().NotBeNull();
        }

        [TestMethod]
        public void Modify()
        {
            IBaseRepository<Haiku> repo = InitializeRepo();

            var haiku = repo.Get(_haikuId);

            haiku.Text = "some other other new other heiku content";

            var modifiedHaiku = repo.Update(haiku, _mockUser.Id);
            //var modifiedHaiku = repo.Get(_haikuId);

            modifiedHaiku.Should().NotBeNull();
            modifiedHaiku.Id.Should().Be(_haikuId);
            modifiedHaiku.Text.Should().Be(haiku.Text);
        }

        [TestMethod]
        public void RateHaiku()
        {
            IBaseRepository<Haiku> repo = InitializeRepo();

            var haiku = repo.Get(_haikuId);

            var ratedHaiku = ((HaikuRepository)repo).UpdateHaikuRating(_haikuId, 3);

            ratedHaiku.Should().NotBeNull();
            ratedHaiku.Id.Should().Be(_haikuId);
            ratedHaiku.RatersCount.Should().Be(haiku.RatersCount + 1);
            ratedHaiku.RatingValue.Should().Be(haiku.RatingValue + 3);
            ratedHaiku.ActualRating.Should().Be((haiku.RatingValue + 3) / (haiku.RatersCount + 1));

        }

        [TestMethod]
        public void AddComplaint()
        {
            IBaseRepository<Complaint> complaintRepo = DataManager.GetDataManager().CreateInstance<Complaint>();
            Complaint c = complaintRepo.Add(new Complaint()
            {
                HaikuId = _haikuId,
                Date = DateTime.Now
            });

            c.Should().NotBeNull();

            c.HaikuId.Should().Be(_haikuId);
        }

        [TestMethod]
        public void Delete()
        {
            IBaseRepository<Haiku> repo = InitializeRepo();

            repo.Remove(_haikuId);

            try
            {
                repo.Get(_haikuId);
                Assert.Fail();
            }
            catch (KeyNotFoundException) { }

        }
    }
}
