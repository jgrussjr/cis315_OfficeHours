<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="OfficeHours.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 14px; top: 64px; position: absolute" Text="Select a professor:"></asp:Label>
    
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 14px; top: 15px; position: absolute; height: 39px; width: 564px;" Text="Welcome to the Office Hours System!" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    
    </div>
        <asp:DropDownList ID="DropDownList1" runat="server" style="position: absolute; top: 96px; left: 15px;">
            <asp:ListItem Value="brinkman001">Brinkman</asp:ListItem>
            <asp:ListItem Value="frezza001">Frezza</asp:ListItem>
            <asp:ListItem Value="tang001">Tang</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 201px; top: 66px; position: absolute" Text="Enter your @knights.gannon.edu email:"></asp:Label>
        <asp:TextBox ID="TextBox1" placeholder="ex: deere001@knights.gannon.edu" runat="server" style="z-index: 1; left: 201px; top: 94px; position: absolute; width: 284px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server"  OnClientClick="window.location.href='http://localhost:2966/calendar.aspx'; return false;" style="z-index: 1; left: 500px; top: 93px; position: absolute" Text="Go!" />
    </form>
</body>
</html>
