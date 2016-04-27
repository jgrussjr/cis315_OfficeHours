<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendar.aspx.cs" Inherits="OfficeHours.calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 548px; top: 99px; position: absolute; margin-bottom: 0px;" ></asp:Label>
        <asp:Button ID="Button2" runat="server" OnClientClick="window.location.href='http://localhost:2966/welcome.aspx'; return false;" style="z-index: 1; left: 17px; top: 92px; position: absolute" Text="Go Back" />
    </div>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 390px; top: 354px; position: absolute" Text="Message for professor (optional):"></asp:Label>
        <asp:Table 
            CellPadding = "10" 
            CellSpacing="0"
            GridLines="Both"
            BorderWidth="3"
            BorderColor="Black"
            BorderStyle="Solid"

            ID="Table1" runat="server" style="z-index: 1; left: 389px; top: 122px; position: absolute; height: 220px; width: 443px">
        </asp:Table>
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 283px; top: 1px; position: absolute" Text="Office Hours Scheduling System" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <p>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 209px; top: 376px; position: absolute" Text="Choose Time:"></asp:Label>
            <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 148px; top: 95px; position: absolute; width: 174px; height: 27px;" inputtype="text" placeholder="search" ></asp:Label>
            <asp:Calendar ID="Calendar1" runat="server" autopostback="true" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth" style="z-index: 1; left: 12px; top: 124px; position: absolute; height: 244px; width: 357px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
            </asp:Calendar>
        </p>
        
        
        
        <asp:Image ID="Image1" runat="server"  onclick="window.location.href='http://localhost:2966/welcome.aspx'; return false;" ImageURL="~/Images/gannonlogo.png" style="z-index: 1; left: 0px; top: 0px; position: absolute; height: 80px; width: 190px; cursor:default; cursor:pointer" />
        
        
        
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" autopostback="true" style="z-index: 1; left: 225px; top: 401px; position: absolute; height: 33px; width: 111px">
            <asp:ListItem Value="12:00">12:00</asp:ListItem>
            <asp:ListItem Value="12:30">12:30</asp:ListItem>
            <asp:ListItem Value="2:45">2:45</asp:ListItem>
            <asp:ListItem Value="3:15">3:15</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" style="z-index: 1; resize:none; left: 387px; top: 380px; position: absolute; height: 153px; width: 440px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" autopostback="true" style="z-index: 1; left: 690px; top: 547px; position: absolute; width: 145px; " Text="Submit Request" />
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" style="z-index: 1; left: 67px; top: 405px; position: absolute; right: 1651px;">
            <asp:ListItem>Brinkman</asp:ListItem>
            <asp:ListItem>Frezza</asp:ListItem>
            <asp:ListItem>Tang</asp:ListItem>
            
        </asp:DropDownList>
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 46px; top: 376px; position: absolute" Text="Choose Professor:"></asp:Label>
    </form>
</body>
</html>
