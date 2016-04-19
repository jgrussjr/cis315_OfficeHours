using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace sendApptEmail
{
    class emailSender
    {

        private String mailFromAddress = "";
        private String mailFromDisplayName = "";

        private String mailToAddress1 = "";
        private String mailToDisplayName1 = "";
        private String mailToAddress2 = "";
        private String mailToDisplayName2 = "";

        private DateTime apptStart = DateTime.Now.AddMinutes(+30);
        private DateTime apptEnd = DateTime.Now.AddMinutes(+60);
        private String location = "The Professor's Office";
        private String messageBody = "This meeting request was made by the Office Hours Scheduling Application";

        private static String mailServerIPDefault = "localhost";
        private String mailServerIP = mailServerIPDefault; // set as optional perameter
        private int port = 587; //465
        private String userName = "gannonsga@gmail.com";
        private String pword = "studentg";



        public emailSender(String mailFromAddress, String mailFromDisplayName,
            String mailToAddress1, String mailToDisplayName1, String mailToAddress2, String mailToDisplayName2,
            DateTime apptStart, DateTime apptEnd, String location, String mailServerIP = null)
        {

            this.mailFromAddress = mailFromAddress;
            this.mailFromDisplayName = mailFromDisplayName;
            this.mailToAddress1 = mailToAddress1;
            this.mailToDisplayName1 = mailToDisplayName1;
            this.mailToAddress2 = mailToAddress2;
            this.mailToDisplayName2 = mailToDisplayName2;

            
            this.apptStart = apptStart;
            this.apptEnd = apptEnd;
            this.location = location;
            this.mailServerIP = mailServerIP; // set as optional perameter, could be null

            if(this.mailServerIP != null) {}
            else
            {
                this.mailServerIP = mailServerIPDefault;
            }
        }


        public emailSender(String mailToAddress1, String mailToDisplayName1, String mailToAddress2, String mailToDisplayName2,
            DateTime apptStart, DateTime apptEnd, String location = "The Office")
        {

            this.mailToAddress1 = mailToAddress1;
            this.mailToDisplayName1 = mailToDisplayName1;

            this.mailToAddress2 = mailToAddress2;
            this.mailToDisplayName2 = mailToDisplayName2;

            this.apptStart = apptStart;
            this.apptEnd = apptEnd;
            this.location = location;
        }


        public void useGoogle()
        {
            mailServerIP = "smtp.gmail.com";
            mailFromAddress = "gannonsga@gmail.com";
            mailFromDisplayName = "James";
            this.port = 587; //465
            userName = "gannonsga@gmail.com";
            pword = "studentg";

        }

        public void Sendmail_With_IcsAttachment()
        {

            MailMessage msg = new MailMessage();
            //Now we have to set the value to Mail message properties

            //Note Please change it to correct mail-id to use this in your application
            msg.From = new MailAddress(mailFromAddress, mailFromDisplayName);
            msg.To.Add(new MailAddress(mailToAddress1, mailToDisplayName1)); // student
            msg.To.Add(new MailAddress(mailToAddress2, mailToDisplayName2)); // proffesor
            msg.Headers.Add("Content-class", "urn:content-classes:calendarmessage");
            msg.Subject = "Office Hours Request: " + mailToDisplayName1 + " - " + mailToDisplayName2;
            msg.Body = messageBody;


            // Now Contruct the ICS file using string builder
            StringBuilder str = new StringBuilder();
            str.AppendLine("BEGIN:VCALENDAR");
            str.AppendLine("PRODID:-//Schedule a Meeting");
            str.AppendLine("VERSION:2.0");
            str.AppendLine("METHOD:REQUEST");
            str.AppendLine("BEGIN:VEVENT");
            //str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", DateTime.Now.AddMinutes(+330)));
            //str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
            //str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", DateTime.Now.AddMinutes(+660)));

            str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", apptStart));
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.Now));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", apptEnd));

            str.AppendLine("LOCATION: " + this.location);
            str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
            str.AppendLine(string.Format("DESCRIPTION:{0}", msg.Body));
            str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", msg.Body));
            str.AppendLine(string.Format("SUMMARY:{0}", "Meeting: " + mailToDisplayName1 + " - " + mailToDisplayName2));
            //str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", msg.From.Address));
            str.AppendLine(string.Format("ORGANIZER;CN=\"{0}\":MAILTO:{1}", msg.To[0].DisplayName, msg.To[0].Address));

            //str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[0].DisplayName, msg.To[0].Address));
            str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[1].DisplayName, msg.To[1].Address));

            str.AppendLine("BEGIN:VALARM");
            str.AppendLine("TRIGGER:-PT15M");
            str.AppendLine("ACTION:DISPLAY");
            str.AppendLine("DESCRIPTION:Reminder");
            str.AppendLine("END:VALARM");
            str.AppendLine("END:VEVENT");
            str.AppendLine("END:VCALENDAR");

            //Now sending an email with attachment ICS file.                     
            //System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient();
            System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient(mailServerIP, this.port);

            //smtpclient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            smtpclient.Credentials = new NetworkCredential(userName, pword);
            smtpclient.EnableSsl = true;


            System.Net.Mime.ContentType contype = new System.Net.Mime.ContentType("text/calendar");
            contype.Parameters.Add("method", "REQUEST");
            contype.Parameters.Add("name", "Meeting.ics");
            AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), contype);
            msg.AlternateViews.Add(avCal);
            smtpclient.Send(msg);
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
            get { return mailServerIP; }
            set { mailServerIP = value; }
        }
    

    }
}
