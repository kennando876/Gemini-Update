<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Gemini.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="styles/index.css" />
    <title>Log In</title>
</head>
<body>
    <header>
        <ul class="background">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
    </header>
    <form id="form1" runat="server">
        <div class="login">
            <img class="avatar" src="images/res/avatar.png" />
            <div class="tbox-container">
                <asp:TextBox ID="UsernameTextBox" class="username tbox" placeholder="Username" runat="server"></asp:TextBox>
                <asp:TextBox ID="PasswordTextBox" class="password tbox" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Button ID="LoginButton" class="login-btn" runat="server" Text="Log In" OnClick="LoginButton_Click" />
                
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
