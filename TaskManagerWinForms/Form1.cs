using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using TaskManagerCore;
using System.Reflection;

namespace TaskManagerWinForms {
    public partial class Form1 : Form {

        TaskManagerCore.TaskManager vTaskManager;
        public Form1() {
            IStorage storage = new Storage();
            vTaskManager = new TaskManagerCore.TaskManager(storage, new AuthForms(this, storage));
            vTaskManager.SessionChangedEvent += SessionChangedHandler;
            //this.Visible = false;
            InitializeComponent();
            //Thread.Sleep(2000);
            //this.Visible = true;
            menuStrip1.Enabled = false;
            menuStrip1.Visible = false;
            tablessTabControl1.SelectedTab = tabPageAuthorization;
            lblErrorMessage.Text = "";
        }

        public void SessionChangedHandler(UserSession session, SessionChangeType change) {
            switch (change) {
                case SessionChangeType.Started:
                case SessionChangeType.Stopped: {
                    int sessionCount = (from UserSession us in vTaskManager.UserSessions where (us.ActionHandler.Status == TaskStatus.Running) select us).ToList().Count;
                    lblUsersLoggedOn.Text = string.Format("Users: {0}", sessionCount);
                }break;
                default:
                break;
            }
        }

        public string[] GetCredentials() {
            string[] credentials = new string[2];
            credentials[0] = comboBoxUserName.Text;
            credentials[1] = textBoxPassword.Text;
            return credentials;
        }

        private async void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            menuStrip1.Enabled = false;
            menuStrip1.Visible = false;
            labelWaiting.Text = "Waiting for shutdown...";
            tablessTabControl1.SelectedTab = tabPageWaiting;
            Task taskShutdown = Task.Run(() => vTaskManager.Shutdown());
            await taskShutdown;
            Application.Exit();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(vTaskManager.Timer.TimerInterval.ToString());
        }

        private void reflectionToolStripMenuItem_Click(object sender, EventArgs e) {
            tablessTabControl1.SelectedTab = tabPageReflection;
        }

        private void tabPageReflection_Enter(object sender, EventArgs e) {
            ReflectionInfo refInfo = new ReflectionInfo();
            treeView1.Nodes.Clear();
            TreeNode classNode = treeView1.Nodes.Add("Classes");
            //Font newFnt = new Font("SegoeUI", 10, FontStyle.Bold);
            //classNode.NodeFont = newFnt;

            foreach (Type refType in refInfo.Classes) {
                //refType.CustomAttributes.AsQueryable

                TreeNode newNode = classNode.Nodes.Add(refType.Name);
                TreeNode cnstrNode = newNode.Nodes.Add("Constructors");
                //cnstrNode.NodeFont = newFnt;
                var constInfo = new List<MethodBase>(from rtCons in refType.GetConstructors() orderby rtCons.Name select rtCons);
                var metInfo = new List<MethodBase>((from mt in refType.GetMethods() orderby mt.Name select mt));
                //foreach (System.Reflection.ConstructorInfo ci in (from rtCons in refType.GetConstructors() orderby rtCons.Name select rtCons)) {
                //    //ci.
                //}
                TreeNode methNode = newNode.Nodes.Add("Methods");
                //methNode.NodeFont = newFnt;
                //                foreach (var mi in (from mt in refType.GetMethods() orderby mt.Name select mt)) {
                foreach (var mi in constInfo.Union(metInfo)) {

                    string pubText = mi.IsPublic ? "public " : "";
                    string privText = mi.IsPrivate ? "private " : "";
                    string abstText = mi.IsAbstract ? "abstract " : "";
                    string sealText = mi.IsFinal ? "sealed " : "";
                    string virtText = mi.IsVirtual ? "virtual " : "";
                    string methBrackets = mi.IsConstructor ? "[]" : "()";

                    string modText = string.Format("{0}{1}{2}{3}{4}", pubText, privText, abstText, sealText, virtText);// public/private abstract sealed virtual constructor
                    modText += " " + mi.Name + methBrackets;
                    if (mi.IsConstructor)
                        cnstrNode.Nodes.Add(modText);
                    else
                        methNode.Nodes.Add(modText);
                }
            }
            TreeNode intfNode = treeView1.Nodes.Add("Interfaces");
            foreach (Type refType in (from rt in refInfo.Types where rt.IsInterface select rt)) {
                TreeNode newNode = intfNode.Nodes.Add(refType.Name);
            }

            //TreeNode attrNode = treeView1.Nodes.Add("Attributes");
            //foreach (Type refType in (from rt in refInfo.Types where rt. select rt)) {
            //    TreeNode newNode = attrNode.Nodes.Add(refType.Name);
            //}

        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                vTaskManager.LogonUser();
                menuStrip1.Enabled = true;
                menuStrip1.Visible = true;
                tablessTabControl1.SelectedTab = tabPageUserActions;
            } catch (Exception exc) {
                lblErrorMessage.Text = "Authorization failed: " + exc.Message;
            }
            if (vTaskManager.UserSessions.Count < 2) {
                vTaskManager.LogonUser(10);
            }
        }

        private void userActionsToolStripMenuItem_Click(object sender, EventArgs e) {
            tablessTabControl1.SelectedTab = tabPageUserActions;
        }


        private void comboBoxUserName_SelectedIndexChanged(object sender, EventArgs e) {
            if (sender is ComboBox) {
                if ((sender as ComboBox).Text == "Administrator") {
                    textBoxPassword.Text = "Administrator";
                }

            }
        }

        private async void logOffToolStripMenuItem_Click(object sender, EventArgs e) {
            menuStrip1.Enabled = false;
            menuStrip1.Visible = false;
            labelWaiting.Text = "Waiting for logoff...";
            tablessTabControl1.SelectedTab = tabPageWaiting;
            Task taskLogoff = Task.Run(() => vTaskManager.LogoffUser());
            await taskLogoff;
            tablessTabControl1.SelectedTab = tabPageAuthorization;
            //vTaskManager.UserSessions
        }

        private void process1_Exited(object sender, EventArgs e) {

        }

        private void tabPageWaiting_Enter(object sender, EventArgs e) {
            dataGridViewWaiting.Rows.Clear();
            timerWaiting.Enabled = true;
        }

        private void timerWaiting_Tick(object sender, EventArgs e) {
            dataGridViewWaiting.Rows.Clear();
            foreach (UserSession session in vTaskManager.UserSessions) {
                TaskStatus sessionState = session.ActionHandler.Status;//
                UserSessionTypes sessionType = session.SessionType;
                string sessionUserName = session.SessionUser.UserName;//
                UserTypes sessionUserType = session.SessionUser.UserType;
                DateTime sessionStartTime = session.SessionStartDateTime;
                dataGridViewWaiting.Rows.Add(0, sessionStartTime, sessionType, sessionUserName, sessionUserType, sessionState);
            }
        }

        private void tabPageWaiting_Leave(object sender, EventArgs e) {
            dataGridViewWaiting.Rows.Clear();
            timerWaiting.Enabled = false;
        }

        private void sessionMonitorToolStripMenuItem_Click(object sender, EventArgs e) {
            labelWaiting.Text = "User sessions";
            tablessTabControl1.SelectedTab = tabPageWaiting;
        }

    }
}
