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
            string emailtext = TextBox3.Text.ToString();
            string first = TextBox1.Text.ToString();
            string last = TextBox2.Text.ToString();
            string pass1 = TextBox4.Text.ToString();
            string pass2 = TextBox5.Text.ToString();

            if (emailtext == null)
            {
                Button1.UseSubmitBehavior = false;
                Button1.Enabled = false;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string emailtext = TextBox3.Text.ToString();
            if (emailtext == null)
            {
                Button1.UseSubmitBehavior = false;
                Button1.Enabled = false;
            }
            if (Page.IsValid)
            {
                if (emailtext == null)
                {
                    Button1.UseSubmitBehavior = false;
                    Button1.Enabled = false;
                }
            }
        }
    }
}