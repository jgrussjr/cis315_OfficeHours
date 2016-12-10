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
            /*
            
            int userId = 0;
            //database stuff needs changed 12/10
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_User"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                // if the create new user function returns false, we want the following error conditons
                switch (userId)
                {
                    case -1:
                        message = "Username already exists.\\nPlease choose a different username.";
                        break;
                    case -2:
                        message = "Supplied email address has already been used.";
                        break;
                    default:
                        message = "Registration successful.\\nUser Id: " + userId.ToString();
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }

            END OLD  FROM EXAMPLE
            */

            // get data from UI
            String firstName = txtFirstName.Text.Trim();
            String lastName = txtLastName.Text.Trim();
            String password = txtPassword.Text.Trim();
            String email = txtEmail.Text.Trim();

            // attempt to create new user
            bool success = datasource.createNewUser(firstName, lastName, email, password);

            string message = string.Empty;
            switch (success)
            {
                case false:
                    message = "Supplied email address has already been used.";
                    break;
                case true:
                    message = "Registration successful.\\nEmail Address: " + email.ToString();
                    break;
            }
            // Not sure what this part does
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);






        }
    }
}