using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Gemini
{
    public partial class trackupdates : System.Web.UI.Page
    {

        string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null )
            {
                ApplicationID = Request.QueryString["id"].ToString();
                GetUser();
                GetNotifications();
                GetApplicant();
                GetComments(FilterType());
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        string ApplicationID;
        string commentText;
        string commentType;


        public void GetComments(string commentType)
        {
            try
            {
                appID.InnerText = ApplicationID;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string getComments = "select Users.Firstname, Users.Lastname, Users.Position," +
                        " ApplicationLog.LogDate, ApplicationLog.LogDescription, Departments.DepartmentName, Comments.Comment, Comments.CommentType" +
                        " from ApplicationLog inner join Users on ApplicationLog.SenderID_FK = Users.UserID " +
                        "inner join Comments on ApplicationLog.LogDescription = Comments.CommentID " +
                        "inner join Departments on Users.DeptID_FK = Departments.DeptID" +
                        " where ApplicationLog.ApplicationID_FK = @aid and Comments.CommentType like @ct order by ApplicationLog.LogDate desc;";
                    ;
                    SqlCommand cmd = new SqlCommand(getComments, connection);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.Parameters.AddWithValue("@ct", $"%{commentType}%");

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    CommentsGridView.DataSource = dt;
                    CommentsGridView.DataBind();

                    AddComments();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
            }
        }

        public void AddComments()
        {
            int commentsTotal = CommentsGridView.Rows.Count;
            //string[] allComments = new string[commentsTotal];

            for (int i = 0; i < commentsTotal; i++)
            {
                string Fname = CommentsGridView.Rows[i].Cells[0].Text;
                string Lname = CommentsGridView.Rows[i].Cells[1].Text;
                string Pos  = $" • { CommentsGridView.Rows[i].Cells[2].Text} • ";
                string d1 = CommentsGridView.Rows[i].Cells[3].Text;
                string comment = CommentsGridView.Rows[i].Cells[6].Text;
                DateTime dte = DateTime.Parse(d1);

                //Adds a div to contain each comment in a row
                System.Web.UI.HtmlControls.HtmlGenericControl comment_row = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                comment_row.Attributes["class"] = "row";
                comment_container.Controls.Add(comment_row);

                Label Firstname = new Label
                {
                    Text = Fname,
                    CssClass = "user c-header"
                };
                comment_row.Controls.Add(Firstname);

                Label Lastname = new Label
                {
                    Text = Lname,
                    CssClass = "user c-header"
                };
                comment_row.Controls.Add(Lastname);

                Label Position = new Label
                {
                    Text = Pos,
                    CssClass = "c-header"
                };
                comment_row.Controls.Add(Position);

                Label Date = new Label
                {
                    Text = dte.ToString("dd-MM-yyyy hh:mm tt"),
                    CssClass = "c-header upper"
                };
                comment_row.Controls.Add(Date);

                Label Comment = new Label
                {
                    Text = comment.Replace("\n", "<br />"),
                    CssClass = "comment"
                };
                comment_row.Controls.Add(Comment);

                //System.Web.UI.HtmlControls.HtmlGenericControl sepatator = new System.Web.UI.HtmlControls.HtmlGenericControl("hr");
                //comment_container.Controls.Add(sepatator);
            }
        }




        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            commentText = CommentTextBox.Text;
            commentType = CommentType();                
            InsertLog();
            CommentTextBox.Text = string.Empty;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }


        public int InsertComment(string comment, string commentType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertComment = "insert into Comments values(@aid, @uid, @cdate, @com, @ctype);" +
                        " SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(insertComment, connection);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.Parameters.AddWithValue("@uid", Session["User"].ToString());
                    cmd.Parameters.AddWithValue("@cdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@com", comment);
                    cmd.Parameters.AddWithValue("@ctype", commentType);

                    int commentID = Convert.ToInt32(cmd.ExecuteScalar());

                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                    CommentTypeRadio.ClearSelection();
                    return commentID;
                }
            }
            catch (Exception ex)
            {
                WarningLabel.Text = ex.Message;
                return 0;
            }
        }

        public void UpdateAppStatus() 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string user = UserDropDownList.SelectedValue;
                    string dept = DeptDropDownList.SelectedValue;
                    string reason = ReasonDropDownList.SelectedValue;
                    string appLocation = $"{reason} • {dept}"; 

                    string updateAppStatus = "Update Applications set ApplicationStatus = @appstat," +
                        " LastLocation = @last where ApplicationID = @aid";
                    SqlCommand cmd = new SqlCommand(updateAppStatus, con);
                    cmd.Parameters.AddWithValue("@last", appLocation);
                    cmd.Parameters.AddWithValue("@appstat", reason);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.ToString();
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
                    cmd.Parameters.AddWithValue("@aid", Request.QueryString["id"].ToString());
                    cmd.Parameters.AddWithValue("@ldate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@desc", InsertComment(commentText, commentType));
                    cmd.Parameters.AddWithValue("@cdept", "Immigration");

                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                WarningLabel.Text = ex.Message;
            }
        }

        public void GetUser()
        {
            userName.Text = Session["Username"].ToString();
        }

        public void GetEmployees()
        {
            //UserDropDownList.Visible = true;
            track.Style["display"] = "block";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string getEmployees = "SELECT [Firstname], [Lastname], [UserID] FROM [Users] " +
                        "inner join Departments on Users.DeptID_FK = Departments.DeptID" +
                        " WHERE Departments.DepartmentName = @dept";
                    SqlCommand cmd = new SqlCommand(getEmployees, con);
                    cmd.Parameters.AddWithValue("@dept", DeptDropDownList.SelectedValue);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    UserDropDownList.Items.Clear();

                    int emp = GridView1.Rows.Count;
                    string name;
                    if (emp > 0)
                    {
                        for (int i = 0; i < emp; i++)
                        {
                            name = $"{GridView1.Rows[i].Cells[0].Text} {GridView1.Rows[i].Cells[1].Text}";
                            UserDropDownList.Items.Add(name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WarningLabel.Text = ex.ToString();               
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

        public void GetApplicant()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string getApplicant = "Select Applicants.Firstname, Applicants.Lastname," +
                        " Applicants.DOB, Files.FilePath, Applications.LastLocation, Applications.UserID_FK, " +
                        "Applications.ApplicantID_FK from Applications" +
                        " inner join Files on Applications.ApplicationID = Files.ApplicationID_FK " +
                        "inner join Applicants on Applications.ApplicantID_FK = Applicants.ApplicantID " +
                        "where Applications.ApplicationID = @aid and Files.FilePath like @fp";

                    SqlCommand cmd = new SqlCommand(getApplicant, con);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.Parameters.AddWithValue("@fp", $"%{ApplicationID}/PassportPhoto%");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ApplicantGridView.DataSource = dt;
                    ApplicantGridView.DataBind();

                    string Fname = ApplicantGridView.Rows[0].Cells[0].Text;
                    String Lname = ApplicantGridView.Rows[0].Cells[1].Text;                    
                    String dob = ApplicantGridView.Rows[0].Cells[2].Text;
                    DateTime dtime = DateTime.Parse(dob);
                    string photo = ApplicantGridView.Rows[0].Cells[3].Text;
                    string location = ApplicantGridView.Rows[0].Cells[4].Text;

                    ApplicantName.Text = $"{Fname} {Lname}";
                    ApplicantDOB.Text = String.Format("{0:MMM dd, yyyy}", dtime);
                    ProfileImage.ImageUrl = photo;
                    AppLocation.Text = location;

                }
            }
            catch (Exception ex)
            {
                WarningLabel.Text = ex.Message;
            }
        }

        public string CommentType()
        {
            int ctype = CommentTypeRadio.SelectedIndex;

            if (ctype == 1)
            {
                return "recommendation";
            }
            
            else
            {
                return "general";
            }
        }

        public string FilterType() 
        {
            int cFilter = commentFilter.SelectedIndex;
            
            if (cFilter == 1)
            {
                return "transfer";
            }
            else if (cFilter == 2)
            {
                return "recommendation";
            }
            else
            {
                return "";
            }
        }

        public void NotifyReceiver()
        {
            int index = UserDropDownList.SelectedIndex;
            string receiverID = GridView1.Rows[index].Cells[2].Text;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string notifyReceiver = "insert into Notifications values(@sid, @rid, @aid, @rf, @msg, @active, @ndate)";
                    SqlCommand cmd = new SqlCommand(notifyReceiver, con);
                    cmd.Parameters.AddWithValue("@sid", Session["User"].ToString());
                    cmd.Parameters.AddWithValue("@rid", receiverID);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.Parameters.AddWithValue("@rf", 0);
                    cmd.Parameters.AddWithValue("@msg", ReasonDropDownList.SelectedValue);
                    cmd.Parameters.AddWithValue("@active", 1);
                    cmd.Parameters.AddWithValue("@ndate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                WarningLabel.Text = ex.Message;
            }

        }
      
        protected void DeptDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEmployees();
        }

        protected void TransferButton_Click(object sender, EventArgs e)
        {
            commentText = $"File Logged to {UserDropDownList.SelectedValue} for {ReasonDropDownList.SelectedValue} \n{CommentTextBox.Text} ";
            commentType = "transfer";
            InsertLog();
            NotifyReceiver();
            RemoveFromQueue();
            UpdateAppStatus();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void transbtn_Click(object sender, EventArgs e)
        {
            GetEmployees();
        }

        protected void commentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetComments(FilterType());
        }

        public void RemoveFromQueue()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string removeFromQueue = "update Notifications set Active = 0 " +
                        "where ApplicationID_FK = @aid and ReceiverID_FK = @rid";
                    SqlCommand cmd = new SqlCommand(removeFromQueue, con);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID) ;
                    cmd.Parameters.AddWithValue("@rid", Session["User"].ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                WarningLabel.Text = ex.Message;
            }
        }

        protected void viewFiles_Click(object sender, EventArgs e)
        {
            Response.Redirect($"filespage.aspx?id={ApplicationID}");
        }

        protected void viewApp_Click(object sender, EventArgs e)
        {
            Session["Applicant"] = ApplicantGridView.Rows[0].Cells[6].Text;
            Response.Redirect($"details.aspx?id={ApplicationID}");
        }

        protected void Dashboard_Click(object sender, EventArgs e)
        {

            Session["filePath"] = ApplicantGridView.Rows[0].Cells[3].Text;
            Session["submittor"] = ApplicantGridView.Rows[0].Cells[5].Text;
            Session["Applicant"] = ApplicantGridView.Rows[0].Cells[6].Text;
            Response.Redirect($"dashboard.aspx?id={ApplicationID}");
        }

        /*protected void Dashboard_Click(object sender, ImageClickEventArgs e)
        {
            Session["filePath"] = ApplicantGridView.Rows[0].Cells[3].Text;
            Session["submittor"] = ApplicantGridView.Rows[0].Cells[5].Text;
            Session["Applicant"] = ApplicantGridView.Rows[0].Cells[6].Text;
            Response.Redirect($"dashboard.aspx?id={ApplicationID}");
        }*/

    }
}