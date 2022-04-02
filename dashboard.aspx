<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="approval.DCEO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Approver's Dashboard</title>
    <link href="styles/dashboard.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>




    <style type="text/css">
        .auto-style1 {
            width: 100%;
            display: inline-block;
            margin-left: 10px;
            padding: 10px;
        }

        .auto-style4 {
            height: 26px;
            width: 127px;
        }

        .auto-style6 {
            height: 23px;
            width: 127px;
        }

        .auto-style11 {
            height: 26px;
            width: 242px;
        }

        .auto-style12 {
            height: 23px;
            width: 242px;
        }

        .auto-style14 {
            width: 242px;
        }

        .auto-style15 {
            width: 201px;
            height: 190px;
        }

        .auto-style27 {
            width: 234px;
        }

        .auto-style28 {
            height: 23px;
            width: 234px;
        }

        .auto-style30 {
            height: 26px;
            width: 243px;
        }

        .auto-style31 {
            height: 23px;
            width: 243px;
        }

        .auto-style32 {
            width: 243px;
        }

        .newStyle1 {
            font-family: "Times New Roman", Times, serif;
            background-color: #999999;
        }

        .auto-style39 {
            text-align: center;
            height: 22px;
            background-color: #FFFFFF;
        }

        .auto-style40 {
            width: 234px;
            height: 27px;
        }

        .auto-style41 {
            width: 243px;
            height: 27px;
        }

        .auto-style42 {
            width: 242px;
            height: 27px;
        }

        .auto-style43 {
            height: 27px;
            width: 127px;
        }

        .auto-style44 {
            width: 127px;
        }

        .auto-style45 {
            width: 234px;
            height: 6px;
        }

        .auto-style46 {
            width: 243px;
            height: 6px;
        }

        .auto-style47 {
            width: 242px;
            height: 6px;
        }

        .auto-style48 {
            height: 6px;
            width: 127px;
        }

        .auto-style49 {
            width: 234px;
            height: 5px;
        }

        .auto-style50 {
            width: 243px;
            height: 5px;
        }

        .auto-style51 {
            width: 242px;
            height: 5px;
        }

        .auto-style52 {
            height: 5px;
            width: 127px;
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
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>

        <asp:GridView ID="ApplicantGridView" runat="server" Visible="false"></asp:GridView>
        <asp:GridView ID="RecommendGridView" runat="server" Visible="false"></asp:GridView>
        <asp:GridView ID="ApplicationGridview" runat="server" Visible="False"></asp:GridView>


        <main id="main" runat="server">

            <div id="tableContainer">

                <table class="auto-style1">
                    <tr>
                        <td class="auto-style39" colspan="4">
                            <asp:LinkButton ID="ApplicationLink" runat="server" OnClick="ApplicationLink_Click" CausesValidation="False">LinkButton</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style39" colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style27" rowspan="6">
                            <asp:Image ID="ApplicantImg" runat="server" />

                        </td>
                        <td class="auto-style30">Firstname</td>
                        <td class="auto-style11">Middlename</td>
                        <td class="auto-style4">Lastname</td>

                    </tr>
                    <tr>
                        <td class="auto-style31">
                            <asp:Label ID="FirstnameLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="MiddlenameLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="LastnameLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style31">&nbsp;</td>
                        <td class="auto-style12">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style32">
                            <asp:Label ID="DOB" runat="server" Text="Date of Birth"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:Label ID="nation" runat="server" Text="Nationality"></asp:Label>
                        </td>
                        <td class="auto-style44">Place of Birth</td>
                    </tr>
                    <tr>
                        <td class="auto-style30">
                            <asp:Label ID="DOBLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style11">
                            <asp:Label ID="NationalityLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style4">
                            <asp:Label ID="POBLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style30">&nbsp;</td>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style28">
                            <asp:Label ID="age" runat="server" Text="Age"></asp:Label>
                        </td>
                        <td class="auto-style31">Gender</td>
                        <td class="auto-style12">Marital Status</td>
                        <td class="auto-style6">Occupation</td>
                    </tr>
                    <tr>
                        <td class="auto-style40">
                            <asp:Label ID="AgeLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style41">
                            <asp:Label ID="GenderLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style42">
                            <asp:Label ID="MaritalStatusLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style43">
                            <asp:Label ID="OccupationLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style45"></td>
                        <td class="auto-style46"></td>
                        <td class="auto-style47"></td>
                        <td class="auto-style48"></td>
                    </tr>
                    <tr>
                        <td class="auto-style27">Passport Number</td>
                        <td class="auto-style32">TRN Number</td>
                        <td class="auto-style14">ID Type</td>
                        <td class="auto-style44">ID Number</td>
                    </tr>
                    <tr>
                        <td class="auto-style28">
                            <asp:Label ID="PassportLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="TRNLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="IDTypeLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="IDNumberLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style49"></td>
                        <td class="auto-style50"></td>
                        <td class="auto-style51"></td>
                        <td class="auto-style52"></td>
                    </tr>
                    <tr>
                        <td class="auto-style27">Citizenships</td>
                        <td class="auto-style32">Primary Language</td>
                        <td class="auto-style14">Secondary Language</td>
                        <td class="auto-style44">Length of Residency</td>
                    </tr>
                    <tr>
                        <td class="auto-style28">
                            <asp:Label ID="CitizenshipsLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="PriLangLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="SecLangLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="LenghResidencyLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style49"></td>
                        <td class="auto-style50"></td>
                        <td class="auto-style51"></td>
                        <td class="auto-style52"></td>
                    </tr>
                    <tr>
                        <td class="auto-style28">Street Address</td>
                        <td class="auto-style31">Town</td>
                        <td class="auto-style12">City/Parish</td>
                        <td class="auto-style6">Country</td>
                    </tr>
                    <tr>
                        <td class="auto-style28">
                            <asp:Label ID="StreetLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style31">
                            <asp:Label ID="TownLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style12">
                            <asp:Label ID="CityLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="CountryLabel" runat="server" Text="Label" CssClass="info-label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style49"></td>
                        <td class="auto-style50"></td>
                        <td class="auto-style51"></td>
                        <td class="auto-style52"></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <%--<textarea id="CommentTextBox" cols="20" name="S1" rows="2" runat="server" placeholder="Approver's note"></textarea></td>--%>
                            <asp:RequiredFieldValidator ID="CommentValidator" runat="server" ControlToValidate="CommentTextBox" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="CommentTextBox" runat="server" placeholder="Approver's note" TextMode="MultiLine"></asp:TextBox>
                    </tr>
                </table>

            </div>

            <div id="recContainer">
                <div id="recommendations" runat="server">
                    <h3 id="recHeader">Recomendations</h3>
                </div>
                <div id="btnContainer">
                    <asp:Button ID="ApproveButton" CssClass="btn" runat="server" Text="APPROVE" OnClick="ApproveButton_Click" />
                    <asp:Button ID="DenyButton" CssClass="btn" runat="server" Text="DENY" OnClick="DenyButton_Click" />
                    <asp:Button ID="DifferButton" CssClass="btn" runat="server" Text="DIFFER" OnClick="DifferButton_Click" />
                </div>
            </div>
        </main>
    </form>


    <script src="jscript/header.js"></script>



    <script>


        $(".btn").click(function (e) {
            if ($('#CommentValidator').is(":visible")) {
                $('#CommentTextBox').addClass('glow');
            }
        });



    </script>

</body>
</html>
