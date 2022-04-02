using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace approval
{
    public partial class DCEO : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        string ApplicationID;
        string commentText;
        string commentType;
        string finalStatus;
        string filePath;
        string submittor;
        string ApplicantID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                PermissionCheck();
                ApplicationID = Request.QueryString["id"].ToString();
                filePath = Session["filePath"].ToString();
                submittor = Session["submittor"].ToString();
                ApplicantID = Session["Applicant"].ToString();
                ApplicationLink.Text = ApplicationID;
                GetApplicant();
                GetRecommendations();
                GetUser();
                GetNotifications();                
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        public void GetApplicant()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string getApplicant = "Select Applicants.*, ContactInfo.* from ContactInfo" +
                        " inner join Applicants on ContactInfo.PersonID_FK = Applicants.ApplicantID" +
                        " where ContactInfo.PersonID_FK = @pid";
                    SqlCommand cmd = new SqlCommand(getApplicant, con);
                    cmd.Parameters.AddWithValue("@pid", ApplicantID);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ApplicantGridView.DataSource = dt;
                    ApplicantGridView.DataBind();

                    AddApplicants();
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        public void PermissionCheck()
        {
            if (Session["Role"].ToString() != "Approver")
            {
                main.Visible = false;
                MessageLabel.Text = "You do not have permission approve applications";
            }
        }

        public void AddApplicants()
        {
            ApplicantImg.ImageUrl = filePath;
            PassportLabel.Text = ApplicantGridView.Rows[0].Cells[0].Text;
            FirstnameLabel.Text = ApplicantGridView.Rows[0].Cells[1].Text;
            MiddlenameLabel.Text = ApplicantGridView.Rows[0].Cells[2].Text;
            LastnameLabel.Text = ApplicantGridView.Rows[0].Cells[4].Text;
            MaritalStatusLabel.Text = ApplicantGridView.Rows[0].Cells[5].Text;
            GenderLabel.Text = ApplicantGridView.Rows[0].Cells[6].Text;
            TRNLabel.Text = ApplicantGridView.Rows[0].Cells[7].Text;
            DOBLabel.Text = ApplicantGridView.Rows[0].Cells[8].Text;
            POBLabel.Text = ApplicantGridView.Rows[0].Cells[9].Text;
            NationalityLabel.Text = ApplicantGridView.Rows[0].Cells[10].Text;
            OccupationLabel.Text = ApplicantGridView.Rows[0].Cells[11].Text;
            PriLangLabel.Text = ApplicantGridView.Rows[0].Cells[12].Text;
            SecLangLabel.Text = ApplicantGridView.Rows[0].Cells[13].Text;
            CitizenshipsLabel.Text = $"{ApplicantGridView.Rows[0].Cells[14].Text} " +
                                 $" <br> {ApplicantGridView.Rows[0].Cells[15].Text}";
            StreetLabel.Text = ApplicantGridView.Rows[0].Cells[19].Text;
            TownLabel.Text = ApplicantGridView.Rows[0].Cells[20].Text;
            CityLabel.Text = ApplicantGridView.Rows[0].Cells[21].Text;
            CountryLabel.Text = ApplicantGridView.Rows[0].Cells[22].Text;

            //IDTypeLabel.Text = 

        }

       /* public void GetApplication()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }*/

        public void GetRecommendations()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string getRec = "Select Users.Firstname + ' ' + Users.Lastname, Users.Position, Comments.Comment" +
                        " from Comments inner join Users on Comments.UserID_FK = Users.UserID " +
                        "where Comments.CommentType = @ctype and ApplicationID_FK = @aid;";

                    SqlCommand cmd = new SqlCommand(getRec, con);
                    cmd.Parameters.AddWithValue("@ctype", "recommendation");
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    RecommendGridView.DataSource = dt;
                    RecommendGridView.DataBind();

                    AddRecommendations();
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        public void AddRecommendations()
        {
            try
            {
                int recTotal = RecommendGridView.Rows.Count;
                if (recTotal > 0)
                {
                    for (int i = 0; i < recTotal; i++)
                    {
                        string np = $"{RecommendGridView.Rows[i].Cells[0].Text} • {RecommendGridView.Rows[i].Cells[1].Text}";
                        string com = RecommendGridView.Rows[i].Cells[2].Text;

                        System.Web.UI.HtmlControls.HtmlGenericControl recRow = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        recRow.Attributes["class"] = "recRow";
                        recommendations.Controls.Add(recRow);

                        Label NamePosition = new Label();
                        NamePosition.Text = np;
                        NamePosition.CssClass = "n-pos";
                        recRow.Controls.Add(NamePosition);

                        Label Comment = new Label();
                        Comment.Text = com;
                        Comment.CssClass = "comment";
                        recRow.Controls.Add(Comment);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;

            }
        }

        public void UpdateDecision()
        {

        }

        public int InsertComment(string fstat)
        {
            commentText = $"APPLICATION {fstat} \n{CommentTextBox.Text}";
            commentType = "Decision";

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
                    cmd.Parameters.AddWithValue("@com", commentText);
                    cmd.Parameters.AddWithValue("@ctype", commentType);

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
                    cmd.Parameters.AddWithValue("@aid", Request.QueryString["id"].ToString());
                    cmd.Parameters.AddWithValue("@ldate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@desc", InsertComment(finalStatus));
                    cmd.Parameters.AddWithValue("@cdept", "Immigration");

                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        public void UpdateAppStatus(string decision)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string updateAppStatus = "Update Applications set ApplicationStatus = @appstat," +
                        " LastLocation = @last where ApplicationID = @aid";
                    SqlCommand cmd = new SqlCommand(updateAppStatus, con);
                    cmd.Parameters.AddWithValue("@last", decision);
                    cmd.Parameters.AddWithValue("@appstat", decision);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.ToString();
            }
        }

        public void NotifySubmittor(string decision)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string notifyReceiver = "insert into Notifications values(@sid, @rid, @aid, @rf, @msg, @active, @ndate)";
                    SqlCommand cmd = new SqlCommand(notifyReceiver, con);
                    cmd.Parameters.AddWithValue("@sid", Session["User"].ToString());
                    cmd.Parameters.AddWithValue("@rid", submittor);
                    cmd.Parameters.AddWithValue("@aid", ApplicationID);
                    cmd.Parameters.AddWithValue("@rf", 0);
                    cmd.Parameters.AddWithValue("@msg", $"APPLICATION {decision}");
                    cmd.Parameters.AddWithValue("@active", 1);
                    cmd.Parameters.AddWithValue("@ndate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }


        protected void ApplicationLink_Click(object sender, EventArgs e)
        {
            Response.Redirect($"tracking.aspx?id={ApplicationID}");
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
        public void GetUser()
        {
            userName.Text = Session["Username"].ToString();
        }


        protected void ApproveButton_Click(object sender, EventArgs e)
        {
            finalStatus = "APPROVED";
            InsertLog();
            UpdateAppStatus(finalStatus);
            NotifySubmittor(finalStatus);            
        }


        protected void DenyButton_Click(object sender, EventArgs e)
        {
            finalStatus = "DENIED";
            InsertLog();
            UpdateAppStatus(finalStatus);
            NotifySubmittor(finalStatus);
        }

        protected void DifferButton_Click(object sender, EventArgs e)
        {
            finalStatus = "DIFFERED";
            InsertLog();
            UpdateAppStatus(finalStatus);
            NotifySubmittor(finalStatus);
        }
    }
}