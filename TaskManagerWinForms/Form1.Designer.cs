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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsersLoggedOn = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.process1 = new System.Diagnostics.Process();
            this.timerWaiting = new System.Windows.Forms.Timer(this.components);
            this.sessionMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabPageWaiting = new System.Windows.Forms.TabPage();
            this.dataGridViewWaiting = new System.Windows.Forms.DataGridView();
            this.SessionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionStartedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelWaiting = new System.Windows.Forms.Label();
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
            this.tabPageWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaiting)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsersLoggedOn});
            this.statusStrip1.Location = new System.Drawing.Point(0, 618);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(996, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsersLoggedOn
            // 
            this.lblUsersLoggedOn.Name = "lblUsersLoggedOn";
            this.lblUsersLoggedOn.Size = new System.Drawing.Size(47, 17);
            this.lblUsersLoggedOn.Text = "Users: 0";
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
            this.toolStripSeparator1,
            this.logOffToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logOffToolStripMenuItem.Text = "Log off";
            this.logOffToolStripMenuItem.Click += new System.EventHandler(this.logOffToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
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
            this.userActionsToolStripMenuItem,
            this.sessionMonitorToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.functionsToolStripMenuItem.Text = "Functions";
            // 
            // reflectionToolStripMenuItem
            // 
            this.reflectionToolStripMenuItem.Name = "reflectionToolStripMenuItem";
            this.reflectionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.reflectionToolStripMenuItem.Text = "Class map";
            this.reflectionToolStripMenuItem.Click += new System.EventHandler(this.reflectionToolStripMenuItem_Click);
            // 
            // userActionsToolStripMenuItem
            // 
            this.userActionsToolStripMenuItem.Name = "userActionsToolStripMenuItem";
            this.userActionsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
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
            this.panel1.Visible = false;
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
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.FileName = "cmd.exe";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            this.process1.Exited += new System.EventHandler(this.process1_Exited);
            // 
            // timerWaiting
            // 
            this.timerWaiting.Interval = 500;
            this.timerWaiting.Tick += new System.EventHandler(this.timerWaiting_Tick);
            // 
            // sessionMonitorToolStripMenuItem
            // 
            this.sessionMonitorToolStripMenuItem.Name = "sessionMonitorToolStripMenuItem";
            this.sessionMonitorToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.sessionMonitorToolStripMenuItem.Text = "Session monitor";
            this.sessionMonitorToolStripMenuItem.Click += new System.EventHandler(this.sessionMonitorToolStripMenuItem_Click);
            // 
            // tablessTabControl1
            // 
            this.tablessTabControl1.Controls.Add(this.tabPageAuthorization);
            this.tablessTabControl1.Controls.Add(this.tabPageUserActions);
            this.tablessTabControl1.Controls.Add(this.tabPageReflection);
            this.tablessTabControl1.Controls.Add(this.tabPageWaiting);
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
            // tabPageWaiting
            // 
            this.tabPageWaiting.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPageWaiting.Controls.Add(this.dataGridViewWaiting);
            this.tabPageWaiting.Controls.Add(this.panel3);
            this.tabPageWaiting.Location = new System.Drawing.Point(4, 22);
            this.tabPageWaiting.Name = "tabPageWaiting";
            this.tabPageWaiting.Size = new System.Drawing.Size(988, 503);
            this.tabPageWaiting.TabIndex = 3;
            this.tabPageWaiting.Text = "tabPageWaiting";
            this.tabPageWaiting.Enter += new System.EventHandler(this.tabPageWaiting_Enter);
            this.tabPageWaiting.Leave += new System.EventHandler(this.tabPageWaiting_Leave);
            // 
            // dataGridViewWaiting
            // 
            this.dataGridViewWaiting.AllowUserToAddRows = false;
            this.dataGridViewWaiting.AllowUserToDeleteRows = false;
            this.dataGridViewWaiting.AllowUserToOrderColumns = true;
            this.dataGridViewWaiting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWaiting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SessionId,
            this.SessionStartedAt,
            this.SessionType,
            this.UserName,
            this.UserType,
            this.SessionState});
            this.dataGridViewWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWaiting.Location = new System.Drawing.Point(0, 43);
            this.dataGridViewWaiting.Name = "dataGridViewWaiting";
            this.dataGridViewWaiting.ReadOnly = true;
            this.dataGridViewWaiting.Size = new System.Drawing.Size(988, 460);
            this.dataGridViewWaiting.TabIndex = 3;
            // 
            // SessionId
            // 
            this.SessionId.HeaderText = "Session ID";
            this.SessionId.Name = "SessionId";
            this.SessionId.ReadOnly = true;
            // 
            // SessionStartedAt
            // 
            this.SessionStartedAt.HeaderText = "Started";
            this.SessionStartedAt.Name = "SessionStartedAt";
            this.SessionStartedAt.ReadOnly = true;
            // 
            // SessionType
            // 
            this.SessionType.HeaderText = "Session type";
            this.SessionType.Name = "SessionType";
            this.SessionType.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // UserType
            // 
            this.UserType.HeaderText = "User type";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            // 
            // SessionState
            // 
            this.SessionState.HeaderText = "Session State";
            this.SessionState.Name = "SessionState";
            this.SessionState.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelWaiting);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(988, 43);
            this.panel3.TabIndex = 2;
            // 
            // labelWaiting
            // 
            this.labelWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaiting.Location = new System.Drawing.Point(0, 0);
            this.labelWaiting.Name = "labelWaiting";
            this.labelWaiting.Size = new System.Drawing.Size(986, 41);
            this.labelWaiting.TabIndex = 0;
            this.labelWaiting.Text = "Waiting for logoff...";
            this.labelWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tabPageWaiting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWaiting)).EndInit();
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripStatusLabel lblUsersLoggedOn;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageWaiting;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelWaiting;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.DataGridView dataGridViewWaiting;
        private System.Windows.Forms.Timer timerWaiting;
        private System.Windows.Forms.ToolStripMenuItem sessionMonitorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionStartedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionState;



    }
}

