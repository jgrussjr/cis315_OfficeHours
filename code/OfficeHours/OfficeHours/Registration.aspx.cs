using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using CAFEDataInterface;


namespace OfficeHours
{

    public partial class Registration : System.Web.UI.Page
    {
        private static LoginManager datasource = new LoginManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            // get data from UI
            String firstName = txtFirst.Text.Trim();
            String lastName = txtLast.Text.Trim();
            String password = txtPassword.Text.Trim();
            String email = txtEmail.Text.Trim();

            // attempt to create new user
            string success = datasource.createNewUser(firstName, lastName, email, password);

            string message = string.Empty;
            switch (success)
            {
                case "duplicate":
                    message = "Registration failed.\\n" + email.ToString() + " is already associated with an account.";
                    break;
                case "true":
                    message = "Registration successful.\\n" + "Email Address: " + email.ToString();
                    break;
                case "exception":
                    //message = successes[1];
                    message = "An unknown error occured in creating the account.";
                    break;
                default:
                    message = "IDK man... Registration successful?\\nUser Id: " + email.ToString();
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

            //Response.Redirect("/welcome.aspx");


        }

        protected void ReturnToWelcome(object sender, EventArgs e)
        {
            Response.Redirect("/welcome.aspx");
        }
    }
}