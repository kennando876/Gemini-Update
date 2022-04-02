<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Gemini.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link rel="stylesheet" type="text/css" href="styles/styling.css" />--%>
    <link rel="stylesheet" type="text/css" href="styles/home.css" />

    <script src="Scripts/jquery-3.4.1.js"></script>
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav>
                <img id="usericon" class="dropdwn" src="images/res/usericon.png" />
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
                <img id="notifications" runat="server" src="images/res/nonotification.png" />
                <asp:Label ID="NotificationCount" runat="server" Text="0"></asp:Label>
                <a href="search.aspx">
                    <img id="search" src="images/res/search.png" />
                </a>

                <%--<img id="home" src="images/res/home.png" />--%>
            </div>
            <asp:GridView ID="UserGridView" runat="server" Visible="False">
            </asp:GridView>

            <asp:GridView ID="NotificationGridView" runat="server" Visible="False">
            </asp:GridView>

            <div id="notificationContainer" runat="server">
            </div>

        </header>


        <main>
            <div class="card">
                <a href="new.aspx">
                    <div class="img-container">
                        <img src="images/res/add1.png" />
                    </div>
                    <h1>Add New</h1>
                </a>
            </div>

            <div class="card">
                <a href="search.aspx">
                    <div class="img-container">
                        <img src="images/res/tracking.png" />
                    </div>
                    <h1>Tracking</h1>
                </a>
            </div>

           <%-- <div class="card">
                <div class="img-container">
                    <img src="images/res/update.png" />
                </div>
                <h1>Update</h1>

            </div>
            <div class="card">
                <div class="img-container">
                    <img src="images/res/batch.png" />
                </div>
                <h1>Batch Management</h1>

            </div>--%>
        </main>
    </form>

    <script src="jscript/header.js"></script>

</body>
</html>
