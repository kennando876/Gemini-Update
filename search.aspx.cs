using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace Gemini
{
    public partial class search : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                GetUser();
                GetNotifications();
            }
            else
            {
                Response.Redirect("index.aspx");
            }
            if (Page.IsPostBack)
            {
                results.Visible = true;
            }
            else
            {
                results.Visible = false;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string search = "select Applications.ApplicationID as Application, Applicants.Firstname, Applicants.Lastname, Applications.ApplicationDate " +
                        " as Date from Applications inner join Applicants on Applications.ApplicantID_FK = Applicants.ApplicantID " +
                        "where Applications.ApplicationID  like @aid " +
                        "and Applications.ApplicationType like @at and Applications.ApplicationDate like @date " +
                        "and Applicants.Firstname like @fn and Applicants.Lastname like @ln;";

                    SqlCommand cmd = new SqlCommand(search, connection);
                    cmd.Parameters.AddWithValue("@aid", $"{ApplicationTextBox.Text}%");
                    cmd.Parameters.AddWithValue("@at", $"{ApplicationTypeDropDownList.SelectedValue}%");
                    cmd.Parameters.AddWithValue("@date", $"{DateEntered.Value}%");
                    cmd.Parameters.AddWithValue("@fn", $"{FirstnameTextBox.Text}%");
                    cmd.Parameters.AddWithValue("@ln", $"{LastnameTextBox.Text}%");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ResultsGridView.DataSource = dt;
                    ResultsGridView.DataBind();

                    MessageLabel.Text = "";

                    if (ResultsGridView.Rows.Count == 0)
                    {
                        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                        MessageLabel.Text = "No results found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        public void Select()
        {
            Response.Redirect("");
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

        protected void ResultsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(ResultsGridView, "Select$" + e.Row.RowIndex));
            }
        }

        protected void ResultsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = ResultsGridView.SelectedRow.Cells[0].Text;
            Response.Redirect($"tracking.aspx?id={ID}");
        }


    }
}