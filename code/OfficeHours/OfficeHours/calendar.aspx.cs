using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sendApptEmail;

namespace OfficeHours
{
    public partial class calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["email"] != null)
            //{
            //    HiddenField1.Value = Session["email"].ToString();
            //}

            Label10.ForeColor = System.Drawing.Color.Red;

            if (!IsPostBack)
            { 
                DropDownList2.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            }

            Label2.Text = DropDownList2.Text + "'s Office Hours";

            if(DropDownList2.Text != "")
            {
                Label2.Text = DropDownList2.Text + "'s Office Hours";
            }
            else
            {
                Label2.Text = "No Professor Selected";
            }

            if (Session["email"] != null)
            {
                //Label6.Text = Session["email"].ToString();
                Label6.Text = HiddenField1.Value.ToString();
            }
            else
            {
                Label10.Text = "**You are not logged in! Please click 'Go Back' and log in to use the system.**";
                Button1.Enabled = false;
                Button1.UseSubmitBehavior = false;
            }

            TableRow tRow = new TableRow();
            Table1.Rows.Add(tRow);

            TableCell tCell = new TableCell();
            tRow.Cells.Add(tCell);

            tCell.Text = "Monday: 12:00 - 12:30";
            tRow.Cells.Add(tCell);

            TableRow tRow2 = new TableRow();
            Table1.Rows.Add(tRow2);

            TableCell tCell2 = new TableCell();
            tRow2.Cells.Add(tCell2);

            tCell2.Text = "Tuesday: None";
            tRow2.Cells.Add(tCell2);

            TableRow tRow3 = new TableRow();
            Table1.Rows.Add(tRow3);

            TableCell tCell3 = new TableCell();
            tRow3.Cells.Add(tCell3);

            tCell3.Text = "Wednesday: 1:00 - 2:30, 4:00 - 5:00";
            tRow3.Cells.Add(tCell3);

            TableRow tRow4 = new TableRow();
            Table1.Rows.Add(tRow4);

            TableCell tCell4 = new TableCell();
            tRow4.Cells.Add(tCell4);

            tCell4.Text = "Thursday: None";
            tRow4.Cells.Add(tCell4);

            TableRow tRow5 = new TableRow();
            Table1.Rows.Add(tRow5);

            TableCell tCell5 = new TableCell();
            tRow5.Cells.Add(tCell5);

            tCell5.Text = "Friday: 1:00 - 2:30";
            tRow5.Cells.Add(tCell5);
        }

        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    TextBox1.Text = "I would like to request a meeting during your office hours on " + Calendar1.SelectedDate.DayOfWeek.ToString() + " " + Calendar1.SelectedDate.ToShortDateString();
        //}

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "I would like to request a meeting during your office hours on " + Calendar1.SelectedDate.DayOfWeek.ToString() +
                " " + Calendar1.SelectedDate.ToShortDateString() + " " + RadioButtonList1.SelectedItem.ToString() + ".";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmailSender es = new EmailSender();

            String email = Session["email"].ToString();


            //es.sendEmailInvite()
        }
    }
}