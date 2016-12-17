using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sendApptEmail
{
    class EmailSenderUnitTester
    {
        static void Main(string[] args)
        {

            String requestorEmail = "mccracke007@knights.gannon.edu";
            String requestorDisplayName = "STUDENT";
            String requesteeEmail = "an_sc_mc@yahoo.com";
            String requesteeDisplayName = "PROFESSOR";
            DateTime apptStart = DateTime.UtcNow.AddMinutes(+30);
            String location = "The Office - test";
            String messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
            String messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();

            string testCaseNum = "0";

            while (testCaseNum != "x")
            {
                Console.WriteLine("Enter test case #, or x to exit program: ");
                testCaseNum = Console.ReadLine();

                switch (testCaseNum)
                {
                    case "1":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 1";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "2":
                        requestorEmail = null;
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 1";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "3":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = null;
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 2";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "4":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = null;
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 3";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "5":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = null;
                        location = "Test Case 5";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "6":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 6";
                        messageBodyProf = null;
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "7":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 7";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = null;
                        break;
                    case "8":
                        requestorEmail = null;
                        requestorDisplayName = null;
                        requesteeEmail = null;
                        requesteeDisplayName = null;
                        location = null;
                        messageBodyProf = null;
                        messageBodyStud = null;
                        break;
                    case "9":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = null;
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "10":
                        requestorEmail = "";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 10";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "11":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 11";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "12":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 12";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "13":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "";
                        location = "Test Case 13";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "14":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 14";
                        messageBodyProf = "";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "15":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 15";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "";
                        break;
                    case "16":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = null;
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "Test Case 16";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "17":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = null;
                        location = "Test Case 17";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "18":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = null;
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = null;
                        location = "Test Case 18";
                        messageBodyProf = "Hello, I would like to meet with you to discuss the assignment.";
                        messageBodyStud = "You have requested a meeting with " + requesteeDisplayName + " for " + apptStart.ToString();
                        break;
                    case "19":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = "";
                        messageBodyProf = "";
                        messageBodyStud = "";
                        break;
                    case "20":
                        requestorEmail = "mccracke007@knights.gannon.edu";
                        requestorDisplayName = "STUDENT";
                        requesteeEmail = "an_sc_mc@yahoo.com";
                        requesteeDisplayName = "PROFESSOR";
                        location = null;
                        messageBodyProf = null;
                        messageBodyStud = null;
                        break;
                    default:
                        testCaseNum = "x";
                        break;
                }

                EmailSender es = new EmailSender();


                Console.WriteLine("Execute emailSender? y/n ");
                string send = Console.ReadLine();

                if (send == "y" && testCaseNum != "x")
                {
                    es.sendEmailInvite(requestorEmail, requestorDisplayName, requesteeEmail, requesteeDisplayName,
                    apptStart, location, messageBodyProf, messageBodyStud);

                    //es.sendEmailInvite(requestorEmail, requestorDisplayName, requesteeEmail, requesteeDisplayName,
                    //apptStart);
                }
                else
                {
                    testCaseNum = "x";
                }
            }


        }
    }
}
