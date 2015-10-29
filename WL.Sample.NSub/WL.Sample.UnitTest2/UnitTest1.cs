using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WL.Sample.NSub.JB;

namespace WL.Sample.UnitTest2
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            Hi 
            Calculator cal = new Calculator();
            var expected = 8;
            var actual = cal.Add(5, 3);

            Assert.AreEqual(expected, actual);
        }
    }
}
