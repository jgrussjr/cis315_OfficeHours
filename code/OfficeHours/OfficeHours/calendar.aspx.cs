using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sendApptEmail;
using CAFEDataInterface;
using System.Text.RegularExpressions;

namespace OfficeHours
{
    public partial class calendar : System.Web.UI.Page
    {
        private static CAFEData datasource = new CAFEData();
        private string currentDept;
        private string currentProf;
        //private string currentFacultyEmail;
        private string currentOffice;
        private string tempTime;
        private string tempDate;
        private DateTime finalDateTime;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Label10.ForeColor = System.Drawing.Color.Red;
                Session["confirm"] = "";

                Calendar1.TodaysDate = new DateTime(2015, 11, 2);
                Calendar1.SelectedDate = Calendar1.TodaysDate;

                List<String> departments = datasource.getDepartments();

                DropDownList3.Items.Clear();

                for (int i = 0; i < departments.Count(); i++)
                {
                    DropDownList3.Items.Add(departments[i]);
                }

                currentDept = departments[0];
                updateFacultyDropDown();
                currentProf = DropDownList2.SelectedValue;
                updateAvailableHoursTable();
            }


        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentDept = DropDownList3.SelectedValue;
            updateFacultyDropDown();
            currentProf = DropDownList2.SelectedValue;
            RadioButtonList1.Items.Clear();
            updateAvailableHoursTable();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentProf = DropDownList2.SelectedValue;
            RadioButtonList1.Items.Clear();
            updateAvailableHoursTable();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "I would like to request a meeting during your office hours on " + Calendar1.SelectedDate.DayOfWeek.ToString() +
                " " + Calendar1.SelectedDate.ToShortDateString() + " " + RadioButtonList1.SelectedItem.ToString() + ".";

            string date = Calendar1.SelectedDate.ToShortDateString();
            string time = RadioButtonList1.SelectedItem.ToString();
            tempDate = date;
            tempTime = time;


            /*
            if (this.dateTimeConversion() != true)
            {
                finalDateTime = Calendar1.SelectedDate;
            }
            */
            finalDateTime = Calendar1.SelectedDate;


            Button3.UseSubmitBehavior = true;
            Button3.Enabled = true;

            // Make DateTime object here to pass to email function
            // 11/13/2015 9:30 AM.
    
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EmailSender es = new EmailSender();

            String studentemail = Session["email"].ToString();
            String studentname = Session["email"].ToString(); // Account Database Query
            String professoremail = HiddenField2.Value.ToString();
            String professorname = DropDownList2.SelectedValue.ToString();
            //DateTime startDateTime = Calendar1.SelectedDate; // Make date time object with day (from calendar) and time (from radio button selection)
            String location = currentOffice;
            String messageProf = TextBox1.Text.ToString();
            String messageStud = null; //in emailSender


            // Sends the email:

            //es.sendEmailInvite(studentemail, studentname, professoremail,
            //professorname, finalDateTime, location, messageProf, messageStud);

            Session["confirm"] = "Your Request Has Successfully Been Made! You should recieve an email soon.";

            Response.Redirect("/welcome.aspx");
        }

        private void updateFacultyDropDown()
        {
            List<CAFEDataInterface.Faculty> facultyList = datasource.getFacultyByDepartment(currentDept);
            DropDownList2.Items.Clear();
            foreach (var member in facultyList)
            {
                DropDownList2.Items.Add(member.LastName);
            }
        }

        private void updateAvailableHoursTable()
        {
            Label2.Text = currentProf + "'s Office Hours";

            if (Session["email"] != null)
            {
                Label6.Text = Session["email"].ToString();
            }
            else
            {
                Label10.Text = "**You are not logged in! Please click 'Go Back' and log in to use the system.**";
                Button3.Enabled = false;
                Button3.UseSubmitBehavior = false;
            }

            int currentTerm = datasource.getTermID(Calendar1.SelectedDate);
            List<CAFEDataInterface.Faculty> facultyRecords = datasource.searchLastName(currentProf);
            int currentFacultyID = facultyRecords[0].FacultyID;
            string currentFacultyEmail = facultyRecords[0].Email;
            string currentOffice = facultyRecords[0].Office;
            //this.setFacultyEmail(currentFacultyEmail);
            this.setFacultyOffice(currentOffice);

            string email = facultyRecords[0].Email.ToString();
            string office = facultyRecords[0].Office.ToString();

            HiddenField2.Value = email;

            Label17.Text = "Office: " + office;

            Label18.Text = "For: " + Calendar1.SelectedDate.DayOfWeek.ToString() + " (Select Above)";

            List<CAFEDataInterface.OfficeHour> currentOfficeHours = datasource.getOfficeHours(currentFacultyID, currentTerm);


            Table1.Rows.Clear();

            TableRow tRow = new TableRow();
            Table1.Rows.Add(tRow);

            TableCell tCell = new TableCell();
            tRow.Cells.Add(tCell);

            tCell.Text = findDayInOfficeHours(currentOfficeHours, "Monday");
            tRow.Cells.Add(tCell);

            TableRow tRow2 = new TableRow();
            Table1.Rows.Add(tRow2);

            TableCell tCell2 = new TableCell();
            tRow2.Cells.Add(tCell2);

            tCell2.Text = findDayInOfficeHours(currentOfficeHours, "Tuesday");
            tRow2.Cells.Add(tCell2);

            TableRow tRow3 = new TableRow();
            Table1.Rows.Add(tRow3);

            TableCell tCell3 = new TableCell();
            tRow3.Cells.Add(tCell3);

            tCell3.Text = findDayInOfficeHours(currentOfficeHours, "Wednesday");
            tRow3.Cells.Add(tCell3);

            TableRow tRow4 = new TableRow();
            Table1.Rows.Add(tRow4);

            TableCell tCell4 = new TableCell();
            tRow4.Cells.Add(tCell4);

            tCell4.Text = findDayInOfficeHours(currentOfficeHours, "Thursday");
            tRow4.Cells.Add(tCell4);

            TableRow tRow5 = new TableRow();
            Table1.Rows.Add(tRow5);

            TableCell tCell5 = new TableCell();
            tRow5.Cells.Add(tCell5);

            tCell5.Text = findDayInOfficeHours(currentOfficeHours, "Friday");
            tRow5.Cells.Add(tCell5);

            this.radioList(currentOfficeHours);
        }

        private string findDayInOfficeHours(List<CAFEDataInterface.OfficeHour> theHoursList, string day)
        {
            string result = day + ": ";

            for (int i = 0; i < theHoursList.Count; i++)
            {
                if (theHoursList[i].Day == day)
                {
                    if (result != day + ": ")
                        result += ", ";

                    int startHour = theHoursList[i].FromTime.Hour;
                    int startMinute = theHoursList[i].FromTime.Minute;
                    int endHour = theHoursList[i].ToTime.Hour;
                    int endMinute = theHoursList[i].ToTime.Minute;

                    if (startHour > 12)
                        startHour %= 12;

                    if (endHour > 12)
                        endHour %= 12;

                    result += startHour + ":" + startMinute.ToString("D2")
                        + " - " + endHour + ":" + endMinute.ToString("D2");
                }
            }

            if (result == day + ": ")
                result += "None";

            return result;
        }

        private void radioList(List<CAFEDataInterface.OfficeHour> theHoursList)
        {
            string result;

            for (int i = 0; i < theHoursList.Count; i++)
            {
                if (theHoursList[i].Day == Calendar1.SelectedDate.DayOfWeek.ToString())
                {
                    DateTime fromTime = theHoursList[i].FromTime;
                    RadioButtonList1.Items.Add(new ListItem(fromTime.ToShortTimeString()));
                    while (fromTime.AddMinutes(+30) < theHoursList[i].ToTime)
                    {
                        fromTime = fromTime.AddMinutes(+30);
                        result = fromTime.ToShortTimeString();

                        RadioButtonList1.Items.Add(new ListItem(result));
                    }

                }
            }


        }
        //OnSelectionChanged="Calendar1_SelectionChanged"
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            currentProf = DropDownList2.SelectedValue;
            RadioButtonList1.Items.Clear();
            updateAvailableHoursTable();
        }

        //private void setFacultyEmail(String email)
        //{
        //    this.currentFacultyEmail = email;
        //}

        private void setFacultyOffice(String office)
        {
            this.currentOffice = office;
        }

        private bool dateTimeConversion()
        {

            // do date spilt
            string[] dateStringArr = new string[3];
            dateStringArr = tempDate.Split('/');
            Int32[] dateIntArr = new Int32[dateStringArr.Length];
            int intDate = 0;
            bool parsed;
            for (int i = 0; i < dateStringArr.Length; i++)
            {
                parsed = Int32.TryParse(dateStringArr[i], out intDate);

                if (parsed)
                {
                    dateIntArr[i] = intDate;
                }
                else
                {
                    Console.WriteLine("Date String '" + i + "' could not be parsed.");
                    dateIntArr[i] = 0;
                    return false;
                }
            }

            // do time split
            string pattern = @"(\d{1,2}):(\d{1,2}).*";
            string[] timeStringArr = new string[2];
            MatchCollection matches = Regex.Matches(tempTime, pattern);
            int count = 0;
            int groupNums = 0;
            foreach (Match match in matches)
            {
                groupNums = (match.Groups.Count -1);
                timeStringArr = new string[groupNums];
                for (int i = 1; i <= groupNums; i++)
                {
                    timeStringArr[i -1] = match.Groups[i].Value; 
                }
                count = count + 1;
                Console.WriteLine("Hour: ", match.Groups[1].Value);
                Console.WriteLine("Minute: ", match.Groups[2].Value);
                Console.WriteLine();
            }

            Int32[] timeIntArr = new Int32[timeStringArr.Length];
            int intTime = 0;
            bool parsedTime;
            for (int i = 0; i < timeStringArr.Length; i++)
            {
                parsedTime = Int32.TryParse(timeStringArr[i], out intTime);

                if (parsedTime)
                {
                    timeIntArr[i] = intTime;
                }
                else
                {
                    Console.WriteLine("Time String '" + i + "' could not be parsed.");
                    timeIntArr[i] = 0;
                    // datetime should be the input just date, generically
                    return false;
                }
            }
            DateTime newDateTime = new DateTime(dateIntArr[2], dateIntArr[1], dateIntArr[0],
                timeIntArr[0], timeIntArr[1], 0, DateTimeKind.Utc);
            this.finalDateTime = newDateTime;
            return true;

        }
    }
}