using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Managers;
using Server.Data.Models;
using Server.Data.Repositories.Interfaces;
using System.Configuration;
using System.Collections.Generic;
using Server.Data.Test.DataGenerators;

namespace Server.Data.Test.IntegrationTests
{

    [TestClass]
    public class UserRepositoryTest
    {
        private static long _logoId;
        private long _userId;
        private static User _mockUser;
        private static long chartId;

        [TestInitialize]
        public void InitTests()
        {
            _userId = 1;
            if (!(long.TryParse(ConfigurationManager.AppSettings["TestUserId"].ToString(), out _userId)))
                Console.WriteLine("Some Exception occur");
        }

        private void SetUpTestData()
        {
            chartId = (long)DataManager.GetDataManager().CreateInstance<User>(_userId).Add(RandomDataGenerator.GenerateUser()).Id;

            _mockUser = new User()
            {
            
            };

        }

        private IBaseRepository<User> InitializeRepo()
        {
            return DataManager.GetDataManager().CreateInstance<User>(_userId);
        }

        //[TestMethod]
        //public void GetAll()
        //{
        //    IBaseRepository<User> repo = InitializeRepo();
        //    int offsetCount = 0;
        //    int entitiesCount = 10;
        //    var logos = repo.GetProjection(offsetCount, entitiesCount);

        //    logos.Should().NotBeNull();
        //    logos.Count.Should().BeGreaterThan(0);
        //}

        [TestMethod]
        public void Insert()
        {
            SetUpTestData();
            IBaseRepository<User> repo = InitializeRepo();

            _mockUser = repo.Add(_mockUser);

            //_mockLogo.Id.Should().NotBe(0);
            //_mockLogo.Enabled.Should().BeTrue();
            //_mockLogo.ChartId.Should().NotBe(0);
            //_logoId = (long)_mockLogo.Id;
        }

        [TestMethod]
        public void Find()
        {
            IBaseRepository<User> repo = InitializeRepo();

            //User logo = repo.GetProjection(_logoId);

            //logo.Should().NotBeNull();
            //logo.Id.Should().NotBe(0);
            //logo.Enabled.Should().BeTrue();
            //logo.ChartId.Should().NotBe(0);
            //logo.Height.Should().Be(_mockLogo.Height);
            //logo.Width.Should().Be(_mockLogo.Width);
        }

        [TestMethod]
        public void Modify()
        {
            IBaseRepository<User> repo = InitializeRepo();

            //var user = repo.GetProjection(_logoId);

            //logo.Enabled = false;
            //logo.Width = 50;
            //logo.Height = 50;

            //repo.Update(logo);
            //var modifiedUser = repo.GetProjection(_logoId);

            //modifiedZoom.Enabled.Should().BeFalse();
            //modifiedZoom.Height.Should().Be(50);
            //modifiedZoom.Width.Should().Be(50);
        }

        [TestMethod]
        public void Delete()
        {
            IBaseRepository<User> repo = InitializeRepo();

            repo.Remove(_logoId);

            try
            {
                //repo.GetProjection(_logoId);
                Assert.Fail();
            }
            catch (KeyNotFoundException)
            {
                DataManager.GetDataManager().CreateInstance<User>(_userId).Remove(chartId);
            }

        }
    }
}
