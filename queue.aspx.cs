using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using Antlr.Runtime.Tree;

namespace Gemini
{
    public partial class queue : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                GetUser();
                GetNotifications();
                GetQueue();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        public void GetQueue()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string getNotifications = "select Notifications.ApplicationID_FK, Users.Firstname + ' ' + Users.Lastname as Sender, " +
                        "Notifications.NotificationDate, Notifications.NotificationID, Notifications.NotificationMessage" +
                        " from Notifications inner join Users on Notifications.SenderID_FK = Users.UserID " +
                        "where Notifications.ReceiverID_FK = @rid and Active = 1 order by Notifications.NotificationDate desc";
                    SqlCommand cmd = new SqlCommand(getNotifications, con);
                    cmd.Parameters.AddWithValue("@rid", Session["User"].ToString());
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    QueueGridView.DataSource = dt;
                    QueueGridView.DataBind();
                    AddQueueItems();
                }
            }
            catch (Exception ex)
            {

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
                                ID = $"{nid}_n"
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
            string nid = GetNID(LB.ID);
            MarkAsRead(nid);
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

        public void AddQueueItems()
        {
            int totalApps = QueueGridView.Rows.Count;
            if (totalApps > 0)
            {
                MessageLabel.Text = $"Files in queue: { totalApps}";
                for (int i = 0; i < totalApps; i++)
                {
                    string aid = QueueGridView.Rows[i].Cells[0].Text;
                    string sender = QueueGridView.Rows[i].Cells[1].Text;
                    string dte = QueueGridView.Rows[i].Cells[2].Text;
                    string nid = QueueGridView.Rows[i].Cells[3].Text;
                    string res = QueueGridView.Rows[i].Cells[4].Text;
                    DateTime notiDate = DateTime.Parse(dte);


                    System.Web.UI.HtmlControls.HtmlGenericControl aRow = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    aRow.Attributes["class"] = "a-row";
                    queueContainer.Controls.Add(aRow);

                    LinkButton AppID = new LinkButton
                    {
                        Text = aid,
                        CssClass = "nLink",
                        ID = $"{nid}_q",
                    };
                    AppID.Click += new EventHandler(view_Click);
                    aRow.Controls.Add(AppID);

                    Label AppDate = new Label
                    {
                        Text = notiDate.ToString("dd-MM-yyyy hh:mm tt").ToUpper(),
                        CssClass = "nDate"
                    };
                    aRow.Controls.Add(AppDate);

                    Label Send = new Label
                    {
                        Text = sender,
                        CssClass = "nDate"
                    };
                    aRow.Controls.Add(Send);

                    Label Reason = new Label
                    {
                        Text = res,
                        CssClass = "nDate"
                    };
                    aRow.Controls.Add(Reason);

                    /* Button Remove = new Button
                     {
                         Text = "Remove",
                         CssClass = "remove-btn",
                         ID = nid
                     };
                     Remove.Click += new EventHandler(remove_Click);
                     aRow.Controls.Add(Remove);*/
                }
            }
            else
            {
                MessageLabel.Text = "No files in queue";
            }
        }

        public void GetUser()
        {
            userName.Text = Session["Username"].ToString();
        }

        public string GetNID(string btnID)
        {
            string[] nid =btnID.Split('_');
            return nid[0];
        }


        /*public void RemoveFromQueue(string nid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string removeFromQueue = "update Notifications set Active = @ac where NotificationID = @nid";
                    SqlCommand cmd = new SqlCommand(removeFromQueue, con);
                    cmd.Parameters.AddWithValue("@ac", 0);
                    cmd.Parameters.AddWithValue("@nid", nid);
                    int res = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }*/


        /*public void remove_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string nid = $"{btn.ID}{btn.ToolTip}";
            RemoveFromQueue(nid);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }*/
    }
}