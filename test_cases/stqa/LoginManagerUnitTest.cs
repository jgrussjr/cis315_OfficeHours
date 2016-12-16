using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAFEDataInterface.Tests
{
    [TestClass]
    public class LoginManagerUnitTest
    {

        // CreateNewUser()
        [TestMethod]
        public void createDupeUser_1()
        {
            LoginManager test = new LoginManager();
            Assert.AreNotEqual(test.createNewUser("James", "Gruss", "gruss001@knights.gannon.edu", "gruss001"), "true");
        }

        [TestMethod]

        public void createNewUser_2()
        {
            LoginManager test = new LoginManager();
            Assert.AreEqual(test.createNewUser("James5", "Gruss5", "gruss005@knights.gannon.edu", "gruss005"), "true");
        }

        [TestMethod]
        public void createNewLongEmail_3()
        {
            String longEmail = "lucifer00666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666@gannon.edu";
            LoginManager test = new LoginManager();
            Assert.AreEqual(test.createNewUser("Lucifer", "LuciferLast", longEmail, "lucifer006"), "true");
        }
        [TestMethod]
        public void createNewLongPass_4()
        {
            String longPass = "666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666";
            LoginManager test = new LoginManager();
            Assert.AreEqual(test.createNewUser("Nate", "Carlin", "carlin999@knights.gannon.edu", longPass), "true");
        }

        [TestMethod]
        public void createNewUserBlankEmail_5()
        {
            LoginManager test = new LoginManager();
            Assert.AreNotEqual(test.createNewUser("James6", "Gruss6", "", "gruss006"), "true");
        }

        [TestMethod]
        public void createNewUserBlankPass_6()
        {
            LoginManager test = new LoginManager();
            Assert.AreNotEqual(test.createNewUser("James7", "Gruss7", "gruss007@knights.gannon.edu", ""), "true");
        }

        [TestMethod]
        public void createNewUserBlankPassEmail_7()
        {
            LoginManager test = new LoginManager();
            Assert.AreNotEqual(test.createNewUser("James8", "Gruss8", "", ""), "true");
        }


        // checkPassword()

        [TestMethod]
        public void checkPasswordExistUserGoodPass_1()
        {
            LoginManager test = new LoginManager();
            Assert.IsTrue(test.checkPassword("gruss001@knights.gannon.edu", "gruss001"));
        }

        [TestMethod]
        public void checkPasswordExistUserBadPass_2()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.checkPassword("gruss001@knights.gannon.edu", "gruss002"));
        }

        [TestMethod]
        public void checkPasswordNonExistUser_3()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.checkPassword("gruss002@knights.gannon.edu", "gruss002"));
        }

        [TestMethod]
        public void checkPasswordNonExistUserGoodPass_4()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.checkPassword("gruss002@knights.gannon.edu", "gruss001"));
        }

        [TestMethod]
        public void checkPasswordExistUserBlankPass_5()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.checkPassword("gruss001@knights.gannon.edu", ""));
        }

        [TestMethod]
        public void checkPasswordNonExistUserBlankPass_5()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.checkPassword("gruss002@knights.gannon.edu", ""));
        }

        [TestMethod]
        public void checkPasswordBlankEmailBlankPass_6()
        {
            LoginManager test = new LoginManager();
            Assert.IsFalse(test.checkPassword("", ""));
        }


    }
}
