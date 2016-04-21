using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeHours
{
    public partial class calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}