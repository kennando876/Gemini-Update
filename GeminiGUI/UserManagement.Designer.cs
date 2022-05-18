namespace GeminiGUI
{
    partial class UserManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabFindUser = new System.Windows.Forms.TabPage();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbbFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvSearchResult = new System.Windows.Forms.DataGridView();
            this.lblNameFilter = new System.Windows.Forms.Label();
            this.lblFilterOption = new System.Windows.Forms.Label();
            this.tabCreateUser = new System.Windows.Forms.TabPage();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.lblLastname = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            this.cbbDepartment = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tabUser = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).BeginInit();
            this.tabFindUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).BeginInit();
            this.tabCreateUser.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(320, 47);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(272, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User Management";
            // 
            // tabFindUser
            // 
            this.tabFindUser.Controls.Add(this.lblFilterOption);
            this.tabFindUser.Controls.Add(this.lblNameFilter);
            this.tabFindUser.Controls.Add(this.dgvSearchResult);
            this.tabFindUser.Controls.Add(this.btnSearch);
            this.tabFindUser.Controls.Add(this.cbbFilter);
            this.tabFindUser.Controls.Add(this.txtSearch);
            this.tabFindUser.Location = new System.Drawing.Point(4, 25);
            this.tabFindUser.Margin = new System.Windows.Forms.Padding(4);
            this.tabFindUser.Name = "tabFindUser";
            this.tabFindUser.Padding = new System.Windows.Forms.Padding(4);
            this.tabFindUser.Size = new System.Drawing.Size(1027, 389);
            this.tabFindUser.TabIndex = 2;
            this.tabFindUser.Text = "Find User";
            this.tabFindUser.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 55);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(144, 22);
            this.txtSearch.TabIndex = 1;
            // 
            // cbbFilter
            // 
            this.cbbFilter.FormattingEnabled = true;
            this.cbbFilter.Items.AddRange(new object[] {
            "Show All",
            "Search by Firstname"});
            this.cbbFilter.Location = new System.Drawing.Point(225, 55);
            this.cbbFilter.Name = "cbbFilter";
            this.cbbFilter.Size = new System.Drawing.Size(149, 24);
            this.cbbFilter.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(439, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 34);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvSearchResult
            // 
            this.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSearchResult.Location = new System.Drawing.Point(4, 86);
            this.dgvSearchResult.Name = "dgvSearchResult";
            this.dgvSearchResult.RowHeadersWidth = 51;
            this.dgvSearchResult.RowTemplate.Height = 24;
            this.dgvSearchResult.Size = new System.Drawing.Size(1019, 299);
            this.dgvSearchResult.TabIndex = 4;
            // 
            // lblNameFilter
            // 
            this.lblNameFilter.AutoSize = true;
            this.lblNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameFilter.Location = new System.Drawing.Point(7, 17);
            this.lblNameFilter.Name = "lblNameFilter";
            this.lblNameFilter.Size = new System.Drawing.Size(149, 25);
            this.lblNameFilter.TabIndex = 5;
            this.lblNameFilter.Text = "Enter Firstname";
            // 
            // lblFilterOption
            // 
            this.lblFilterOption.AutoSize = true;
            this.lblFilterOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterOption.Location = new System.Drawing.Point(220, 17);
            this.lblFilterOption.Name = "lblFilterOption";
            this.lblFilterOption.Size = new System.Drawing.Size(117, 25);
            this.lblFilterOption.TabIndex = 6;
            this.lblFilterOption.Text = "Filter Option";
            // 
            // tabCreateUser
            // 
            this.tabCreateUser.Controls.Add(this.btnCreate);
            this.tabCreateUser.Controls.Add(this.cbbDepartment);
            this.tabCreateUser.Controls.Add(this.cbbRole);
            this.tabCreateUser.Controls.Add(this.lblDepartment);
            this.tabCreateUser.Controls.Add(this.lblRole);
            this.tabCreateUser.Controls.Add(this.txtPosition);
            this.tabCreateUser.Controls.Add(this.txtLastname);
            this.tabCreateUser.Controls.Add(this.txtFirstname);
            this.tabCreateUser.Controls.Add(this.txtUsername);
            this.tabCreateUser.Controls.Add(this.lblPosition);
            this.tabCreateUser.Controls.Add(this.lblLastname);
            this.tabCreateUser.Controls.Add(this.lblFirstname);
            this.tabCreateUser.Controls.Add(this.txtPassword);
            this.tabCreateUser.Controls.Add(this.lblPassword);
            this.tabCreateUser.Controls.Add(this.lblUsername);
            this.tabCreateUser.Location = new System.Drawing.Point(4, 25);
            this.tabCreateUser.Margin = new System.Windows.Forms.Padding(4);
            this.tabCreateUser.Name = "tabCreateUser";
            this.tabCreateUser.Padding = new System.Windows.Forms.Padding(4);
            this.tabCreateUser.Size = new System.Drawing.Size(1027, 389);
            this.tabCreateUser.TabIndex = 0;
            this.tabCreateUser.Text = "Create User";
            this.tabCreateUser.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(140, 45);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(121, 25);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "User Name :";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(286, 48);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(132, 22);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(536, 45);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(109, 25);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(680, 48);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(132, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstname.Location = new System.Drawing.Point(140, 102);
            this.lblFirstname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(117, 25);
            this.lblFirstname.TabIndex = 4;
            this.lblFirstname.Text = "First Name :";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(286, 105);
            this.txtFirstname.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(132, 22);
            this.txtFirstname.TabIndex = 5;
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastname.Location = new System.Drawing.Point(536, 102);
            this.lblLastname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(117, 25);
            this.lblLastname.TabIndex = 6;
            this.lblLastname.Text = "Last Name :";
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(680, 105);
            this.txtLastname.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(132, 22);
            this.txtLastname.TabIndex = 7;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(140, 160);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(92, 25);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "Position :";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(286, 163);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(4);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(132, 22);
            this.txtPosition.TabIndex = 9;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(140, 220);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(62, 25);
            this.lblRole.TabIndex = 10;
            this.lblRole.Text = "Role :";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(536, 160);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(124, 25);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "Department :";
            // 
            // cbbRole
            // 
            this.cbbRole.AllowDrop = true;
            this.cbbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Items.AddRange(new object[] {
            "Creator",
            "Reviewer",
            "Investigator",
            "Approver"});
            this.cbbRole.Location = new System.Drawing.Point(286, 221);
            this.cbbRole.Margin = new System.Windows.Forms.Padding(4);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(160, 24);
            this.cbbRole.TabIndex = 14;
            this.cbbRole.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbbDepartment
            // 
            this.cbbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDepartment.FormattingEnabled = true;
            this.cbbDepartment.Items.AddRange(new object[] {
            "Admin",
            "IMM",
            "ISU"});
            this.cbbDepartment.Location = new System.Drawing.Point(680, 161);
            this.cbbDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.cbbDepartment.Name = "cbbDepartment";
            this.cbbDepartment.Size = new System.Drawing.Size(160, 24);
            this.cbbDepartment.TabIndex = 13;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(342, 305);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(139, 36);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tabCreateUser);
            this.tabUser.Controls.Add(this.tabFindUser);
            this.tabUser.Location = new System.Drawing.Point(16, 110);
            this.tabUser.Margin = new System.Windows.Forms.Padding(4);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(1035, 418);
            this.tabUser.TabIndex = 1;
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabUser);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.UserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rolesBindingSource)).EndInit();
            this.tabFindUser.ResumeLayout(false);
            this.tabFindUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).EndInit();
            this.tabCreateUser.ResumeLayout(false);
            this.tabCreateUser.PerformLayout();
            this.tabUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.BindingSource rolesBindingSource;
        private System.Windows.Forms.TabPage tabFindUser;
        private System.Windows.Forms.Label lblFilterOption;
        private System.Windows.Forms.Label lblNameFilter;
        private System.Windows.Forms.DataGridView dgvSearchResult;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TabPage tabCreateUser;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cbbDepartment;
        private System.Windows.Forms.ComboBox cbbRole;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label lblFirstname;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TabControl tabUser;
    }
}