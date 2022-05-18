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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void lblCFPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string connetionString, sql;
            SqlConnection cnn;
            SqlCommand command;
            int result;
            Geminibase parent = new Geminibase();
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Temp\GeminiUpdate\database\GeminiDB.mdf;Integrated Security=True;Connect Timeout=30";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            if (txtCPUsername.Text == "" || txtNewPassword.Text == "" || txtCPPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("All fields are reuired...");
            }
            else
            {
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("New password an confrim password does not match...");
                }
                else
                {
                    try
                    {
                        sql = "UPDATE Users SET Password = '" + txtNewPassword.Text +
                            "' WHERE Username = '" + txtCPUsername.Text + "' AND Password = '" + txtCPPassword.Text + "'";
                        command = new SqlCommand(sql, cnn);

                        result = command.ExecuteNonQuery();

                        if (result >= 1)
                        {
                            MessageBox.Show("Password successfully updated");
                            txtCPUsername.Text = "";
                            txtNewPassword.Text = "";
                            txtCPPassword.Text = "";
                            txtConfirmPassword.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Error found! Pasword was not updated...");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            cnn.Close();
        }
    }
}
