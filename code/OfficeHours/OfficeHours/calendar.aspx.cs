using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sendApptEmail;
using CAFEDataInterface;

namespace OfficeHours
{
    public partial class calendar : System.Web.UI.Page
    {
        private static CAFEData datasource = new CAFEData();
        private string currentDept;
        private string currentProf;
        //private string currentFacultyEmail;
        private string currentOffice;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if(RadioButtonList1.Text == null || RadioButtonList1.Text == "")
            //{
            //    Button3.UseSubmitBehavior = false;
            //    Button3.Enabled = false;
            //}

            if (!IsPostBack)
            {
                //if (RadioButtonList1.Text == null || RadioButtonList1.Text == "")
                //{
                //    Button3.UseSubmitBehavior = false;
                //    Button3.Enabled = false;
                //}

                Label10.ForeColor = System.Drawing.Color.Red;
                Session["confirm"] = "";

                Calendar1.TodaysDate = new DateTime(2015, 11, 2);
                Calendar1.SelectedDate = Calendar1.TodaysDate;

                List<String> departments = datasource.getDepartments();

                //DropDownList3.Items.Clear();

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

            Button3.UseSubmitBehavior = true;
            Button3.Enabled = true;

            /* Make DateTime object here to pass to email function


            //DateTime(Int32, Int32, Int32, Int32, Int32, Int32)

            String date = Calendar1.SelectedDate.ToShortDateString();
            String time = RadioButtonList1.SelectedItem.ToString();

            Console.WriteLine(date);
            Console.WriteLine(time);


            DateTime nd = new DateTime();
            */

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EmailSender es = new EmailSender();

            String studentemail = Session["email"].ToString();
            String studentname = Session["email"].ToString(); // Account Database Query
            String professoremail = HiddenField2.Value.ToString();
            String professorname = DropDownList2.SelectedValue.ToString();
            DateTime startDateTime = Calendar1.SelectedDate; // Make date time object with day (from calendar) and time (from radio button selection)
            String location = currentOffice;
            String messageProf = TextBox1.Text.ToString();
            String messageStud = null;




            // Sends the email:
            //es.sendEmailInvite(studentemail, studentname, professoremail,
            //professorname, startDateTime, location, messageProf, messageStud);

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

            if (RadioButtonList1.Text == null || RadioButtonList1.Text == "")
            {
                Button3.UseSubmitBehavior = false;
                Button3.Enabled = false;
            }
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
    }
}