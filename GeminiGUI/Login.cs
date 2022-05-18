using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GeminiGUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string connetionString, sql;
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader datareader;
            Geminibase parent = new Geminibase();
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Temp\GeminiUpdate\database\GeminiDB.mdf;Integrated Security=True;Connect Timeout=30";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("All fields are reuired...");
            }
            else
            {
                try
                {
                    sql = "SELECT Firstname, Lastname FROM Users WHERE Username = '" + txtusername.Text + "' AND Password = '" + txtpassword.Text + "'";
                    command = new SqlCommand(sql, cnn);
                    datareader = command.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {

                            //parent.lblwelcomename.Text = datareader.GetString(0) + " " + datareader.GetString(1);
                            //parent.toolStripMenuItem1.Enabled = false;
                            parent.showDashboard();
                            parent.showlabels();
                        }
                        this.Close();
                        UserManagement db = new UserManagement();
                        db.MdiParent = this.MdiParent;
                        db.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credentials provided...");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            cnn.Close();
        }
    }
}
