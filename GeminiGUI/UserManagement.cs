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
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public int getRoleID(string role)
        {
            int roleID = 0;
            if(role == "Creator")
            {
                roleID = 1004;
            }
            else if (role == "Reviewer")
            {
                roleID = 1005;
            }
            else if (role == "Investigator")
            {
                roleID = 1006;
            }
            else if (role == "Approver")
            {
                roleID = 1007;
            }

            return roleID;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cbbDepartment.Text == "" || cbbRole.Text == "" || txtFirstname.Text == "" || txtLastname.Text == "" || txtPassword.Text == "" || txtPosition.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("All fields are required...");
            }
            else
            {
                string connetionString, sql;
                SqlConnection cnn;
                SqlCommand command;
                int result;
                Geminibase parent = new Geminibase();
                connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Temp\GeminiUpdate\database\GeminiDB.mdf;Integrated Security=True;Connect Timeout=30";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                try
                {
                    sql = "INSERT INTO Users(Username,Password,Firstname,Lastname,Position,RoleID_FK,DeptID_FK) " +
                        " VALUES ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtFirstname.Text + "', '" +
                        txtLastname.Text + "','" + txtPosition.Text + "', " + getRoleID(cbbRole.Text) + ",'" + cbbDepartment.Text + "')";
                    command = new SqlCommand(sql, cnn);

                    result = command.ExecuteNonQuery();

                    if (result >= 1)
                    {
                        MessageBox.Show("User has been created...");
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtFirstname.Text = "";
                        txtLastname.Text = "";
                        txtPosition.Text = "";
                        cbbRole.Text = "";
                        cbbDepartment.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Error found! User was not created...");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string connetionString, sql="";
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt;
            Geminibase parent = new Geminibase();
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Temp\GeminiUpdate\database\GeminiDB.mdf;Integrated Security=True;Connect Timeout=30";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            switch(cbbFilter.SelectedIndex)
            {
                case 0:
                    sql = "Select Username, Firstname, Lastname, Position from Users ";
                    break;
                case 1:
                    sql = "Select Username, Firstname, Lastname, Position from Users where Firstname LIKE '%" + txtSearch.Text + "%'"; ;
                    break;
                default:
                    MessageBox.Show("Filter is required...");
                    break;
            }

            if(cbbFilter.SelectedIndex == 1 && txtSearch.Text == "")
            {
                MessageBox.Show("The texbox cannot be blank...");
            }
            else
            {
                if (sql != "")
                {
                    da = new SqlDataAdapter(sql, cnn);
                    dt = new DataTable();
                    da.Fill(dt);
                    dgvSearchResult.DataSource = dt;
                }
            }

        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
        }
    }
}
