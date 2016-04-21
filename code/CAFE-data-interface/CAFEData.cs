using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAFEDataInterface
{
    public class CAFEData
    {
        private CAFEDBDataContext myDB;

        public CAFEData()
        {
            myDB = new CAFEDBDataContext("Data Source=TOM-AIR-PC\\SQLEXPRESS;Initial Catalog=CAFE;Integrated Security=True");
        }
        public List<Faculty> facultyList()
        {
            return (from fac in myDB.Faculties select fac).ToList();
        }

        public List<Faculty> searchFaculty(String firstName, String lastName)
        {
            return (from fac in myDB.Faculties where fac.FirstName == firstName 
                       && fac.LastName == lastName select fac).ToList();
        }

        public List<Faculty> searchLastName(String lastName)
        {
            return (from fac in myDB.Faculties where fac.LastName == lastName
                    select fac).ToList();
        }

        public int getTermID (DateTime date)
        {
            return myDB.Terms.Single(t => t.StartDate < date && t.EndDate > date).TermID;
        }

        public Term getTermByName (String semester, String year)
        {
            return myDB.Terms.Single(t => t.Semester == semester && t.Year == year);
        }

        public List<OfficeHour> getOfficeHours(int facultyID, int termID)
        {
            return (from hour in myDB.OfficeHours where hour.FacultyID == facultyID 
                           && hour.TermID == termID select hour).ToList();
        }
    }
}