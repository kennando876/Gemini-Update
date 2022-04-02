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
    public partial class details : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        string ApplicationID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                GetUser();
                GetNotifications();
                HideGrid();
            }
            else
            {
                Response.Redirect("index.aspx");
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

        public void GetUser()
        {
            userName.Text = Session["Username"].ToString();
        }

        public void HideGrid()
        {
            if (DependentGridView.Rows.Count == 0)
            {
                Dependent.Visible = false;
            }
            if (SpouseGridView.Rows.Count == 0)
            {
                Spouse.Visible = false;
            }
        }
    }
}