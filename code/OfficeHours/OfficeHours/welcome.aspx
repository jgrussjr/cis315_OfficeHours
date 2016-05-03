<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="OfficeHours.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="Button5">
    <div style="width: auto; margin: 0 10%;">
    
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 31px; top: 157px; position: absolute" Text="Login or"></asp:Label>
    
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 14px; top: 15px; position: absolute; height: 39px; width: 564px;" Text="Welcome to the Office Hours System!" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Validation1" ErrorMessage="Please enter a @knights.gannon.edu email address." style="z-index: 1; left: 269px; top: 190px; position: absolute" ControlToValidate="TextBox1" ValidationExpression="^[a-z]+[0-9]{3}@knights\.gannon\.edu" ForeColor="#CC0000"></asp:RegularExpressionValidator>
        <asp:TextBox ID="TextBox1" TextMode="Email" placeholder="Email" runat="server" style="z-index: 1; left: 16px; top: 184px; position: absolute; width: 246px; height: 27px;"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" placeholder="Password" TextMode="Password" style="z-index: 1; left: 16px; top: 222px; position: absolute; width: 246px; height: 27px;"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClientClick="window.location.href='http://localhost:2966/account.aspx'; return false;" style="z-index: 1; left: 99px; top: 155px; position: absolute; width: 145px;" Text="Create Account" />
    </div>
        
        
        
        <asp:Image ID="Image1" runat="server" ImageURL="~/Images/gannonlogo.png" style="z-index: 1; left: 18px; top: 57px; position: absolute; height: 80px; width: 190px" />
        
        
        
        <p>
            &nbsp;</p>
        
        
        
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" style="z-index: 1; left: 211px; top: 259px; position: absolute" Text="Login" />
        
        
        
        <asp:Label ID="Label3" runat="server"  font-size="16" ForeColor="#009933" style="z-index: 1; left: 281px; top: 81px; position: absolute; width: 529px"></asp:Label>
        
        
        
    </form>
</body>
</html>
