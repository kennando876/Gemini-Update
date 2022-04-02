<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="search.aspx.cs" Inherits="Gemini.search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="styles/search.css" />
    <script src="Scripts/jquery-3.4.1.js"></script>


    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            text-align: right;
            width: 834px;
        }

        .auto-style3 {
            width: 290px;
        }

        .auto-style4 {
            width: 834px;
        }

        .auto-style5 {
            width: 891px;
        }
    </style>
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

        <main>

            <div id="searchControls">

                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style3">
                            <strong>SEARCH</strong></td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Application Number</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="ApplicationTextBox" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Application Type</td>
                        <td class="auto-style3">
                            <asp:DropDownList ID="ApplicationTypeDropDownList" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Employment</asp:ListItem>
                                <asp:ListItem>Retirement</asp:ListItem>
                                <asp:ListItem>Marriage</asp:ListItem>
                                <asp:ListItem>Dependent</asp:ListItem>
                                <asp:ListItem Value="Previous Holder of U/L">Previous Holder of U/L</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Date Entered</td>
                        <td class="auto-style3">
                            <input type="date" id="DateEntered" runat="server" /></td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Firstname</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="FirstnameTextBox" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Lastname</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="LastnameTextBox" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style3">&nbsp;
                            <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />

                        </td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style3"></td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                </table>

            </div>

            <div id="results" runat="server">
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>
                <asp:GridView ID="ResultsGridView" runat="server" BorderColor="#CCCCCC" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="ResultsGridView_RowDataBound" OnSelectedIndexChanged="ResultsGridView_SelectedIndexChanged" Width="605px">
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#007BFF" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#007BFF" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </div>
        </main>
    </form>

    <script src="jscript/header.js"></script>

</body>
</html>
