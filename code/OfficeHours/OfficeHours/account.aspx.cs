using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeHours
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["confirm"] = "";

            string email = TextBox3.Text.ToString();
            string first = TextBox1.Text.ToString();
            string last = TextBox2.Text.ToString();
            string pass1 = TextBox4.Text.ToString();
            string pass2 = TextBox5.Text.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Validate that all fields are not empty, and passwords match
                // Make session variable to display welcome page label (very similar code welcome/calendar)
                // If email is already used, refresh page with error message "email already used..."

                if (TextBox3.Text.ToString() != null && TextBox3.Text.ToString() != "")
                {
                    Response.Redirect("/welcome.aspx");
                }
            }
        }
    }
}