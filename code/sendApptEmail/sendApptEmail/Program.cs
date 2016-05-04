// This is a demo class for the classes


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
            //String requesteeDisplayName = "Prof JG";

            //String requesteeEmail = "carlin010@knights.gannon.edu";
            //String requesteeDisplayName = "Nate Carlin";


            //String requestorEmail = "jgrussjr@gmail.com";
            //String requestorDisplayName = "Google Gruss";

            //String requesteeEmail = "gruss001@knights.gannon.edu";
            //String requesteeDisplayName = "James Gruss";


            DateTime apptStart = DateTime.UtcNow.AddMinutes(+30);
            String location = "The Office - test";
            String messageBodyProf = "Hello, I would like to meet with you to discuss the upcoming data structures assignment.";
            String messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();



            EmailSender es = new EmailSender();

            //es.sendEmailInvite(requestorEmail, requestorDisplayName, requesteeEmail, requesteeDisplayName,
            //apptStart, location, messageBodyProf, messageBodyStud);

            es.sendEmailInvite(requestorEmail, requestorDisplayName, requesteeEmail, requesteeDisplayName,
            apptStart);


        }
    }
}
