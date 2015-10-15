using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Diagnostics;
using WL.Sample.NSub.Model;
using WL.Sample.NSub.DAL;
using WL.Sample.NSub.Service;

namespace WL.Sample.NSub.UnitTest
{
    [TestClass]
    public class UnitTestSample
    {
        private List<User> myUsers = null;
        private IDalRepository dalRepository = null;

        private AgeStcService stService = null;


        public UnitTestSample()
        {
            myUsers = new List<User>() {
                new User {Level=8, Age=20 },
                new User {Level=8, Age=30 },
                new User {Level=11, Age=40 },
                new User {Level=13, Age=50 },
                new User {Level=20, Age=60 } };

            this.dalRepository = Substitute.For<IDalRepository>();

            stService = new AgeStcService();
            stService.DalRepository = this.dalRepository;

        }

        [TestMethod]
        public void TestAll()
        {
            this.dalRepository.GetAll().Returns(myUsers);

            int expectedAvg = 40;
            int actualAvg = stService.CompanyAverageAge;
            Assert.AreEqual(expectedAvg, actualAvg);

            int expectedMax = 60;
            int actualMax = stService.CompanyMaxAge;
            Assert.AreEqual(expectedMax, actualMax);

            int expectedMin = 20;
            int actualMin = stService.CompanyMinAge;
            Assert.AreEqual(expectedMin, actualMin);

        }


        [TestMethod]
        public void TestSupervisor()
        {
            var supervisorUsers = myUsers.Where(x => x.Level >= 10).ToList();

            this.dalRepository.GetSupervisors(Arg.Is<int>(x => x >= 10)).Returns(
                supervisorUsers);

            int expectedAvg = 50;
            int actualAvg = stService.SupervisorAverageAge;
            Assert.AreEqual(expectedAvg, actualAvg);

            int expectedMax = 60;
            int actualMax = stService.SupervisorMaxAge;
            Assert.AreEqual(expectedMax, actualMax);

            int expectedMin = 40;
            int actualMin = stService.SupervisorMinAge;
            Assert.AreEqual(expectedMin, actualMin);

        }


        [TestMethod]
        public void TestSpecificLevel()
        {
            int level = 8;

            this.dalRepository.GetUsersOfLevel(Arg.Is<int>(x => x == level)).Returns(
                myUsers.Where(x => x.Level == level).ToList());




            int expectedAvg = 25;
            int actualAvg = stService.GetAverageAgeOfLevel(level);
            Assert.AreEqual(expectedAvg, actualAvg);

            int expectedMax = 30;
            int actualMax = stService.GetMaxAgeOfLevel(level);
            Assert.AreEqual(expectedMax, actualMax);

            int expectedMin = 20;
            int actualMin = stService.GetMinAgeOfLevel(level);
            Assert.AreEqual(expectedMin, actualMin);
        }


    }
}
