<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="OfficeHours.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: auto; margin: 0 10%;">
            <p>
    
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 393px; top: 21px; position: absolute; height: 39px; width: 290px;" Text="Create an Account" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    
        </p>
        <asp:TextBox ID="TextBox1" runat="server" style="z-index: 1; left: 406px; top: 132px; position: absolute; margin-bottom: 0px;"></asp:TextBox>
        
        <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 408px; top: 94px; position: absolute" Text="First Name:"></asp:Label>
        
        <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 407px; top: 171px; position: absolute" Text="Last Name:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" style="z-index: 1; left: 406px; top: 205px; position: absolute"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 404px; top: 249px; position: absolute" Text="Email (Must be @knights.gannon.edu):"></asp:Label>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Validation1" ErrorMessage="Please enter a @knights.gannon.edu email address." style="z-index: 1; left: 579px; top: 289px; position: absolute" ControlToValidate="TextBox3" ValidationExpression="^[a-z]+[0-9]{3}@knights\.gannon\.edu" ForeColor="#CC0000"></asp:RegularExpressionValidator>
        <asp:TextBox ID="TextBox3" runat="server" style="z-index: 1; left: 405px; top: 289px; position: absolute"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 403px; top: 323px; position: absolute" Text="Password:"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" style="z-index: 1; left: 404px; top: 357px; position: absolute"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" style="z-index: 1; left: 404px; top: 401px; position: absolute" Text="Re-enter Password:"></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" style="z-index: 1; left: 404px; top: 440px; position: absolute"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" style="z-index: 1; left: 456px; top: 487px; position: absolute" Text="Submit" OnClick="Button1_Click" ValidationGroup="Validation1" CausesValidation="true"/>
        
        
        
        <asp:Image ID="Image1" runat="server"  onclick="window.location.href='/welcome.aspx'; return false;" ImageURL="~/Images/gannonlogo.png" style="z-index: 1; left: 0px; top: -5px; position: absolute; height: 80px; width: 190px; cursor:default; cursor:pointer" />
        
        
        
    </div>

        

        <%--<asp:Label ID="Label9" runat="server" style="z-index: 1; left: 624px; top: 293px; position: absolute" Text=""></asp:Label>--%>

        

    </form>
</body>
</html>
