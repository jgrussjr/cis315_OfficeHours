using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeHours
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DropDownList1.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            //Session["dropdown"] = DropDownList1.Text;
            Session["email"] = TextBox1.Text;

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:2966/calendar.aspx");
        }
    }
}