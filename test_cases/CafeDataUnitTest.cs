using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CAFEDataInterface;

namespace CAFEDataInterface.Tests
{
    [TestClass]
    public class CafeDataUnitTest
    {
        [TestMethod]
        public void FacultyCountCorrect()
        {
            CAFEData test = new CAFEData();
            int count = test.facultyList().Count;
            Assert.AreEqual(146, count);
        }

        [TestMethod]

        public void CheckBrinkmanHours()
        {
            CAFEData test = new CAFEData();
            List<Faculty> facList = test.searchFaculty("Barry", "Brinkman");
            Assert.AreEqual(1, facList.Count);
            int facID = facList[0].FacultyID;
            Assert.AreEqual(109, facID);
            int termID = test.getTermID(new DateTime(2010, 4, 12));
            Assert.AreEqual(8, termID);
            List<OfficeHour> hourList = test.getOfficeHours(facID, termID);
            Assert.AreEqual(4, hourList.Count);
            Assert.AreEqual("Monday", hourList[0].Day);
            Assert.AreEqual(15, hourList[0].FromTime.Hour);
            Assert.AreEqual(0, hourList[0].FromTime.Minute);
            Assert.AreEqual(17, hourList[0].ToTime.Hour);
            Assert.AreEqual(0, hourList[0].ToTime.Minute);
            Assert.AreEqual("Thursday", hourList[1].Day);
            Assert.AreEqual(13, hourList[1].FromTime.Hour);
            Assert.AreEqual(0, hourList[1].FromTime.Minute);
            Assert.AreEqual(15, hourList[1].ToTime.Hour);
            Assert.AreEqual(0, hourList[1].ToTime.Minute);
            Assert.AreEqual("Friday", hourList[2].Day);
            Assert.AreEqual(9, hourList[2].FromTime.Hour);
            Assert.AreEqual(0, hourList[2].FromTime.Minute);
            Assert.AreEqual(10, hourList[2].ToTime.Hour);
            Assert.AreEqual(0, hourList[2].ToTime.Minute);
            Assert.AreEqual("Friday", hourList[3].Day);
            Assert.AreEqual(13, hourList[3].FromTime.Hour);
            Assert.AreEqual(30, hourList[3].FromTime.Minute);
            Assert.AreEqual(14, hourList[3].ToTime.Hour);
            Assert.AreEqual(30, hourList[3].ToTime.Minute);
        }

        [TestMethod]
        public void noHoursFrankBogacki()
        {
            CAFEData test = new CAFEData();
            List<Faculty> facList = test.searchFaculty("Frank", "Bogacki");
            Assert.AreEqual(1, facList.Count);
            int facID = facList[0].FacultyID;
            int termID = test.getTermID(new DateTime(2010, 4, 12));
            Assert.AreEqual(8, termID);
            Assert.AreEqual(0, test.getOfficeHours(facID, termID).Count);
        }

        [TestMethod]

        public void howManyGustafson()
        {
            CAFEData test = new CAFEData();
            Assert.AreEqual(2, test.searchLastName("Gustafson").Count);
        }

        [TestMethod]

        public void checkTermStartEnd()
        {
            CAFEData test = new CAFEData();
            Term testTerm = test.getTermByName("Spring", "2010");
            Assert.AreEqual(8, testTerm.TermID);
            Assert.AreEqual(1, testTerm.StartDate.Month);
            Assert.AreEqual(11, testTerm.StartDate.Day);
            Assert.AreEqual(2010, testTerm.StartDate.Year);
            Assert.AreEqual(5, testTerm.EndDate.Month);
            Assert.AreEqual(6, testTerm.EndDate.Day);
            Assert.AreEqual(2010, testTerm.EndDate.Year);
        }

        [TestMethod]

        public void getMaryCraneEmail()
        {
            CAFEData test = new CAFEData();
            Assert.AreEqual("CRANE003@gannon.edu", test.searchFaculty("Mary", "Crane")[0].Email);
        }
    }
}
