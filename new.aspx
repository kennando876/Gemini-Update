<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new.aspx.cs" Inherits="Gemini.NewApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Application
    </title>
    <link rel="stylesheet" type="text/css" href="styles/new.css" />
    <script src="Scripts/jquery-3.4.1.js"></script>
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

        <asp:Label ID="MessageLabel" runat="server" Text="  "></asp:Label>


        <input id="isMarried" type="hidden" runat="server" />
        <input id="isDependent" type="hidden" runat="server" />
        <input id="isSaved" type="hidden" runat="server" />

<main id="main" runat="server">
        <!-- PAGE 0 STARTS-->
        <div id="pg0" style="display: block" runat="server">
            <div id="PersonalInformation">

                <h3>Application Type</h3>
                <asp:DropDownList ID="ApplicationTypeDropDownList" runat="server" placeholder="select beverage">
                    <asp:ListItem>Employment</asp:ListItem>
                    <asp:ListItem>Retirement</asp:ListItem>
                    <asp:ListItem>Marriage</asp:ListItem>
                    <asp:ListItem>Dependent</asp:ListItem>
                    <asp:ListItem Value="Previous Holder of U/L">Previous Holder of U/L</asp:ListItem>
                </asp:DropDownList>

                <h3>Applicant</h3>
                <hr />
                <div class="row">
                    <label for="">
                        Passport Number
                <br />
                        <asp:TextBox ID="AP_PassportTextBox" runat="server"></asp:TextBox>
                    </label>

                    <label for="">
                        TRN
                    <br />
                        <asp:TextBox ID="AP_TRNTextBox" runat="server"></asp:TextBox>
                    </label>

                </div>

                <div class="row">
                    <label for="">
                        ID Type
                        <br />
                        <asp:DropDownList ID="AP_IDTypeDropDownList" runat="server">
                            <asp:ListItem>Driver&#39;s License</asp:ListItem>
                            <asp:ListItem>Voter&#39;s</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                    </label>

                    <label for="">
                        ID Number
                        <br />
                        <asp:TextBox ID="AP_IDNumTextBox" runat="server"></asp:TextBox>
                    </label>
                </div>
                <div class="row">
                    <label for="TextBox1">
                        Firstname
                    <br />
                        <asp:TextBox ID="AP_FirstnameTextBox" runat="server"></asp:TextBox>
                    </label>

                    <label for="">
                        Middlename
                    <br />
                        <asp:TextBox ID="AP_MiddlenameTextBox" runat="server"></asp:TextBox>
                    </label>
                </div>
                <div class="row">
                    <label for="">
                        Alias
                  <br />
                        <asp:TextBox ID="AP_AliasTextBox" runat="server"></asp:TextBox>
                    </label>

                    <label for="">
                        Lastname
                    <br />
                        <asp:TextBox ID="AP_LastnameTextBox" runat="server"></asp:TextBox>
                    </label>

                </div>


                <h3>Personal Information</h3>
                <hr />
                <div class="row">
                    <label for="">
                        Occupation
                    <br />
                        <asp:TextBox ID="AP_OccupationTextBox" runat="server"></asp:TextBox>
                    </label>

                    <label for="">
                        Date of Birth
                    <br />
                        <input id="AP_DOBDateBox" type="date" runat="server" />
                    </label>
                </div>
                <div class="row">

                    <label for="">
                        Sex
                    <br />
                        <asp:DropDownList ID="AP_SexDropDownList" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </label>
                    <label for="">
                        Marital Status
                    <br />
                        <asp:DropDownList ID="AP_MaritalStatusDropDownList" runat="server">
                            <asp:ListItem>Single</asp:ListItem>
                            <asp:ListItem>Married</asp:ListItem>
                            <asp:ListItem>Divorced</asp:ListItem>
                            <asp:ListItem>Widowed</asp:ListItem>
                            <asp:ListItem>Common Law</asp:ListItem>
                        </asp:DropDownList>
                    </label>
                </div>

                <div class="row">
                    <label for="">
                        Place of Birth
                       <br />
                        <asp:DropDownList ID="AP_POBDropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                        <asp:SqlDataSource ID="Country" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;C:\Temp\GeminiUpdate\database\GeminiDB.mdf&quot;;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                    </label>
                    <label for="">
                        Nationality
                  <br />
                        <asp:DropDownList ID="AP_NationalityDropDownList" runat="server" DataSourceID="Nationality" DataTextField="Nationality" DataValueField="Nationality"></asp:DropDownList>
                        <asp:SqlDataSource ID="Nationality" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;C:\Temp\GeminiUpdate\database\GeminiDB.mdf&quot;;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Nationality] FROM [Country]"></asp:SqlDataSource>
                    </label>

                </div>



                <div class="btn-container">
                    <input id="Button1" type="button" class="btn" value="Back" style="visibility: hidden" />
                    <input id="AP_NextButton" type="button" class="btn" value="Next" onclick="ValidatePG0()" />
                </div>
            </div>
        </div>
        <!-- PAGE 0 ENDS-->

        <!-- PAGE 1 STARTS-->
        <div id="pg1" style="display: none" runat="server">

            <h3>Citizenships</h3>
            <hr />
            <div class="row">
                <label for="">
                    1. Country
                          <br />
                    <asp:DropDownList ID="AP_C1DropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                </label>
                <label for="">
                    2. Country
                          <br />
                    <asp:DropDownList ID="AP_C2DropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                </label>
            </div>
            <h3>Residency</h3>
            <hr />

            <div class="row">
                <label for="">
                    1. Previous Country of Residence
                          <br />
                    <asp:DropDownList ID="AP_PreviousResidenceDropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                </label>
                <label for="">
                    2. Length of Residence in Jamaica (months)
                          <br />
                    <asp:TextBox ID="AP_LengthOfResidenceTextBox" runat="server" TextMode="Number"></asp:TextBox>
                </label>
            </div>
            <h3>Language Preferences</h3>
            <hr />

            <div class="row">

                <label for="">
                    a. Primary Language
                    <br />
                    <select data-placeholder="Choose a Language..." id="AP_PrimaryLangDropDownList" runat="server">
                        <option></option>
                        <option value="Afrikaans">Afrikaans</option>
                        <option value="Albanian">Albanian</option>
                        <option value="Arabic">Arabic</option>
                        <option value="Armenian">Armenian</option>
                        <option value="Basque">Basque</option>
                        <option value="Bengali">Bengali</option>
                        <option value="Bulgarian">Bulgarian</option>
                        <option value="Catalan">Catalan</option>
                        <option value="Cambodian">Cambodian</option>
                        <option value="Chinese (Mandarin)">Chinese (Mandarin)</option>
                        <option value="Croatian">Croatian</option>
                        <option value="Czech">Czech</option>
                        <option value="Danish">Danish</option>
                        <option value="Dutch">Dutch</option>
                        <option value="English">English</option>
                        <option value="Estonian">Estonian</option>
                        <option value="Fiji">Fiji</option>
                        <option value="Finnish">Finnish</option>
                        <option value="French">French</option>
                        <option value="Georgian">Georgian</option>
                        <option value="German">German</option>
                        <option value="Greek">Greek</option>
                        <option value="Gujarati">Gujarati</option>
                        <option value="Hebrew">Hebrew</option>
                        <option value="Hindi">Hindi</option>
                        <option value="Hungarian">Hungarian</option>
                        <option value="Icelandic">Icelandic</option>
                        <option value="Indonesian">Indonesian</option>
                        <option value="Irish">Irish</option>
                        <option value="Italian">Italian</option>
                        <option value="Japanese">Japanese</option>
                        <option value="Javanese">Javanese</option>
                        <option value="Korean">Korean</option>
                        <option value="Latin">Latin</option>
                        <option value="Latvian">Latvian</option>
                        <option value="Lithuanian">Lithuanian</option>
                        <option value="Macedonian">Macedonian</option>
                        <option value="Malay">Malay</option>
                        <option value="Malayalam">Malayalam</option>
                        <option value="Maltese">Maltese</option>
                        <option value="Maori">Maori</option>
                        <option value="Marathi">Marathi</option>
                        <option value="Mongolian">Mongolian</option>
                        <option value="Nepali">Nepali</option>
                        <option value="Norwegian">Norwegian</option>
                        <option value="Persian">Persian</option>
                        <option value="Polish">Polish</option>
                        <option value="Portuguese">Portuguese</option>
                        <option value="Punjabi">Punjabi</option>
                        <option value="Quechua">Quechua</option>
                        <option value="Romanian">Romanian</option>
                        <option value="Russian">Russian</option>
                        <option value="Samoan">Samoan</option>
                        <option value="Serbian">Serbian</option>
                        <option value="Slovak">Slovak</option>
                        <option value="Slovenian">Slovenian</option>
                        <option value="Spanish">Spanish</option>
                        <option value="Swahili">Swahili</option>
                        <option value="Swedish ">Swedish </option>
                        <option value="Tamil">Tamil</option>
                        <option value="Tatar">Tatar</option>
                        <option value="Telugu">Telugu</option>
                        <option value="Thai">Thai</option>
                        <option value="Tibetan">Tibetan</option>
                        <option value="Tonga">Tonga</option>
                        <option value="Turkish">Turkish</option>
                        <option value="Ukrainian">Ukrainian</option>
                        <option value="Urdu">Urdu</option>
                        <option value="Uzbek">Uzbek</option>
                        <option value="Vietnamese">Vietnamese</option>
                        <option value="Welsh">Welsh</option>
                        <option value="Xhosa">Xhosa</option>
                    </select>
                </label>

                <label for="">
                    b. Secondary Language
                    <br />
                    <select data-placeholder="Choose a Language..." id="AP_SecondaryLangDropDownList" runat="server">
                        <option></option>
                        <option value="Afrikaans">Afrikaans</option>
                        <option value="Albanian">Albanian</option>
                        <option value="Arabic">Arabic</option>
                        <option value="Armenian">Armenian</option>
                        <option value="Basque">Basque</option>
                        <option value="Bengali">Bengali</option>
                        <option value="Bulgarian">Bulgarian</option>
                        <option value="Catalan">Catalan</option>
                        <option value="Cambodian">Cambodian</option>
                        <option value="Chinese (Mandarin)">Chinese (Mandarin)</option>
                        <option value="Croatian">Croatian</option>
                        <option value="Czech">Czech</option>
                        <option value="Danish">Danish</option>
                        <option value="Dutch">Dutch</option>
                        <option value="English">English</option>
                        <option value="Estonian">Estonian</option>
                        <option value="Fiji">Fiji</option>
                        <option value="Finnish">Finnish</option>
                        <option value="French">French</option>
                        <option value="Georgian">Georgian</option>
                        <option value="German">German</option>
                        <option value="Greek">Greek</option>
                        <option value="Gujarati">Gujarati</option>
                        <option value="Hebrew">Hebrew</option>
                        <option value="Hindi">Hindi</option>
                        <option value="Hungarian">Hungarian</option>
                        <option value="Icelandic">Icelandic</option>
                        <option value="Indonesian">Indonesian</option>
                        <option value="Irish">Irish</option>
                        <option value="Italian">Italian</option>
                        <option value="Japanese">Japanese</option>
                        <option value="Javanese">Javanese</option>
                        <option value="Korean">Korean</option>
                        <option value="Latin">Latin</option>
                        <option value="Latvian">Latvian</option>
                        <option value="Lithuanian">Lithuanian</option>
                        <option value="Macedonian">Macedonian</option>
                        <option value="Malay">Malay</option>
                        <option value="Malayalam">Malayalam</option>
                        <option value="Maltese">Maltese</option>
                        <option value="Maori">Maori</option>
                        <option value="Marathi">Marathi</option>
                        <option value="Mongolian">Mongolian</option>
                        <option value="Nepali">Nepali</option>
                        <option value="Norwegian">Norwegian</option>
                        <option value="Persian">Persian</option>
                        <option value="Polish">Polish</option>
                        <option value="Portuguese">Portuguese</option>
                        <option value="Punjabi">Punjabi</option>
                        <option value="Quechua">Quechua</option>
                        <option value="Romanian">Romanian</option>
                        <option value="Russian">Russian</option>
                        <option value="Samoan">Samoan</option>
                        <option value="Serbian">Serbian</option>
                        <option value="Slovak">Slovak</option>
                        <option value="Slovenian">Slovenian</option>
                        <option value="Spanish">Spanish</option>
                        <option value="Swahili">Swahili</option>
                        <option value="Swedish ">Swedish </option>
                        <option value="Tamil">Tamil</option>
                        <option value="Tatar">Tatar</option>
                        <option value="Telugu">Telugu</option>
                        <option value="Thai">Thai</option>
                        <option value="Tibetan">Tibetan</option>
                        <option value="Tonga">Tonga</option>
                        <option value="Turkish">Turkish</option>
                        <option value="Ukrainian">Ukrainian</option>
                        <option value="Urdu">Urdu</option>
                        <option value="Uzbek">Uzbek</option>
                        <option value="Vietnamese">Vietnamese</option>
                        <option value="Welsh">Welsh</option>
                        <option value="Xhosa">Xhosa</option>
                    </select>
                </label>

            </div>

            <h3>Contact Information</h3>
            <hr />
            <div id="APContact" runat="server">
                <div class="row">
                    <label for="">
                        Street
                        <br />
                        <asp:TextBox ID="AP_StreetAddressTextBox" runat="server"></asp:TextBox>
                    </label>
                    <label for="">
                        Town
                          <br />
                        <asp:TextBox ID="AP_TownAddressTextBox" runat="server"></asp:TextBox>
                    </label>
                </div>

                <div class="row">
                    <label for="">
                        Parish/City
                          <br />
                        <asp:TextBox ID="AP_CityAddressTextBox" runat="server"></asp:TextBox>
                    </label>


                    <label for="">
                        Country
                          <br />
                        <asp:DropDownList ID="AP_CountryAddressDropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                    </label>
                </div>
                <div class="row">
                    <label for="">
                        House Number
                        <br />
                        <asp:TextBox ID="AP_HouseNumTextBox" runat="server"></asp:TextBox>
                    </label>

                    <label for="">
                        Business Number
                        <br />
                        <asp:TextBox ID="AP_BusinessNumTextBox" runat="server"></asp:TextBox>
                    </label>
                </div>

                <div class="row">
                    <label for="">
                        Cell Number
                        <br />
                        <asp:TextBox ID="AP_CellNumTextBox" runat="server"></asp:TextBox>
                    </label>

                    <label for="">
                        Email
                        <br />
                        <asp:TextBox ID="AP_EmailTextBox" runat="server"></asp:TextBox>
                        <%--<input type ="email" id="AP_EmailBox" runat="server"/>--%>
                    </label>
                </div>
            </div>
            <div class="btn-container">
                <input id="AP_BackButton" type="button" class="btn" value="Back" onclick="GoBack1()" />
                <input id="AP_NextButton2" type="button" class="btn" value="Next" />
            </div>
        </div>
        <!-- PAGE 1 ENDS-->

        <!-- PAGE 2 STARTS-->
        <div id="pg2" style="display: none" runat="server">
            <h3>Spouse</h3>
            <hr />

            <div class="row">
                <label for="TextBox1">
                    Firstname
                    <br />
                    <asp:TextBox ID="SP_FirstnameTextBox" runat="server"></asp:TextBox>
                </label>

                <label for="">
                    Middlename
                    <br />
                    <asp:TextBox ID="SP_MiddlenameTextBox" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="row">
                <label for="">
                    Maiden Name
                  <br />
                    <asp:TextBox ID="SP_MaidennameTextBox" runat="server"></asp:TextBox>
                </label>

                <label for="">
                    Lastname
                    <br />
                    <asp:TextBox ID="SP_LastnameTextBox" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="row">
                <label for="">
                    Sex
                    <br />
                    <asp:DropDownList ID="SP_SexDropDownList" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </label>

                <label for="">
                    Date of Marriage
                    <br />
                    <input id="SP_DOMDateBox" type="date" runat="server" />
                </label>

            </div>
            <div class="row">
                <label for="">
                    Date of Birth
                    <br />
                    <input id="SP_DOBDateBox" type="date" runat="server" />
                </label>

                <label for="">
                    Place of Birth
                       <br />
                    <asp:DropDownList ID="SP_POBDropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;C:\Temp\GeminiUpdate\database\GeminiDB.mdf&quot;;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                </label>
            </div>
            <div class="row">

                <label for="">
                    Nationality
                  <br />
                    <asp:DropDownList ID="SP_NationalityDropDownList" runat="server" DataSourceID="Nationality" DataTextField="Nationality" DataValueField="Nationality"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;C:\Temp\GeminiUpdate\database\GeminiDB.mdf&quot;;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Nationality] FROM [Country]"></asp:SqlDataSource>
                </label>
                <label for="">
                    Occupation
                    <br />
                    <asp:TextBox ID="SP_OccupationTextBox" runat="server"></asp:TextBox>
                </label>

            </div>

            <h3>Contact Information</h3>
            <hr />
            <label for="SP_SameAsAppCheckbox">
                <input id="SP_SameAsAppCheckbox" type="checkbox" onclick="AutofillAdress('SP_')" />
                Same as applicant
            </label>
            <div class="row">
                <label for="">
                    Street
                        <br />
                    <asp:TextBox ID="SP_StreetAddressTextBox" runat="server"></asp:TextBox>
                </label>
                <label for="">
                    Town
                          <br />
                    <asp:TextBox ID="SP_TownAddressTextBox" runat="server"></asp:TextBox>
                </label>
            </div>

            <div class="row">
                <label for="">
                    Parish/City
                          <br />
                    <asp:TextBox ID="SP_CityAddressTextBox" runat="server"></asp:TextBox>
                </label>


                <label for="">
                    Country
                          <br />
                    <asp:DropDownList ID="SP_CountryAddressDropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                </label>
            </div>
            <div class="row">

                <label for="">
                    House Number
                        <br />
                    <asp:TextBox ID="SP_HouseNumTextBox" runat="server"></asp:TextBox>
                </label>
                <label for="">
                    Business Number
                        <br />
                    <asp:TextBox ID="SP_BusinessNumTextBox" runat="server"></asp:TextBox>
                </label>

            </div>
            <div class="row">

                <label for="">
                    Cell Number
                        <br />
                    <asp:TextBox ID="SP_CellNumTextBox" runat="server"></asp:TextBox>
                </label>

                <label for="">
                    Email
                        <br />
                    <asp:TextBox ID="SP_EmailTextBox" runat="server"></asp:TextBox>
                </label>


            </div>

            <div class="btn-container">
                <input id="SP_BackButton" type="button" class="btn" value="Back" onclick="GoBack2()" />
                <input id="SP_NextButton" type="button" class="btn" value="Save AP" onclick="ValidatePG2()"/>
            </div>
        </div>

        <!-- PAGE 2 ENDS-->

        <!-- PAGE 3 STARTS-->


        <div id="pg3" style="display: none" runat="server">
            <h3>Dependant 1</h3>
            <hr />

            <div class="row">
                <label for="TextBox1">
                    Firstname
                    <br />
                    <asp:TextBox ID="DP_FirstnameTextBox" runat="server"></asp:TextBox>
                </label>

                <label for="">
                    Middlename
                    <br />
                    <asp:TextBox ID="DP_MiddlenameTextBox" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="row">
                <label for="">
                    Alias
                  <br />
                    <asp:TextBox ID="DP_AliasTextBox" runat="server"></asp:TextBox>
                </label>

                <label for="">
                    Lastname
                    <br />
                    <asp:TextBox ID="DP_LastnameTextBox" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="row">
                <label for="">
                    Sex
                    <br />
                    <asp:DropDownList ID="DP_SexDropDownList" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </label>
                <label for="">
                    Date of Birth
                    <br />
                    <input id="DP_DOBDateBox" type="date" runat="server" />
                </label>

            </div>
            <div class="row">

                <label for="">
                    Place of Birth
                       <br />
                    <asp:DropDownList ID="DP_POBDropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;C:\Temp\GeminiUpdate\database\GeminiDB.mdf&quot;;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                </label>

                <label for="">
                    Relationship to Applicant
                    <br />
                    <asp:DropDownList ID="DP_RelationshipDropDownList" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Mother</asp:ListItem>
                        <asp:ListItem>Father</asp:ListItem>
                        <asp:ListItem>Sister</asp:ListItem>
                        <asp:ListItem>Brother</asp:ListItem>
                        <asp:ListItem>Son</asp:ListItem>
                        <asp:ListItem>Daughter</asp:ListItem>
                        <asp:ListItem>Uncle</asp:ListItem>
                        <asp:ListItem>Aunt</asp:ListItem>
                        <asp:ListItem>Grandmother</asp:ListItem>
                        <asp:ListItem>Grandfather</asp:ListItem>
                        <asp:ListItem>Cousin</asp:ListItem>
                    </asp:DropDownList>
                </label>
            </div>

            <h3>Contact Information</h3>
            <hr />
            <label for="DP_SameAsAppCheckbox">
                <input id="DP_SameAsAppCheckbox" type="checkbox" onclick="AutofillAdress('DP_')" />
                Same as applicant
            </label>
            <div class="row">
                <label for="">
                    Street
                        <br />
                    <asp:TextBox ID="DP_StreetAddressTextBox" runat="server"></asp:TextBox>
                </label>
                <label for="">
                    Town
                          <br />
                    <asp:TextBox ID="DP_TownAddressTextBox" runat="server"></asp:TextBox>
                </label>
            </div>

            <div class="row">
                <label for="">
                    Parish/City
                          <br />
                    <asp:TextBox ID="DP_CityAddressTextBox" runat="server"></asp:TextBox>
                </label>


                <label for="">
                    Country
                          <br />
                    <asp:DropDownList ID="DP_CountryAddressDropDownList" runat="server" DataSourceID="Country" DataTextField="CountryName" DataValueField="CountryName"></asp:DropDownList>
                </label>
            </div>
            <div class="row">

                <label for="">
                    House Number
                        <br />
                    <asp:TextBox ID="DP_HouseNumTextBox" runat="server"></asp:TextBox>
                </label>
                <label for="">
                    Business Number
                        <br />
                    <asp:TextBox ID="DP_BusinessNumTextBox" runat="server"></asp:TextBox>
                </label>
            </div>
            <div class="row">

                <label for="">
                    Cell Number
                        <br />
                    <asp:TextBox ID="DP_CellNumTextBox" runat="server"></asp:TextBox>
                </label>
                <label for="">
                    Email
                        <br />
                    <asp:TextBox ID="DP_EmailTextBox" runat="server"></asp:TextBox>
                </label>
            </div>

            <div class="btn-container">


                <input id="DP_BackButton" type="button" class="btn" value="Back" onclick="GoBack3()" />
                <input id="DP_SaveButton" type="button" class="btn" value="Save" onclick="ValidatePG3()" />

                <asp:Button ID="SaveButton" CssClass="btn" runat="server" Text="Save" OnClick="SaveButton_Click" UseSubmitBehavior="False" />
                <%--<asp:Button ID="AddNewButton" CssClass="btn" runat="server" Text="Add New" UseSubmitBehavior="False" />--%>
            </div>

        </div>

        <!-- PAGE 3 ENDS-->


        <!-- -->
        <div id="pg4" style="display: none" runat="server">

            <asp:Label ID="WarningLabel" runat="server" Text=""></asp:Label>
            <br />

            <div id="file-container">

                
                <div class="file-row">
                    <embed class="preview" id="ppfu" />
                    <label class="file-upload" for="PassportPhoto_FileUpload">
                        <span><strong>Passport Photo</strong></span>
                        <br />
                        <asp:FileUpload ID="PassportPhoto_FileUpload" runat="server" onchange="document.getElementById('ppfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>

                <div class="file-row">
                    <embed class="preview" id="pfu" />
                    <label class="file-upload" for="Passport_FileUpload">
                        <span><strong>Passport</strong></span>
                        <br />
                        <asp:FileUpload ID="Passport_FileUpload" runat="server" onchange="document.getElementById('pfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>

                 <div class="file-row">
                    <embed class="preview" id="evfu" />
                    <label class="file-upload" for="EntryVisa_FileUpload">
                        <span><strong>Entry Visa</strong></span>
                        <br />
                        <asp:FileUpload ID="EntryVisa_FileUpload" runat="server" onchange="document.getElementById('evfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>


                <div class="file-row">
                    <embed class="preview" id="bcfu" />
                    <label class="file-upload" for="BirthCertificate_FileUpload">
                        <span><strong>Birth Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="BirthCertificate_FileUpload" runat="server" onchange="document.getElementById('bcfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>

                
                <div class="file-row">
                    <embed class="preview" id="mcfu" />
                    <label class="file-upload" for="MarriageCertificate_FileUpload">
                        <span><strong>Marriage Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="MarriageCertificate_FileUpload" runat="server" onchange="document.getElementById('mcfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>

                
                <div class="file-row">
                    <embed class="preview" id="pcbcfu" />
                    <label class="file-upload" for="ChildrenBirthCertificate_FileUpload">
                        <span><strong>Children's Birth Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="ChildrenBirthCertificate_FileUpload" runat="server" onchange="document.getElementById('pcbcfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>


                 
                <div class="file-row">
                    <embed class="preview" id="spbcfu" />
                    <label class="file-upload" for="SpouseBirthCertificate_FileUpload">
                        <span><strong>Spouse's Birth Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="SpouseBirthCertificate_FileUpload" runat="server" onchange="document.getElementById('spbcfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>



                <div class="file-row">
                    <embed class="preview" id="dfu" />
                    <label class="file-upload" for="Divorce_FileUpload">
                        <span><strong>Decree Absolute</strong></span>
                        <br />
                        <asp:FileUpload ID="Divorce_FileUpload" runat="server" onchange="document.getElementById('dfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>


                <div class="file-row">
                    <embed class="preview" id="lmfu" />
                    <label class="file-upload" for="LocalMedicalCertificate_FileUpload">
                        <span><strong>Local Medical Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="LocalMedicalCertificate_FileUpload" runat="server" onchange="document.getElementById('lmfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>

                <div class="file-row">
                    <embed class="preview" id="fsfu" />
                    <label class="file-upload" for="FinancialStatus_FileUpload">
                        <span><strong>Evidence of Financial Status</strong></span>
                        <br />
                        <asp:FileUpload ID="FinancialStatus_FileUpload" runat="server" onchange="document.getElementById('fsfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>

                <div class="file-row">
                    <embed class="preview" id="rlfu" />
                    <label class="file-upload" for="ResidenceLetter_FileUpload">
                        <span><strong>Residency Request Letter</strong></span>
                        <br />
                        <asp:FileUpload ID="ResidenceLetter_FileUpload" runat="server" onchange="document.getElementById('rlfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>


                <div class="file-row">
                    <embed class="preview" id="tcfu" />
                    <label class="file-upload" for="TaxCompliance_FileUpload">
                        <span><strong>Tax Compliance Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="TaxCompliance_FileUpload" runat="server" onchange="document.getElementById('tcfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>


                <%-- <div class="file-row">
                    <embed class="preview" id="fstatfu" />
                    <label class="file-upload" for="FinancialStatement_FileUpload">
                        <span><strong>Audited Financial Statememt</strong></span>
                        <br />
                        <asp:FileUpload ID="FinancialStatement_FileUpload" runat="server" onchange="document.getElementById('fstatfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>--%>

                <div class="file-row">
                    <embed class="preview" id="brfu" />
                    <label class="file-upload" for="BusinessRegistration_FileUpload">
                        <span><strong>Business Registration Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="BusinessRegistration_FileUpload" runat="server" onchange="document.getElementById('brfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>

               
                <div class="file-row">
                    <embed class="preview" id="ppolfu" />
                    <label class="file-upload" for="PreviousPolice_FileUpload">
                        <span><strong>Previous Country Police Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="PreviousPolice_FileUpload" runat="server" onchange="document.getElementById('ppolfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>

                <div class="file-row">
                    <embed class="preview" id="lpfu" />
                    <label class="file-upload" for="LocalPolice_FileUpload">
                        <span><strong>Local Police Certificate</strong></span>
                        <br />
                        <asp:FileUpload ID="LocalPolice_FileUpload" runat="server" onchange="document.getElementById('lpfu').src = window.URL.createObjectURL(this.files[0])" />
                    </label>
                </div>         

            </div>


            <asp:Button ID="SubmitButton" class="btn" runat="server" Text="Submit" OnClick="SubmitButton_Click" UseSubmitBehavior="False" />
         
        </div>
        <!--PAGE 4 ENDS-->
    </main>
        <script src="jscript/new.js"></script>
        <script src="jscript/header.js"></script>


    </form>

</body>
</html>
