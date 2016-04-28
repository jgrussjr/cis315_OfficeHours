using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace sendApptEmail
{
    class EmailSender
    {
        // student
        private String mailToAddress1;
        private String mailToDisplayName1;
        // professor
        private String mailToAddress2;
        private String mailToDisplayName2;
        // apppointment and message info
        private DateTime apptStart;
        private DateTime apptEnd;
        private String location;
        private String messageBodyProf;
        private String messageBodyStud;

        // sending address
        private String mailFromAddress = "guofficehours@gmail.com";
        private String mailFromDisplayName = "GU Office Hours";
        // SMTP information
        private static String mailServerAddressDefault = "smtp.gmail.com";
        private String mailServerAddress = mailServerAddressDefault; // set as optional perameter
        private int port = 587; //465 google ports
        private String userName = "guofficehours@gmail.com";
        private String pword = "Gannon123";

        public EmailSender()
        {

        }


        // the method that the system should use to send the email. This validates and cleans the data
        public void sendEmailInvite(String mailToAddressStudent, String mailToDisplayNameStudent, String mailToAddressProf,
            String mailToDisplayNameProf, DateTime apptStart, String location = null, String messageBodyProf = null, String messageBodyStud = null)
        {
            DateTime apptEnd = apptStart;
            apptEnd = apptEnd.AddMinutes(+30);

            mailToAddressStudent = mailToAddressStudent.Trim();
            mailToDisplayNameStudent = mailToDisplayNameStudent.Trim();
            mailToAddressProf = mailToAddressProf.Trim();
            mailToDisplayNameProf = mailToDisplayNameProf.Trim();


            if (location != null) 
            {
                location = location.Trim();
            }
            else
            {
                location = mailToDisplayNameProf + "'s Office";
            }

            if (messageBodyProf != null) 
            {
                messageBodyProf = messageBodyProf.Trim();
            }
            else
            {
                messageBodyProf = "A request has been made by " + mailToDisplayNameStudent +
                    " to meet with you during your office hours at " + apptStart.ToString() + " until " + apptEnd.ToString() +
                    ". Please accept or decline the request. This message has been sent via the Office Hours Scheduling System.";
            }

            if (messageBodyStud != null) 
            {
                messageBodyStud = messageBodyStud.Trim();
            }
            else
            {
                messageBodyStud = "You have requested to meet " + mailToDisplayNameProf +
                    " during normal office hours at " + apptStart.ToString() + " until " + apptEnd.ToString() +
                    " The professor should respond to this outlook" +
                    " invitation by accepting or denying the request." +
                    " This message has been sent via the Office Hours Scheduling System.";
            }

            // set values in class
            this.setICSEmailValues(mailToAddressStudent, mailToDisplayNameStudent, mailToAddressProf, mailToDisplayNameProf,
            apptStart, apptEnd, location, messageBodyProf, messageBodyStud);
            // prepare and mail ics and emails from class data

            this.SendEmailWithIcsAttachment();

            /*
            Console.Out.WriteLine("Student email: " + mailToAddress1);
            Console.Out.WriteLine("Student name: " + mailToDisplayName1);

            Console.Out.WriteLine("Professor email: " + mailToAddress2);
            Console.Out.WriteLine("Professor name: " + mailToDisplayName2);

            Console.Out.WriteLine("appt start: " + this.apptStart.ToString());
            Console.Out.WriteLine("appt end: " + this.apptEnd.ToString());

            Console.Out.WriteLine("Location: " + this.location);
            Console.Out.WriteLine("Professor Message: " + this.messageBodyProf);
            Console.Out.WriteLine("Student Message: " + this.messageBodyStud);
            
            Console.ReadKey();
            */

        }


        // method that sets the values needed to send the email
        private void setICSEmailValues(String mailToAddressStudent, String mailToDisplayNameStudent, 
            String mailToAddressProf, String mailToDisplayNameProf,
            DateTime apptStart, DateTime apptEnd, String location, String messageBodyProf, String messageBodyStud)
        {

            this.mailToAddress1 = mailToAddressStudent;
            this.mailToDisplayName1 = mailToDisplayNameStudent;

            this.mailToAddress2 = mailToAddressProf;
            this.mailToDisplayName2 = mailToDisplayNameProf;

            this.apptStart = apptStart;
            this.apptEnd = apptEnd;
            this.location = location;
            this.messageBodyProf = messageBodyProf;
            this.messageBodyStud = messageBodyStud;
        }


        // method that prepares and sends the two emails with an ics in each
        private void SendEmailWithIcsAttachment()
        {

            MailMessage msgProf = new MailMessage();
            MailMessage msgStud = new MailMessage();
            //Now we have to set the value to Mail message properties

            //Note Please change it to correct mail-id to use this in your application
            msgProf.From = new MailAddress(mailFromAddress, mailFromDisplayName); //sending email address
            msgProf.To.Add(new MailAddress(mailToAddress2, mailToDisplayName2)); // professor
            msgProf.Headers.Add("Content-class", "urn:content-classes:calendarmessage");
            msgProf.Subject = "Office Hours Request: " + mailToDisplayName1 + " - " + mailToDisplayName2;
            msgProf.Body = messageBodyProf;

            msgStud.From = new MailAddress(mailFromAddress, mailFromDisplayName); //sending email address
            msgStud.To.Add(new MailAddress(mailToAddress1, mailToDisplayName1)); // student
            msgStud.Headers.Add("Content-class", "urn:content-classes:calendarmessage");
            msgStud.Subject = "Office Hours Request: " + mailToDisplayName2 + " - " + mailToDisplayName1;
            msgStud.Body = messageBodyStud;


            // Contruct the ICS file using string builder
            StringBuilder str = new StringBuilder();
            str.AppendLine("BEGIN:VCALENDAR");
            str.AppendLine("PRODID:-//Schedule a Meeting");
            str.AppendLine("VERSION:2.0");
            str.AppendLine("METHOD:REQUEST");
            str.AppendLine("BEGIN:VEVENT");

            str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", apptStart));
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.Now));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", apptEnd));

            str.AppendLine("LOCATION: " + this.location);
            str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
            str.AppendLine(string.Format("DESCRIPTION:{0}", msgProf.Body));
            str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", msgProf.Body));
            str.AppendLine(string.Format("SUMMARY:{0}", "Meeting: " + mailToDisplayName1 + " - " + mailToDisplayName2));
            str.AppendLine(string.Format("ORGANIZER;CN=\"{0}\":MAILTO:{1}", msgStud.To[0].DisplayName, msgStud.To[0].Address));

            str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msgProf.To[0].DisplayName, msgProf.To[0].Address));
            str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=FALSE:mailto:{1}", msgStud.To[0].DisplayName, msgStud.To[0].Address));

            str.AppendLine("BEGIN:VALARM");
            str.AppendLine("TRIGGER:-PT15M");
            str.AppendLine("ACTION:DISPLAY");
            str.AppendLine("DESCRIPTION:Reminder");
            str.AppendLine("END:VALARM");
            str.AppendLine("END:VEVENT");
            str.AppendLine("END:VCALENDAR");

            //Now sending an email with attachment ICS file.                     
            //System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient();
            System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient(mailServerAddress, this.port);

            //smtpclient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            smtpclient.Credentials = new NetworkCredential(userName, pword);
            smtpclient.EnableSsl = true;


            System.Net.Mime.ContentType contype = new System.Net.Mime.ContentType("text/calendar");
            contype.Parameters.Add("method", "REQUEST");
            contype.Parameters.Add("name", "Meeting.ics");
            AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), contype);
            msgProf.AlternateViews.Add(avCal);
            msgStud.AlternateViews.Add(avCal);
            smtpclient.Send(msgStud);
            smtpclient.Send(msgProf);
        }

        // getters and setters
        public String MailFromAddress
        {
            get { return mailFromAddress; }
            set { mailFromAddress = value; }
        }

        public String MailFromDisplayName
        {
            get { return mailFromDisplayName; }
            set { mailFromDisplayName = value; }
        }

        public String MailToAddress
        {
            get { return mailToAddress1; }
            set { mailToAddress1 = value; }
        }

        public String MailToDisplayName
        {
            get { return mailToDisplayName1; }
            set { mailToDisplayName1 = value; }
        }

        public DateTime ApptStart
        {
            get { return apptStart; }
            set { apptStart = value; }
        }

        public DateTime ApptEnd
        {
            get { return apptEnd; }
            set { apptEnd = value; }
        }

        public String Location
        {
            get { return location; }
            set { location = value; }
        }

        public String MailServerIP
        {
            get { return mailServerAddress; }
            set { mailServerAddress = value; }
        }
   
    }
}
