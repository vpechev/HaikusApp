using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Server.Data.Managers;
using Server.Data.Models;
using Server.Data.Repositories.Interfaces;
using Server.Data.Test.DataGenerators;
using FluentAssertions;

namespace Server.Data.Test.IntegrationTests
{
    [TestClass]
    public class ComplaintRepositoryTest
    {
        //private string _publishCode;
        private static Complaint _mockComplaint;
        private static long _mockComplaintId;

        [TestInitialize]
        public void InitTests()
        {
            //_publishCode = "some test publish cod";
            //if (ConfigurationManager.AppSettings["TestPublishCode"] != null)
            //    _publishCode = ConfigurationManager.AppSettings["TestPublishCode"].ToString();
        }

        private void SetUpTestData()
        {
            long haikuId = DataManager.GetDataManager().CreateInstance<Haiku>().Add(RandomDataGenerator.GenerateHaiku(), 1).Id;
            _mockComplaint = new Complaint()
            {
                Date = DateTime.Now,
                HaikuId = haikuId
            };
        }

        private IBaseRepository<Complaint> InitializeRepo()
        {
            return DataManager.GetDataManager().CreateInstance<Complaint>();
        }

        [TestMethod]
        public void GetAll()
        {
            IBaseRepository<Complaint> repo = InitializeRepo();
            int offsetCount = 0;
            int entitiesCount = 10;
            var complaints = repo.Get(offsetCount, entitiesCount);

            complaints.Should().NotBeNull();
        }

        [TestMethod]
        public void Insert()
        {
            SetUpTestData();
            IBaseRepository<Complaint> repo = InitializeRepo();

            _mockComplaint = repo.Add(_mockComplaint);

            _mockComplaint.Should().NotBeNull();
            _mockComplaint.Id.Should().NotBe(0);
            _mockComplaint.HaikuId.Should().BeGreaterThan(0);
            _mockComplaintId = (long)_mockComplaint.Id;
        }
        
    }
}
