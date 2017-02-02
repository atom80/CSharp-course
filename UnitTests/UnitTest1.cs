using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagerCore;

namespace UnitTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            Storage storage = new Storage();
            Assert.AreEqual(0, storage.ListUsers().Count);
            storage.Load();
            Assert.AreNotEqual(0, storage.ListUsers().Count);
            //Assert.Fail("Oops");
            
        }
    }
}
