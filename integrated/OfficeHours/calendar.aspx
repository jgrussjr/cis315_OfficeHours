<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendar.aspx.cs" Inherits="OfficeHours.calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Password1 {
            z-index: 1;
            left: 52px;
            top: 488px;
            position: absolute;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 548px; top: 101px; position: absolute; margin-bottom: 0px;" ></asp:Label>
        <asp:Button ID="Button2" runat="server" OnClientClick="window.location.href='http://localhost:2966/welcome.aspx'; return false;" style="z-index: 1; left: 13px; top: 94px; position: absolute" Text="Go Back" />
    </div>
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 390px; top: 354px; position: absolute" Text="Message for professor (optional):"></asp:Label>
        <asp:Table 
            CellPadding = "10" 
            CellSpacing="0"
            GridLines="Both"
            BorderWidth="3"
            BorderColor="Black"
            BorderStyle="Solid"

            ID="Table1" runat="server" style="z-index: 1; left: 389px; top: 124px; position: absolute; height: 220px; width: 443px">
        </asp:Table>
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 395px; top: 1px; position: absolute" Text="Office Hours Scheduling System" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <p>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 280px; top: 376px; position: absolute; bottom: 296px;" Text="Choose Time:"></asp:Label>
            <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 105px; top: 95px; position: absolute; width: 357px; height: 27px;" inputtype="text" placeholder="search" ></asp:Label>
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
        
        
        
        <asp:Image ID="Image1" runat="server"  onclick="window.location.href='http://localhost:2966/welcome.aspx'; return false;" ImageURL="~/Images/gannonlogo.png" style="z-index: 1; left: 0px; top: -5px; position: absolute; height: 80px; width: 190px; cursor:default; cursor:pointer; right: 1644px;" />
        
        
        
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" style="z-index: 1; left: 294px; top: 397px; position: absolute; height: 33px; width: 111px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Value="12:00">12:00</asp:ListItem>
            <asp:ListItem Value="12:30">12:30</asp:ListItem>
            <asp:ListItem Value="2:45">2:45</asp:ListItem>
            <asp:ListItem Value="3:15">3:15</asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" style="z-index: 1; resize:none; left: 387px; top: 380px; position: absolute; height: 153px; width: 440px"></asp:TextBox>
        
        <asp:DropDownList ID="DropDownList2" runat="server" autopostback="True" style="z-index: 1; left: 172px; top: 403px; position: absolute; right: 1546px;" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            <asp:ListItem>Brinkman</asp:ListItem>
            <asp:ListItem>Frezza</asp:ListItem>
            <asp:ListItem>Tang</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 153px; top: 376px; position: absolute" Text="Choose Professor:"></asp:Label>
        <asp:Label ID="Label8" runat="server" style="z-index: 1; left: 19px; top: 376px; position: absolute" Text="Department Filter:"></asp:Label>
        <asp:DropDownList ID="DropDownList3" autopostback="True" runat="server" style="z-index: 1; left: 17px; top: 403px; position: absolute" Width="125px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
            <asp:ListItem>Computer Science</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label9" runat="server" font-size="11pt" style="z-index: 1; left: 836px; top: 396px; position: absolute; height: 207px; width: 225px" Text="Note: Upon submission, the selected professor will receive a calender invitation for the selected date and time. The message you type will also be included with this email."></asp:Label>
        <asp:Label ID="Label10" runat="server" font-size="16pt" style="z-index: 1; left: 350px; top: 58px; position: absolute; width: 831px" Text=""></asp:Label>
        <asp:Label ID="Label11" runat="server" font-bold="True" font-size="14pt" style="z-index: 1; left: 925px; top: 127px; position: absolute; bottom: 550px" Text="Steps:" ForeColor="#990000"></asp:Label>
        <asp:Label ID="Label12" runat="server" style="z-index: 1; left: 843px; top: 161px; position: absolute; width: 438px; bottom: 516px" Text="1. Select a date (even if today's date)"></asp:Label>
        <asp:Label ID="Label13" runat="server" style="z-index: 1; left: 843px; top: 190px; position: absolute; bottom: 487px; width: 438px" Text="2. Select a department (optional)"></asp:Label>
        <asp:Label ID="Label14" runat="server" style="z-index: 1; left: 843px; top: 219px; position: absolute; right: 20px" Text="3. Select a time"></asp:Label>
        <asp:Label ID="Label16" runat="server" style="z-index: 1; left: 843px; top: 277px; position: absolute" Text="5. Submit Request"></asp:Label>
        <asp:Label ID="Label15" runat="server" style="z-index: 1; left: 843px; top: 248px; position: absolute; width: 438px" Text="4. Modify message (optional)"></asp:Label>
        <p>
            &nbsp;</p>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="z-index: 1; left: 722px; top: 545px; position: absolute" Text="Button" />
    </form>
</body>
</html>
