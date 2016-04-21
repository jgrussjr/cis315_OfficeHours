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

            //String requesteeEmail = "mccracke007@knights.gannon.edu";
            //String requesteeDisplayName = "Andrew McCracken";

            String requesteeEmail = "jgrussjr@gmail.com";
            String requesteeDisplayName = "Google Gruss";


            DateTime apptStart = DateTime.UtcNow.AddMinutes(+30);
            DateTime apptEnd = DateTime.UtcNow.AddMinutes(+60);
            //String location = "The Office";
            //String mailCCAddress = null;
            //String mailCCDisplayName = null; 
            //String mailServerIP = null;

            Console.WriteLine(apptStart.ToString());
            Console.WriteLine(apptEnd.ToString());




            emailSender es = new emailSender(requestorEmail, requestorDisplayName, requesteeEmail, 
                requesteeDisplayName, apptStart, apptEnd);

            es.useGoogle();
            es.Sendmail_With_IcsAttachment();

            Console.ReadLine();
        }
    }
}
