using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CAFEDataInterface;

namespace OfficeHours
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //private static LoginManagerDataContext datasource = new LoginManagerDataContext();
        private static LoginManager datasource = new LoginManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            //DropDownList1.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            //Session["dropdown"] = DropDownList1.Text;

            //if (TextBox1.Text.ToString() == "" || TextBox1.Text.ToString() == null)
            //{
            //    Button5.Enabled = false;
            //    Button5.UseSubmitBehavior = false;
            //}
            //else
            //{
            //    Button5.Enabled = true;
            //    Button5.UseSubmitBehavior = true;
            //}
     
            Session["email"] = TextBox1.Text;
    
            if (Session["confirm"] != null)
            {
                Label3.Text = Session["confirm"].ToString();
            }
            else
            {
                Label3.Text = null;
            }
        }

        // Query Account Database to validate email/password
        protected void Button5_Click(object sender, EventArgs e)
        {
            String email = TextBox1.Text.ToString();
            String password = TextBox2.Text.ToString();
            if (password != null && email != null)
            {
                if (email == "")
                {
                    string message = "Please enter an email or create an account. No email entered.";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
                else if (password == "")
                {
                    string message = "Please enter a valid password or create an account. No password entered.";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
                else if (datasource.checkPassword(email, password))
                {
                    //Label3.Text = null;
                    //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "password matched!" + "');", true);
                    Response.Redirect("/calendar.aspx");
                }
                else
                {
                    string message = "Username or password match does not exist. Please enter a valid username and password combination.";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

                }
            }
        }
    }
}