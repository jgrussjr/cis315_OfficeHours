using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAFEDataInterface.Tests
{
    [TestClass]
    public class LoginManagerUnitTest
    {

        [TestMethod]
        public void createUser()
        {
            LoginManager test = new LoginManager();
            Assert.IsTrue(test.createNewUser("Tom", "Dylewski", "dylewski004@knights.gannon.edu", "testpw"));
        }

        [TestMethod]

        public void createDupeUser()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.createNewUser("Fred", "Dylewski", "dylewski004@knights.gannon.edu", "fredrules"));
        }

        [TestMethod]

        public void checkPassGood()
        {
            LoginManager test = new LoginManager();
            Assert.IsTrue(test.checkPassword("dylewski004@knights.gannon.edu", "testpw"));
        }

        [TestMethod]
        public void checkPassFail()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.checkPassword("dylewski004@knights.gannon.edu", "badpassword"));
        }

        [TestMethod]

        public void deleteUser()
        {
            LoginManager test = new LoginManager();
            Assert.IsTrue(test.deleteUser("dylewski004@knights.gannon.edu"));
        }

        [TestMethod]

        public void deleteNonExistentUser()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.deleteUser("fred@knights.gannon.edu"));
        }
    }
}
