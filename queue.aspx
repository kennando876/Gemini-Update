<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="queue.aspx.cs" Inherits="Gemini.queue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="styles/queue.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>

    <title>Queue</title>
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
        
        
        <div>
            <asp:GridView ID="QueueGridView" runat="server" Visible="false"></asp:GridView>

            <div id="queueContainer" runat="server"></div>

        </div>
    </form>

    <script src="jscript/header.js"></script>
</body>
</html>
