using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeminiGUI
{
    public partial class Geminibase : Form
    {
        public static Geminibase mdiobj;
        public Geminibase()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean isOpen = false;
            foreach(Form f in Application.OpenForms)
            {
                if(f.Text == "Login")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if(isOpen == false)
            {
                Login lg = new Login();
                lg.MdiParent = this;
                lg.Show();
            }
            changePasswordToolStripMenuItem.Enabled = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void showlabels()
        {
            InitializeComponent();
            loginToolStripMenuItem.Enabled = false;
        }

        public void showDashboard()
        {
            UserManagement db = new UserManagement();
            db.MdiParent = this;
            db.Show();
        }

        private void Geminibase_Load(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.MdiParent = this;
            lg.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Change Password")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                ChangePassword lg = new ChangePassword();
                lg.MdiParent = this;
                lg.Show();
            }
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "User Management")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                UserManagement lg = new UserManagement();
                lg.MdiParent = this;
                lg.Show();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
