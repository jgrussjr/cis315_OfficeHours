using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace sendApptEmail
{
    class emailSender
    {

        private String mailFromAddress = "testFrom@test.com";
        private String mailFromDisplayName = "testFrom";
        private String mailToAddress = "testTo@test.com";
        private String mailToDisplayName = "testTo";
        private String mailCCAddress = "testCC@test.com"; // optional
        private String mailCCDisplayName = "testCC"; // optional
        private DateTime apptStart = DateTime.Now.AddMinutes(+30);
        private DateTime apptEnd = DateTime.Now.AddMinutes(+60);
        private String location = "The Office";
        private String mailServerIP = "localhost"; // set as optional perameter

        private String mailServerIPDefault = "localhost";

        public emailSender()
        {

        }


        public emailSender(String mailFromAddress, String mailFromDisplayName,
            String mailToAddress, String mailToDisplayName,
            DateTime apptStart, DateTime apptEnd, String location, String mailCCAddress = null, 
            String mailCCDisplayName = null, String mailServerIP = null)
        {

            this.mailFromAddress = mailFromAddress;
            this.mailFromDisplayName = mailFromDisplayName;
            this.mailToAddress = mailToAddress;
            this.mailToDisplayName = mailToDisplayName;


            this.mailCCAddress = mailCCAddress; // optional, could be null
            this.mailCCDisplayName = mailCCDisplayName; // optional, could be null
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




        public void Sendmail_With_IcsAttachment()
        {

            MailMessage msg = new MailMessage();
            //Now we have to set the value to Mail message properties

            //Note Please change it to correct mail-id to use this in your application
            msg.From = new MailAddress(mailFromAddress, mailFromDisplayName);
            msg.To.Add(new MailAddress(mailToAddress, mailToDisplayName));
            msg.CC.Add(new MailAddress(mailCCAddress, mailCCDisplayName));// it is optional, only if required
            msg.Subject = "Send mail with ICS file as an Attachment";
            msg.Body = "Please Attend the meeting with this schedule";
            msg.Headers.Add("Content-class", "urn:content-classes:calendarmessage");

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
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", apptEnd));

            str.AppendLine("LOCATION: " + this.location);
            str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
            str.AppendLine(string.Format("DESCRIPTION:{0}", msg.Body));
            str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", msg.Body));
            str.AppendLine(string.Format("SUMMARY:{0}", msg.Subject));
            str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", msg.From.Address));

            str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[0].DisplayName, msg.To[0].Address));

            str.AppendLine("BEGIN:VALARM");
            str.AppendLine("TRIGGER:-PT15M");
            str.AppendLine("ACTION:DISPLAY");
            str.AppendLine("DESCRIPTION:Reminder");
            str.AppendLine("END:VALARM");
            str.AppendLine("END:VEVENT");
            str.AppendLine("END:VCALENDAR");

            //Now sending a mail with attachment ICS file.                     
            System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient();

            //smtpclient.Host = "localhost"; //-------this has to given the Mailserver IP
            smtpclient.Host = mailServerIP; //-------this has to given the Mailserver IP

            smtpclient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

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
            get { return mailToAddress; }
            set { mailToAddress = value; }
        }

        public String MailToDisplayName
        {
            get { return mailToDisplayName; }
            set { mailToDisplayName = value; }
        }

        public String MailCCAddress
        {
            get { return mailCCAddress; }
            set { mailCCAddress = value; }
        }

        public String MailCCDisplayName
        {
            get { return mailCCDisplayName; }
            set { mailCCDisplayName = value; }
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
