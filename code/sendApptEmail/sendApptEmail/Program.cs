using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sendApptEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            String requestorEmail = "gruss001@knights.gannon.edu";
            String requestorDisplayName = "James Gruss";

            String requesteeEmail = "mccracke007@knights.gannon.edu";
            String requesteeDisplayName = "Andrew McCracken";

            //String requesteeEmail = "jgrussjr@gmail.com";
            //String requesteeDisplayName = "Google Gruss";


            DateTime apptStart = DateTime.UtcNow.AddMinutes(+30);
            DateTime apptEnd = DateTime.UtcNow.AddMinutes(+60);
            String location = "The Office";
            String messageBodyProf = "Hello, I would like to meet with you to discuss the upcoming data structures assignment.";
            String messageBodyStudent = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();


            Console.WriteLine(apptStart.ToString());
            Console.WriteLine(apptEnd.ToString());




            emailSender es = new emailSender();

            es.sendICSEmail(requestorEmail, requestorDisplayName, requesteeEmail, requesteeDisplayName,
            apptStart, apptEnd, location, messageBodyProf);
            Console.ReadLine();
        }
    }
}
