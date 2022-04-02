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
    public partial class index : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["User"] = null;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
               using ( SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string SQLAccess = "Select * from Users where Username = @un and Password = @pass";
                    SqlCommand com = new SqlCommand(SQLAccess, con);
                    com.Parameters.Clear();
                    com.Parameters.AddWithValue("@un", UsernameTextBox.Text);
                    com.Parameters.AddWithValue("@pass", PasswordTextBox.Text);

                    int id = Convert.ToInt32(com.ExecuteScalar());
                    if (id != 0)
                    {
                        Session["User"] = id.ToString();
                        Response.Redirect("home.aspx");
                    }
                    else
                    {
                        MessageLabel.Text = "User not found";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
    }
}