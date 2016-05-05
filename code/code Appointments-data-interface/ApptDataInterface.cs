using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace Appointment
{
    class ApptDataInterface
    {
        [STAThread]
        static void Main()
        {
          
        }
        AppointmentDBDataContext myDB;

        public ApptDataInterface()
        {
            myDB = new AppointmentDBDataContext("Data Source=NAIF-PC\\SQLEXPRESS;Initial Catalog=Appointments;Integrated Security=True");
        }

        public void addRecord()
        {
            appointment newAppt = new appointment();
            newAppt.FacultyID = 109;
            newAppt.FromTime = new DateTime(2016, 4, 28, 8, 0, 0);

            myDB.appointments.InsertOnSubmit(newAppt);

            myDB.SubmitChanges();
        }

        public List<appointment> getAllRecords()
        {
            var query = from appt in myDB.appointments select appt;

            var query2 = from appt in myDB.appointments
                         where
                             appt.FacultyID == 109
                         select appt;

            return query.ToList();
        }


        public void deleteappointment(int facToDelete = 109)
        {
            var deleteappointment =
                from appt in myDB.appointments
                where appt.FacultyID == facToDelete
                select appt;

            foreach (var appt in deleteappointment)
            {
                myDB.appointments.DeleteOnSubmit(appt);
            }
            myDB.SubmitChanges();
        }

        public void updateappointment(int facToUpdate = 109)
        {
            var query =
                from appt in myDB.appointments
                where appt.FacultyID == facToUpdate
                select appt;

        }
        
    }
}

