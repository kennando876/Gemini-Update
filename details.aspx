<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="Gemini.details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="styles/details.css" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <title>Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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


            <div id="Applicant">
                <h3>Applicant's Information</h3>
                <asp:GridView ID="ApplicantGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ApplicantSqlDataSource" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                        <asp:BoundField DataField="Middlename" HeaderText="Middlename" SortExpression="Middlename" />
                        <asp:BoundField DataField="Alias" HeaderText="Alias" SortExpression="Alias" />
                        <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                        <asp:BoundField DataField="MaritalStatus" HeaderText="MaritalStatus" SortExpression="MaritalStatus" />
                        <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
                        <asp:BoundField DataField="TRN" HeaderText="TRN" SortExpression="TRN" />
                        <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                        <asp:BoundField DataField="CitizenTwo" HeaderText="CitizenTwo" SortExpression="CitizenTwo" />
                        <asp:BoundField DataField="CitizenOne" HeaderText="CitizenOne" SortExpression="CitizenOne" />
                        <asp:BoundField DataField="SecondaryLanguage" HeaderText="SecondaryLanguage" SortExpression="SecondaryLanguage" />
                        <asp:BoundField DataField="PrimaryLanguage" HeaderText="PrimaryLanguage" SortExpression="PrimaryLanguage" />
                        <asp:BoundField DataField="Occupation" HeaderText="Occupation" SortExpression="Occupation" />
                        <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" />
                        <asp:BoundField DataField="POB" HeaderText="POB" SortExpression="POB" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:SqlDataSource ID="ApplicantSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:connectionString %>" SelectCommand="SELECT [Firstname], [Middlename], [Alias], [Lastname], [MaritalStatus], [Sex], [TRN], [DOB], [CitizenTwo], [CitizenOne], [SecondaryLanguage], [PrimaryLanguage], [Occupation], [Nationality], [POB] FROM [Applicants] WHERE ([ApplicantID] = @ApplicantID)">
                    <SelectParameters>
                        <asp:SessionParameter Name="ApplicantID" SessionField="Applicant" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>


            <div id="Spouse" runat="server">
                <h3>Spouse's Information</h3>

            <asp:GridView ID="SpouseGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SpouseSqlDataSource" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                    <asp:BoundField DataField="Middlename" HeaderText="Middlename" SortExpression="Middlename" />
                    <asp:BoundField DataField="Maidenname" HeaderText="Maidenname" SortExpression="Maidenname" />
                    <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                    <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                    <asp:BoundField DataField="POB" HeaderText="POB" SortExpression="POB" />
                    <asp:BoundField DataField="DOM" HeaderText="DOM" SortExpression="DOM" />
                    <asp:BoundField DataField="Occupation" HeaderText="Occupation" SortExpression="Occupation" />
                    <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SpouseSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:connectionString %>" SelectCommand="SELECT [Firstname], [Middlename], [Maidenname], [Lastname], [Sex], [DOB], [POB], [DOM], [Occupation], [Nationality] FROM [Spouses] WHERE ([ApplicationID_FK] = @ApplicationID_FK)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ApplicationID_FK" QueryStringField="id" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

            </div>



            <div id="Dependent" runat="server">
                <h3>Dependent's Information</h3>

            <asp:GridView ID="DependentGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DependentsSqlDataSource" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                    <asp:BoundField DataField="Middlename" HeaderText="Middlename" SortExpression="Middlename" />
                    <asp:BoundField DataField="Alias" HeaderText="Alias" SortExpression="Alias" />
                    <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                    <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
                    <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                    <asp:BoundField DataField="POB" HeaderText="POB" SortExpression="POB" />
                    <asp:BoundField DataField="RelationToApplicant" HeaderText="RelationToApplicant" SortExpression="RelationToApplicant" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="DependentsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:connectionString %>" SelectCommand="SELECT [Firstname], [Middlename], [Alias], [Lastname], [Sex], [DOB], [POB], [RelationToApplicant] FROM [Dependants] WHERE ([ApplicationID_FK] = @ApplicationID_FK)">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ApplicationID_FK" QueryStringField="id" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            </div>
        </div>
    </form>

    <script src="jscript/header.js"></script>

</body>
</html>
