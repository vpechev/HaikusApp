using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Managers;
using Server.Data.Models;
using Server.Data.Repositories.Interfaces;
using System.Configuration;
using System.Collections.Generic;
using Server.Data.Test.DataGenerators;
using FluentAssertions;
using Server.Data.Repositories;

namespace Server.Data.Test.IntegrationTests
{

    [TestClass]
    public class UserRepositoryTest
    {
        private string _publishCode;
        private static User _mockUser;
        private static long _userId;

        [TestInitialize]
        public void InitTests()
        {
            _publishCode = "some test publish cod";
            if (ConfigurationManager.AppSettings["TestPublishCode"] != null)
                _publishCode = ConfigurationManager.AppSettings["TestPublishCode"].ToString();
        }

        private void SetUpTestData()
        {
            _mockUser = RandomDataGenerator.GenerateUser();
        }

        private IBaseRepository<User> InitializeRepo()
        {
            return DataManager.GetDataManager().CreateInstance<User>();
        }

        [TestMethod]
        public void GetAll()
        {
            IBaseRepository<User> repo = InitializeRepo();
            int offsetCount = 0;
            int entitiesCount = 10;
            var users = repo.Get(offsetCount, entitiesCount);

            users.Should().NotBeNull();
        }

        [TestMethod]
        public void Insert()
        {
            SetUpTestData();
            IBaseRepository<User> repo = InitializeRepo();

            _mockUser = repo.Add(_mockUser);

            _mockUser.Should().NotBeNull();
            _mockUser.Id.Should().NotBe(0);
            _mockUser.PublishCode.Should().BeNull();
            _userId = (long)_mockUser.Id;
        }

        [TestMethod]
        public void Find()
        {
            IBaseRepository<User> repo = InitializeRepo();

            User user = repo.Get(_userId);

            user.Should().NotBeNull();
            user.Id.Should().NotBe(0);
            user.PublishCode.Should().BeNull();
            user.Username.Should().NotBeNull();
        }

        [TestMethod]
        public void Modify()
        {
            IBaseRepository<User> repo = InitializeRepo();

            var user = repo.Get(_userId);

            string newUsername = "aladin";
            user.Username = newUsername;

            var modifiedUser = repo.Update(user);

            modifiedUser.Username.Should().Be(newUsername);
        }

        [TestMethod]
        public void ChangeVip()
        {
            IBaseRepository<User> repo = InitializeRepo();

            var user = repo.Get(_userId);

            bool newVipStatus = !user.IsVip;

            user.IsVip = newVipStatus;
            ((UserRepository)repo).UpdateToVip(_userId, newVipStatus);

            repo.Get(_userId).IsVip.Should().Be(newVipStatus);
        }

        [TestMethod]
        public void Delete()
        {
            IBaseRepository<User> repo = InitializeRepo();

            repo.Remove(_userId);

            try
            {
                repo.Get(_userId);
                Assert.Fail();
            }
            catch (KeyNotFoundException) { }

        }
    }
}
