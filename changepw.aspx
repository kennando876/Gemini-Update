<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepw.aspx.cs" Inherits="Gemini.changepw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="styles/changepw.css" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <title></title>
</head>
<body>


    <form id="form1" runat="server">
        <header>
            <nav>
                <img id="usericon" class="dropdwn" src="images/res/usericon.png" />
                <%--<input type="button" class="dropdwn" id="userbtn" value="Lorem Ipsum" runat="server" />--%>
                <asp:Label ID="userName" class="dropdwn" runat="server" Text="Lorem Ipsum"></asp:Label>
                <img id="angle" class="dropdwn" src="images/res/angledown.png" />
                <ul id="options">
                    <a href="changepw.aspx">
                        <li>Change Password</li>
                    </a>
                    <a href="index.aspx">
                        <li>Log out</li>
                    </a>
                </ul>
            </nav>
            <div class="header-right">
                <a href="home.aspx">
                    <img id="homepage" src="images/res/homepage.png" />
                </a>
                <img id="notifications" runat="server" src="images/res/nonotification.png" />
                <asp:Label ID="NotificationCount" runat="server" Text="0"></asp:Label>
                <a href="search.aspx">
                    <img id="search" src="images/res/search.png" />
                </a>

                <%--<img id="home" src="images/res/home.png" />--%>
            </div>
            <asp:GridView ID="NotificationGridView" runat="server" Visible="false">
            </asp:GridView>

            <div id="notificationContainer" runat="server">
            </div>

        </header>

        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>

        <div class="pw-container">
            <label for="OldTextBox">
                Old Password
            <asp:TextBox ID="OldTextBox" class="tbox" runat="server" TextMode="Password"></asp:TextBox>
            </label>
            <label for="NewTextBox">
                New Password
            <asp:TextBox ID="NewTextBox" class="tbox" runat="server" TextMode="Password"></asp:TextBox>
            </label>
            <label for="ComfirmTextBox">
                Confirm New Password
            <asp:TextBox ID="ComfirmTextBox" class="tbox" runat="server" TextMode="Password"></asp:TextBox>
            </label>
            <input id="SaveButton" type="button" value="Save" onclick="ValidatePW()" />

        </div>

        <asp:Button ID="Save" runat="server" Text="" BackColor="White" BorderColor="White" BorderStyle="None" OnClick="Save_Click" />
    </form>

    <script src="jscript/header.js"></script>
    <script src="jscript/changepw.js"></script>
</body>
</html>
