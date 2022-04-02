<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="filespage.aspx.cs" Inherits="Gemini.filespage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="styles/filespage.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>

    <title>Files</title>
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
            <asp:GridView ID="NotificationGridView" runat="server" Visible="False">
            </asp:GridView>

            <div id="notificationContainer" runat="server">
            </div>

        </header>

        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

        <div id="psizeContainer">
            Preview Size: 
            <input type="button" value="Small" onclick="Small()"/> 
            <input type="button" value="Medium" onclick="Medium()"/> 
            <input type="button" value="Large" onclick="Large()"/> 
        </div>


        <div id="fileContainer" runat="server">

            <asp:GridView ID="FilesGridView" runat="server" Visible="false"></asp:GridView>

        </div>
    </form>

    <script src="jscript/header.js"></script>
    <script>
        function Small() {
            $(".file-holder").css("width", "15vw");
            $(".file-holder").css("height", "20vh");
            $(".fileRow").css("margin", "20px 30px");

        }

        function Medium() {
            $(".file-holder").css("width", "35vw");
            $(".file-holder").css("height", "45vh");
            $(".fileRow").css("margin", "20px 100px");

        }

        function Large() {
            $(".file-holder").css("width", "45vw");
            $(".file-holder").css("height", "60vh");
            $(".fileRow").css("margin", "20px 30px");

        }
    </script>

</body>
</html>
