<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tracking.aspx.cs" Inherits="Gemini.trackupdates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="styles/tracking.css" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <title>Tracking</title>
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
                <%--<asp:ImageButton ID="Dashboard" runat="server" ImageUrl="~/images/res/dashboard.png" OnClick="Dashboard_Click" />--%>
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


        <main>

            <asp:Label ID="WarningLabel" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="" Font-Bold="True" Font-Size="Large"></asp:Label>

          


            <asp:GridView ID="CommentsGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False">
            </asp:GridView>

            <asp:GridView ID="ApplicantGridView" runat="server" Visible="False"></asp:GridView>


            <div id="commentsControls">
                <div id="actionCenter">
                    <h4 id="appID" runat="server"></h4>
                    <asp:Label ID="AppLocation" runat="server" Text="Label"></asp:Label>
                    <hr />
                    <div class="action-row">
                        <asp:Image ID="ProfileImage" runat="server" AlternateText="No photo available" />
                        <div class="cqv-info">
                            <asp:Label ID="ApplicantName" runat="server" Text="Shanice Lewis" Font-Size="Large"></asp:Label>
                            <asp:Label ID="ApplicantDOB" runat="server" Text="March 3, 1990" Font-Bold="False"></asp:Label>
                            <asp:Button ID="Dashboard" class="btn" runat="server" Text="Dashboard" OnClick="Dashboard_Click" />
                          
                            <%-- <asp:Label ID="Label4" runat="server" Text="Bahamian"></asp:Label>
                              <asp:Label ID="Label5" runat="server" Text="Marriage"></asp:Label>--%>
                        </div>
                    </div>
                    <hr />
                    <div class="v-btns">
                            <asp:Button ID="viewApp" class="btn" runat="server" Text="View" OnClick="viewApp_Click" />

                       <%-- <asp:Button ID="viewSpouse" class="btn" runat="server" Text="Spouse" />
                        <asp:Button ID="viewDependents" class="btn" runat="server" Text="Dependents" />--%>
                        <asp:Button ID="viewFiles" class="btn" runat="server" Text="Files" OnClick="viewFiles_Click" />
                    </div>
                    <hr />
                    <div class="c-type">
                        <label for="">Comment Type</label>
                        <br />
                        <asp:RadioButtonList ID="CommentTypeRadio" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Gen</asp:ListItem>
                            <asp:ListItem>Rec</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <hr />

                    <div class="c-filter">
                        <label for="">Filter Comments</label>
                        <asp:RadioButtonList ID="commentFilter" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="commentFilter_SelectedIndexChanged">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Trans</asp:ListItem>
                            <asp:ListItem>Rec</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                    <hr />


                    <%--<input type="button" class="btn transBtn" id="transbtn" value="Transfer" onclick="GetEmployees"/>--%>

                    <asp:Button ID="transbtn" class="btn transBtn" runat="server" Text="Transfer" OnClick="transbtn_Click"  />
                </div>


                <div id="comment_container" runat="server">
                </div>

            </div>
        </main>


        <div id="track" runat="server">

            <%--<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>--%>

            <label>Department</label>
            <asp:DropDownList ID="DeptDropDownList" runat="server" AutoPostBack="True" DataSourceID="DepartmentSqlDataSource" DataTextField="DepartmentName" DataValueField="DepartmentName" OnSelectedIndexChanged="DeptDropDownList_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server" Visible="False">
            </asp:GridView>

            <label>Employee</label>
            <asp:DropDownList ID="UserDropDownList" runat="server">
            </asp:DropDownList>

            <label>Reason</label>
            <asp:DropDownList ID="ReasonDropDownList" runat="server">
                <asp:ListItem>Review</asp:ListItem>
                <asp:ListItem>Investigation</asp:ListItem>
                <asp:ListItem>Approval</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="TransferButton" class="btn transBtn" runat="server" Text="Transfer" OnClick="TransferButton_Click" />

            <input type="button" id="closeTransfer" onclick="CloseTransfer()" />




            <asp:SqlDataSource ID="DepartmentSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:connectionString %>" SelectCommand="SELECT [DeptID], [DepartmentName] FROM [Departments]"></asp:SqlDataSource>
        </div>


        <footer class="update-box-container" id="update_container">
            <asp:TextBox ID="CommentTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" />
        </footer>


    </form>

    <script src="jscript/header.js"></script>

    <script>


        var tbx = document.getElementById('CommentTextBox');
        var container = document.getElementById('update_container');
        var aCenter = document.getElementById('actionCenter');
        var commentContainer = document.getElementById('comment_container');

        tbx.addEventListener("focus", GrowContainer);
        tbx.addEventListener("blur", ShrinkContainer);

        function GrowContainer() {
            container.style.height = '100px';
            commentContainer.style.marginBottom = '150px';
            if (tbx.value == "") {
                aCenter.style.marginTop = '15px';
                commentContainer.scrollBy(0, 55);
            }
        }

        function ShrinkContainer() {
            if (tbx.value == "") {
                commentContainer.scrollBy(0, -55);
                aCenter.style.marginTop = '15px';
                container.style.height = '45px';
                commentContainer.style.marginBottom = '75px';
            }
        }

        function CloseTransfer() {
            document.getElementById('track').style.display = 'none';
        }

        function ShowTransfer() {
            document.getElementById('track').style.display = 'block';
        }

    </script>

</body>
</html>
