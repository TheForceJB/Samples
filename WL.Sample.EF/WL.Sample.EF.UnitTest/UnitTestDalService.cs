using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using NSubstitute;
using System.Collections.Generic;
using System.Data.Entity;
using WL.Sample.EF.DAL.Model;
using WL.Sample.EF.DAL.Service;
using System.Linq;

namespace WL.Sample.EF.UnitTest
{
    [TestClass]
    public class UnitTestDalService
    {

        [TestMethod]
        public void TestGetWithRealData()
        {
            //using (var dalService = new WL.Sample.EF.Service.DalService())
            //{
            //    var entities = dalService.Get(x=>x.Name.ToString().StartsWith("A"));
            //    foreach(var entity in entities)
            //    {
            //        Debug.WriteLine(String.Format("Name:{0}, Department:{1}", entity.Name, entity.Department.Name));
            //    }

            //}
        }

        [TestMethod]
        public void TestGetWithNSub()
        {
            var rtnForGetAll = new List<User>()
            {
                new User() { Name="Amigo", DepartmentId=1, Department=new Department() { Name="開發二課"} },
                new User() { Name="Ariel", DepartmentId=1, Department=new Department() { Name="開發一課"} },
                new User() { Name="Frank", DepartmentId=1, Department=new Department() { Name="開發一課"} }
            };

            IDalService dalService = Substitute.For<IDalService>();
            dalService.GetAll().Returns(rtnForGetAll.AsEnumerable());

            var entities = dalService.GetAll();
            foreach (var entity in entities)
            {
                Debug.WriteLine(String.Format("Name:{0}, Department:{1}", entity.Name, entity.Department.Name));
            }

            Debug.WriteLine("Finish");
            //The real test here ....
        }
    }
}
