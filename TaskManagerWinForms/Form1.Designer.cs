namespace TaskManagerWinForms {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tablessTabControl1 = new TaskManagerWinForms.TablessTabControl();
            this.tabPageAuthorization = new System.Windows.Forms.TabPage();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.comboBoxUserName = new System.Windows.Forms.ComboBox();
            this.panelAuth = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogon = new System.Windows.Forms.Button();
            this.tabPageUserActions = new System.Windows.Forms.TabPage();
            this.panelUserActions = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageReflection = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelCaptionClassMap = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tablessTabControl1.SuspendLayout();
            this.tabPageAuthorization.SuspendLayout();
            this.panelAuth.SuspendLayout();
            this.tabPageUserActions.SuspendLayout();
            this.panelUserActions.SuspendLayout();
            this.tabPageReflection.SuspendLayout();
            this.panelCaptionClassMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 618);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(996, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.functionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reflectionToolStripMenuItem,
            this.userActionsToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.functionsToolStripMenuItem.Text = "Functions";
            // 
            // reflectionToolStripMenuItem
            // 
            this.reflectionToolStripMenuItem.Name = "reflectionToolStripMenuItem";
            this.reflectionToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.reflectionToolStripMenuItem.Text = "Class map";
            this.reflectionToolStripMenuItem.Click += new System.EventHandler(this.reflectionToolStripMenuItem_Click);
            // 
            // userActionsToolStripMenuItem
            // 
            this.userActionsToolStripMenuItem.Name = "userActionsToolStripMenuItem";
            this.userActionsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.userActionsToolStripMenuItem.Text = "User actions";
            this.userActionsToolStripMenuItem.Click += new System.EventHandler(this.userActionsToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 553);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 65);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tablessTabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(996, 529);
            this.panel2.TabIndex = 3;
            // 
            // tablessTabControl1
            // 
            this.tablessTabControl1.Controls.Add(this.tabPageAuthorization);
            this.tablessTabControl1.Controls.Add(this.tabPageUserActions);
            this.tablessTabControl1.Controls.Add(this.tabPageReflection);
            this.tablessTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablessTabControl1.Location = new System.Drawing.Point(0, 0);
            this.tablessTabControl1.Name = "tablessTabControl1";
            this.tablessTabControl1.SelectedIndex = 0;
            this.tablessTabControl1.Size = new System.Drawing.Size(996, 529);
            this.tablessTabControl1.TabIndex = 0;
            // 
            // tabPageAuthorization
            // 
            this.tabPageAuthorization.Controls.Add(this.lblErrorMessage);
            this.tabPageAuthorization.Controls.Add(this.label4);
            this.tabPageAuthorization.Controls.Add(this.textBoxPassword);
            this.tabPageAuthorization.Controls.Add(this.lblPassword);
            this.tabPageAuthorization.Controls.Add(this.lblUserName);
            this.tabPageAuthorization.Controls.Add(this.comboBoxUserName);
            this.tabPageAuthorization.Controls.Add(this.panelAuth);
            this.tabPageAuthorization.Controls.Add(this.btnLogon);
            this.tabPageAuthorization.Location = new System.Drawing.Point(4, 22);
            this.tabPageAuthorization.Name = "tabPageAuthorization";
            this.tabPageAuthorization.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuthorization.Size = new System.Drawing.Size(988, 503);
            this.tabPageAuthorization.TabIndex = 2;
            this.tabPageAuthorization.Text = "tabPageAuthorization";
            this.tabPageAuthorization.UseVisualStyleBackColor = true;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(24, 222);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(96, 13);
            this.lblErrorMessage.TabIndex = 7;
            this.lblErrorMessage.Text = "Authorization failed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(472, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Administrator/Administrator";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(131, 145);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(302, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.Text = "Administrator";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(24, 145);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(24, 104);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "User name";
            // 
            // comboBoxUserName
            // 
            this.comboBoxUserName.AutoCompleteCustomSource.AddRange(new string[] {
            "Administrator"});
            this.comboBoxUserName.FormattingEnabled = true;
            this.comboBoxUserName.Items.AddRange(new object[] {
            "Administrator",
            "Manager",
            "User"});
            this.comboBoxUserName.Location = new System.Drawing.Point(131, 100);
            this.comboBoxUserName.Name = "comboBoxUserName";
            this.comboBoxUserName.Size = new System.Drawing.Size(302, 21);
            this.comboBoxUserName.TabIndex = 1;
            this.comboBoxUserName.Text = "Administrator";
            this.comboBoxUserName.SelectedIndexChanged += new System.EventHandler(this.comboBoxUserName_SelectedIndexChanged);
            // 
            // panelAuth
            // 
            this.panelAuth.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelAuth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAuth.Controls.Add(this.label2);
            this.panelAuth.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAuth.Location = new System.Drawing.Point(3, 3);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(982, 43);
            this.panelAuth.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(980, 41);
            this.label2.TabIndex = 0;
            this.label2.Text = "Authorization";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(475, 143);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(75, 23);
            this.btnLogon.TabIndex = 3;
            this.btnLogon.Text = "Go!";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPageUserActions
            // 
            this.tabPageUserActions.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageUserActions.Controls.Add(this.panelUserActions);
            this.tabPageUserActions.Location = new System.Drawing.Point(4, 22);
            this.tabPageUserActions.Name = "tabPageUserActions";
            this.tabPageUserActions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserActions.Size = new System.Drawing.Size(988, 503);
            this.tabPageUserActions.TabIndex = 0;
            this.tabPageUserActions.Text = "tabPageUserActions";
            // 
            // panelUserActions
            // 
            this.panelUserActions.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelUserActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserActions.Controls.Add(this.label3);
            this.panelUserActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserActions.Location = new System.Drawing.Point(3, 3);
            this.panelUserActions.Name = "panelUserActions";
            this.panelUserActions.Size = new System.Drawing.Size(982, 43);
            this.panelUserActions.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(980, 41);
            this.label3.TabIndex = 0;
            this.label3.Text = "User actions";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageReflection
            // 
            this.tabPageReflection.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageReflection.Controls.Add(this.treeView1);
            this.tabPageReflection.Controls.Add(this.panelCaptionClassMap);
            this.tabPageReflection.Location = new System.Drawing.Point(4, 22);
            this.tabPageReflection.Name = "tabPageReflection";
            this.tabPageReflection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReflection.Size = new System.Drawing.Size(988, 503);
            this.tabPageReflection.TabIndex = 1;
            this.tabPageReflection.Text = "tabPageReflection";
            this.tabPageReflection.Enter += new System.EventHandler(this.tabPageReflection_Enter);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(3, 46);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(367, 454);
            this.treeView1.TabIndex = 2;
            // 
            // panelCaptionClassMap
            // 
            this.panelCaptionClassMap.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelCaptionClassMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCaptionClassMap.Controls.Add(this.label1);
            this.panelCaptionClassMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaptionClassMap.Location = new System.Drawing.Point(3, 3);
            this.panelCaptionClassMap.Name = "panelCaptionClassMap";
            this.panelCaptionClassMap.Size = new System.Drawing.Size(982, 43);
            this.panelCaptionClassMap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(980, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class map";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 640);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Task Manager v.0.1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tablessTabControl1.ResumeLayout(false);
            this.tabPageAuthorization.ResumeLayout(false);
            this.tabPageAuthorization.PerformLayout();
            this.panelAuth.ResumeLayout(false);
            this.tabPageUserActions.ResumeLayout(false);
            this.panelUserActions.ResumeLayout(false);
            this.tabPageReflection.ResumeLayout(false);
            this.panelCaptionClassMap.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private TablessTabControl tablessTabControl1;
        private System.Windows.Forms.TabPage tabPageUserActions;
        private System.Windows.Forms.TabPage tabPageReflection;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reflectionToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelCaptionClassMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageAuthorization;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelUserActions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem userActionsToolStripMenuItem;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.ComboBox comboBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblErrorMessage;



    }
}

