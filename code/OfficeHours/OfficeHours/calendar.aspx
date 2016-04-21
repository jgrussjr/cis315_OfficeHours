<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendar.aspx.cs" Inherits="OfficeHours.calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 567px; top: 55px; position: absolute; margin-bottom: 0px;" Text="Brinkman"></asp:Label>
        <asp:Button ID="Button2" runat="server" OnClientClick="window.location.href='http://localhost:2966/welcome.aspx'; return false;" style="z-index: 1; left: 10px; top: 15px; position: absolute" Text="Go Back" />
    </div>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 392px; top: 314px; position: absolute" Text="Message for professor (optional):"></asp:Label>
        <asp:Table 
            CellPadding = "10" 
            CellSpacing="0"
            GridLines="Both"
            BorderWidth="3"
            BorderColor="Black"
            BorderStyle="Solid"

            ID="Table1" runat="server" style="z-index: 1; left: 390px; top: 72px; position: absolute; height: 220px; width: 443px">
        </asp:Table>
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 509px; top: 2px; position: absolute" Text="Office Hours" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <p>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 168px; top: 316px; position: absolute" Text="Please choose a time:"></asp:Label>
            <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 137px; top: 14px; position: absolute" Text="deere@knightsgannon.edu" inputtype="text" placeholder="search" ></asp:Label>
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth" style="z-index: 1; left: 10px; top: 48px; position: absolute; height: 244px; width: 357px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
            </asp:Calendar>
        </p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" style="z-index: 1; left: 172px; top: 345px; position: absolute; height: 33px; width: 180px">
            <asp:ListItem Value="12:00">12:00 - 12:30</asp:ListItem>
            <asp:ListItem Value="12:30">12:30 - 1:00</asp:ListItem>
            <asp:ListItem Value="2:45">2:45 - 3:15</asp:ListItem>
            <asp:ListItem Value="3:15">3:15 - 3:35</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" placeholder="Example: Dear Dr. Brinkman, I would like to visit your office hours from 12:00-12:30 on Monday, May 2 – John Deere, deere001@knights.gannon.edu" style="z-index: 1; resize:none; left: 390px; top: 342px; position: absolute; height: 153px; width: 440px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 688px; top: 507px; position: absolute; width: 145px; " Text="Submit Request" />
    </form>
</body>
</html>
