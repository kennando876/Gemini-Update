using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Gemini
{
    public partial class NewApplication : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                GetUser();
                PermissionCheck();
                GetNotifications();
            }
            
            else
            {
                Response.Redirect("index.aspx");
            }
          
            if (Page.IsPostBack)
            {
                pg0.Style["display"] = "none";
                pg1.Style["display"] = "none";
                pg2.Style["display"] = "none";
                pg3.Style["display"] = "none";
                pg4.Style["display"] = "block";
            }
        }

        int spouseID;
        int dependantID;

        public string ApplicantID
        {
            get { return AP_PassportTextBox.Text + DateTime.Today.Day + DateTime.Today.Month; }
        }

        public string ApplicationID
        {
            get { return ApplicantID + "APP"; }
            set { Session["AppID"] = value; }
        }

        public string SpouseID
        {
            get { return spouseID.ToString(); }
        }

        public string DependantID
        {
            get { return dependantID.ToString(); }
        }

        public void GetUser()
        {
            userName.Text = Session["Username"].ToString();
        }

        public void PermissionCheck()
        {
            if (Session["Role"].ToString() != "Creator")
            {
                main.Visible = false;
                MessageLabel.Text = "You do not have permission to create new applications";
            }
        }

        public void ApplicantInsert()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string insertApplicant = "insert into Applicants (ApplicantID, Firstname, Middlename, Alias, " +
                   "Lastname, MaritalStatus, Sex, TRN, DOB, POB, Nationality, Occupation, PrimaryLanguage," +
                   "SecondaryLanguage, CitizenOne, CitizenTwo, IDType, IDNumber, ResidencyLength) " +
                   "values(@id, @fn, @mn, @ali, @ln, @ms, @sex, " +
                   "@trn, @dob, @pob, @nat, @occ, @plang, @slang, @c1, @c2, @idtype, @idnum, @lor)";

                    SqlCommand AP_cmd = new SqlCommand(insertApplicant, connection);
                    AP_cmd.Parameters.AddWithValue("@id", ApplicantID);
                    AP_cmd.Parameters.AddWithValue("@fn", AP_FirstnameTextBox.Text);
                    AP_cmd.Parameters.AddWithValue("@mn", AP_MiddlenameTextBox.Text);
                    AP_cmd.Parameters.AddWithValue("@ali", AP_AliasTextBox.Text);
                    AP_cmd.Parameters.AddWithValue("@ln", AP_LastnameTextBox.Text);
                    AP_cmd.Parameters.AddWithValue("@ms", AP_MaritalStatusDropDownList.Text);
                    AP_cmd.Parameters.AddWithValue("@sex", AP_SexDropDownList.Text);
                    AP_cmd.Parameters.AddWithValue("@trn", AP_TRNTextBox.Text);
                    AP_cmd.Parameters.AddWithValue("@dob", AP_DOBDateBox.Value);
                    AP_cmd.Parameters.AddWithValue("@pob", AP_POBDropDownList.Text);
                    AP_cmd.Parameters.AddWithValue("@nat", AP_NationalityDropDownList.Text);
                    AP_cmd.Parameters.AddWithValue("@occ", AP_OccupationTextBox.Text);
                    AP_cmd.Parameters.AddWithValue("@plang", AP_PrimaryLangDropDownList.Value);
                    AP_cmd.Parameters.AddWithValue("@slang", AP_SecondaryLangDropDownList.Value);
                    AP_cmd.Parameters.AddWithValue("@c1", AP_C1DropDownList.Text);
                    AP_cmd.Parameters.AddWithValue("@c2", AP_C1DropDownList.Text);
                    AP_cmd.Parameters.AddWithValue("@idtype", AP_IDTypeDropDownList.SelectedValue);
                    AP_cmd.Parameters.AddWithValue("@idnum", AP_IDNumTextBox.Text);
                    AP_cmd.Parameters.AddWithValue("@lor", AP_LengthOfResidenceTextBox.Text);


                    AP_cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        private void ApplicationInsert()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string insertApplication = "insert into Applications values(@applicationid, @applicantid, @uid, @at, @fn, @last, " +
                        "@sstat, @ad, @as)";
                    SqlCommand APL_cmd = new SqlCommand(insertApplication, connection);
                    APL_cmd.Parameters.AddWithValue("@applicationid", ApplicationID);
                    APL_cmd.Parameters.AddWithValue("@applicantid", ApplicantID);
                    APL_cmd.Parameters.AddWithValue("@uid", Session["User"].ToString());
                    APL_cmd.Parameters.AddWithValue("@at", ApplicationTypeDropDownList.Text);
                    APL_cmd.Parameters.AddWithValue("@fn", 0);
                    APL_cmd.Parameters.AddWithValue("@last", "Submitted • Immigration Unit");
                    APL_cmd.Parameters.AddWithValue("@sstat", 0);
                    APL_cmd.Parameters.AddWithValue("@ad", DateTime.Now);
                    APL_cmd.Parameters.AddWithValue("@as", "Processing");

                    APL_cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        public int SpouseInsert()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string insertSpouse = "insert into Spouses (ApplicationID_FK, Firstname, Middlename," +
                        "Maidenname, Lastname, Sex, DOB,DOM, POB, Nationality, Occupation)" +
                        "values(@aid, @fn, @midn, @maidn, @ln, @sex, @dob, @dom, @pob, @nat, @occ); " +
                        "SELECT SCOPE_IDENTITY();  ";
                    SqlCommand SP_cmd = new SqlCommand(insertSpouse, connection);
                    SP_cmd.Parameters.Clear();
                    SP_cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    SP_cmd.Parameters.AddWithValue("@fn", SP_FirstnameTextBox.Text);
                    SP_cmd.Parameters.AddWithValue("@midn", SP_MiddlenameTextBox.Text);
                    SP_cmd.Parameters.AddWithValue("@maidn", SP_MaidennameTextBox.Text);
                    SP_cmd.Parameters.AddWithValue("@ln", SP_LastnameTextBox.Text);
                    SP_cmd.Parameters.AddWithValue("@sex", SP_SexDropDownList.Text);
                    SP_cmd.Parameters.AddWithValue("@dob", SP_DOBDateBox.Value);
                    SP_cmd.Parameters.AddWithValue("@dom", SP_DOMDateBox.Value);
                    SP_cmd.Parameters.AddWithValue("@pob", SP_POBDropDownList.Text);
                    SP_cmd.Parameters.AddWithValue("@nat", SP_NationalityDropDownList.Text);
                    SP_cmd.Parameters.AddWithValue("@occ", SP_OccupationTextBox.Text);

                    spouseID = Convert.ToInt32(SP_cmd.ExecuteScalar());
                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                    return spouseID;

                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                    return 0;
                }
            }
        }

        public int DependantInsert()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string insertDependant = "insert into Dependants (" +
                        "ApplicationID_FK, Firstname, Middlename," +
                        "Alias, Lastname, Sex, DOB, POB, RelationToApplicant)" +
                        "values(@aid, @fn, @midn, @al, @ln, @sex, @dob, @pob, @rel); " +
                        "SELECT SCOPE_IDENTITY();";
                    SqlCommand DP_cmd = new SqlCommand(insertDependant, connection);
                    DP_cmd.Parameters.Clear();
                    DP_cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    DP_cmd.Parameters.AddWithValue("@fn", DP_FirstnameTextBox.Text);
                    DP_cmd.Parameters.AddWithValue("@midn", DP_MiddlenameTextBox.Text);
                    DP_cmd.Parameters.AddWithValue("@al", DP_AliasTextBox.Text);
                    DP_cmd.Parameters.AddWithValue("@ln", DP_LastnameTextBox.Text);
                    DP_cmd.Parameters.AddWithValue("@sex", DP_SexDropDownList.Text);
                    DP_cmd.Parameters.AddWithValue("@dob", DP_DOBDateBox.Value);
                    DP_cmd.Parameters.AddWithValue("@pob", DP_POBDropDownList.Text);
                    DP_cmd.Parameters.AddWithValue("@rel", DP_RelationshipDropDownList.Text);

                    dependantID = Convert.ToInt32(DP_cmd.ExecuteScalar());

                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                    return dependantID;

                }
                catch (Exception ex)
                {
                    MessageLabel.Text += "\n \n" + ex.Message;
                    return 0;
                }
            }
        }

        public void ContactInfoInsert(
            string personID,
            string applicationID,
            string street,
            string town,
            string city,
            string country,
            string email,
            string cell,
            string home,
            string business)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string insertContactInfo = "insert into ContactInfo values(@pid, @aid, @str, @twn, @city," +
                   " @country, @em, @cell, @home, @bus)";
                    SqlCommand Contact_cmd = new SqlCommand(insertContactInfo, connection);
                    Contact_cmd.Parameters.AddWithValue("@pid", personID);
                    Contact_cmd.Parameters.AddWithValue("@aid", applicationID);
                    Contact_cmd.Parameters.AddWithValue("@str", street);
                    Contact_cmd.Parameters.AddWithValue("@twn", town);
                    Contact_cmd.Parameters.AddWithValue("@city", city);
                    Contact_cmd.Parameters.AddWithValue("@country", country);
                    Contact_cmd.Parameters.AddWithValue("@em", email);
                    Contact_cmd.Parameters.AddWithValue("@cell", cell);
                    Contact_cmd.Parameters.AddWithValue("@home", home);
                    Contact_cmd.Parameters.AddWithValue("@bus", business);
                    Contact_cmd.ExecuteNonQuery();
                }
                catch (Exception CI)
                {
                    MessageLabel.Text += "\n\n" + CI.ToString();
                }
            }
        }



        protected void SaveButton_Click(object sender, EventArgs e)
        {
                ApplicantInsert();
                ApplicationInsert();

                ContactInfoInsert(
                  ApplicantID,
                  ApplicationID,
                  AP_StreetAddressTextBox.Text,
                  AP_TownAddressTextBox.Text,
                  AP_CityAddressTextBox.Text,
                  AP_CityAddressTextBox.Text,
                  AP_EmailTextBox.Text,
                  AP_CellNumTextBox.Text,
                  AP_HouseNumTextBox.Text,
                  AP_BusinessNumTextBox.Text);

                if (isMarried.Value == "true")
                {
                    //MessageLabel.Text += "Spouse Inserted\n";
                    SpouseInsert();
                    ContactInfoInsert(
                    SpouseID,
                    ApplicationID,
                    SP_StreetAddressTextBox.Text,
                    SP_TownAddressTextBox.Text,
                    SP_CityAddressTextBox.Text,
                    SP_CityAddressTextBox.Text,
                    SP_EmailTextBox.Text,
                    SP_CellNumTextBox.Text,
                    SP_HouseNumTextBox.Text,
                    SP_BusinessNumTextBox.Text);
                }

                if (isDependent.Value == "true")
                {
                    //MessageLabel.Text += "Dependant Inserted\n";
                    DependantInsert();
                    ContactInfoInsert(
                    DependantID,
                    ApplicationID,
                    DP_StreetAddressTextBox.Text,
                    DP_TownAddressTextBox.Text,
                    DP_CityAddressTextBox.Text,
                    DP_CityAddressTextBox.Text,
                    DP_EmailTextBox.Text,
                    DP_CellNumTextBox.Text,
                    DP_HouseNumTextBox.Text,
                    DP_BusinessNumTextBox.Text);
                }

               /* pg0.Style["display"] = "none";
                pg1.Style["display"] = "none";
                pg2.Style["display"] = "none";
                pg3.Style["display"] = "block";
                pg4.Style["display"] = "none";*/
           /* }
            else if (Session["Saved"].ToString() == "1" && isDependent.Value == "true")
            {
                MessageLabel.Text += "Dependant Inserted\n";
                DependantInsert();
                ContactInfoInsert(
                DependantID,
                ApplicationID,
                DP_StreetAddressTextBox.Text,
                DP_TownAddressTextBox.Text,
                DP_CityAddressTextBox.Text,
                DP_CityAddressTextBox.Text,
                DP_EmailTextBox.Text,
                DP_CellNumTextBox.Text,
                DP_HouseNumTextBox.Text,
                DP_BusinessNumTextBox.Text);
            }

            Session["Saved"] = "1";*/
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            UploadFiles();
            InsertComment();
            InsertLog();
            Response.Redirect($"tracking.aspx?id={ApplicationID}");
        }


        public string GetFilename(string id)
        {
            string[] filename = id.Split('_');
            return filename[0];
        }

        public void InsertFiles(string path, string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertFile = "Insert into Files values(@aid, @fp, @fn)";
                    SqlCommand f_cmd = new SqlCommand(insertFile, connection);
                    f_cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    f_cmd.Parameters.AddWithValue("@fp", path);
                    f_cmd.Parameters.AddWithValue("@fn", name);

                    f_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }


        public void UploadFiles()
        {

            Directory.CreateDirectory(Server.MapPath("/Files/" + ApplicationID));
            try
            {
                foreach (Control cntrl in pg4.Controls)
                {
                    //MessageLabel.Text += "\n" + cntrl.GetType().ToString();

                    if (cntrl.GetType().ToString() == "System.Web.UI.WebControls.FileUpload")
                    {
                        FileUpload upload = cntrl as FileUpload;
                        if (upload.HasFile)
                        {
                            string extension = Path.GetExtension(upload.FileName);
                            string fileName = GetFilename(upload.ID);
                            string filePath = "/Files/" + ApplicationID + "/" +
                                upload.FileName.Replace(upload.FileName, fileName + extension);
                            upload.SaveAs(Server.MapPath(filePath));
                            InsertFiles(filePath, fileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }


        public int InsertComment()
        {
            string newAppText = "SUBMITTED FOR PROCESSING";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string submitApp = "insert into Comments values(@aid, @uid, @cdate, @com, @ctype);" +
                        " SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(submitApp, connection);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.Parameters.AddWithValue("@uid", Session["User"].ToString());
                    cmd.Parameters.AddWithValue("@cdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@com", newAppText);
                    cmd.Parameters.AddWithValue("@ctype", "general");

                    int commentID = Convert.ToInt32(cmd.ExecuteScalar());
                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                    return commentID;
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                return 0;
            }
        }

        public void InsertLog()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string submitLog = "insert into ApplicationLog" +
                        "(SenderID_FK, ApplicationID_FK, LogDate, LogDescription, FileCurrentDept)" +
                        " values(@send, @aid, @ldate, @desc, @cdept);";
                    SqlCommand cmd = new SqlCommand(submitLog, connection);
                    cmd.Parameters.AddWithValue("@send", Session["User"].ToString());
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.Parameters.AddWithValue("@ldate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@desc", InsertComment());
                    cmd.Parameters.AddWithValue("@cdept", "Immigration");
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        public void GetNotifications()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string getNotifications = "select Notifications.ApplicationID_FK, Users.Firstname + ' ' + Users.Lastname as Sender, " +
                        "Notifications.NotificationDate, Notifications.NotificationID from Notifications inner join Users on Notifications.SenderID_FK = Users.UserID " +
                        "where Notifications.ReceiverID_FK = @rid and ReadFlag = 0 order by Notifications.NotificationDate desc";
                    SqlCommand cmd = new SqlCommand(getNotifications, con);
                    cmd.Parameters.AddWithValue("@rid", Session["User"].ToString());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    NotificationGridView.DataSource = dt;
                    NotificationGridView.DataBind();

                    int notifs = NotificationGridView.Rows.Count;
                    NotificationCount.Text = notifs.ToString();
                    if (notifs > 0)
                    {
                        NotificationCount.Style["visibility"] = "visible";
                        notifications.Src = "images/res/activenotification.png";

                        for (int i = 0; i < notifs; i++)
                        {
                            string aid = NotificationGridView.Rows[i].Cells[0].Text;
                            string dte = NotificationGridView.Rows[i].Cells[2].Text;
                            string nid = NotificationGridView.Rows[i].Cells[3].Text;
                            DateTime notiDate = DateTime.Parse(dte);

                            System.Web.UI.HtmlControls.HtmlGenericControl nRow = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            nRow.Attributes["class"] = "n-row";
                            notificationContainer.Controls.Add(nRow);

                            LinkButton AppID = new LinkButton
                            {
                                Text = aid,
                                CssClass = "nLink",
                                ID = nid
                            };
                            AppID.Click += new EventHandler(view_Click);
                            nRow.Controls.Add(AppID);

                            Label AppDate = new Label
                            {
                                Text = notiDate.ToString("dd-MM-yyyy hh:mm tt").ToUpper(),
                                CssClass = "nDate"
                            };
                            nRow.Controls.Add(AppDate);
                        }
                    }
                    else
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl nRow = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        nRow.Attributes["class"] = "n-row";
                        notificationContainer.Controls.Add(nRow);

                        Label noNew = new Label
                        {
                            Text = "No new notifications",
                            CssClass = "nDate"
                        };
                        nRow.Controls.Add(noNew);
                    }

                    HyperLink Queue = new HyperLink
                    {
                        NavigateUrl = "queue.aspx",
                        CssClass = "queue-link",
                        Text = "QUEUE"
                    };
                    notificationContainer.Controls.Add(Queue);
                }
            }
            catch (Exception ex)
            {
                userName.Text = ex.Message;
            }
        }

        public void view_Click(object sender, EventArgs e)
        {
            LinkButton LB = sender as LinkButton;
            MarkAsRead(LB.ID);
            Response.Redirect($"~/tracking.aspx?id={LB.Text}");
        }

        public void MarkAsRead(string nid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string markAsRead = "update Notifications set ReadFlag = @rf where NotificationID = @nid";
                    SqlCommand cmd = new SqlCommand(markAsRead, con);
                    cmd.Parameters.AddWithValue("@rf", 1);
                    cmd.Parameters.AddWithValue("@nid", nid);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                userName.Text = ex.Message;
            }
        }


        protected void AddNewButton_Click(object sender, EventArgs e)
        {
            pg0.Style["display"] = "none";
            pg1.Style["display"] = "none";
            pg2.Style["display"] = "none";
            pg3.Style["display"] = "none";
            pg4.Style["display"] = "block";
        }
    }
}