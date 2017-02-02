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
            vTaskManager.DoAskParameters += DoAskParameters;
            //this.Visible = false;
            InitializeComponent();
            //Thread.Sleep(2000);
            //this.Visible = true;
            menuStrip1.Enabled = false;
            menuStrip1.Visible = false;
            tablessTabControl1.SelectedTab = tabPageAuthorization;
            lblErrorMessage.Text = "";
        }

        private delegate void FormSetAuthPage();
        private void SetAuthPage() {
            menuStrip1.Enabled = false;
            menuStrip1.Visible = false;
            tablessTabControl1.SelectedTab = tabPageAuthorization;
        }

        private List<object> FormAskParameters(UserSession userSession, MethodInfo meth) {
            //MessageBox.Show(string.Format("[{0}] Parameters requested: {1}", Thread.CurrentThread.ManagedThreadId, meth));
            if (meth.GetParameters().Length == 0) {
                if (meth.ReturnType.IsGenericType) {
                    ReflectionInfo ri = new ReflectionInfo();
                    Type cls = meth.GetType();
                    List<object> list = vTaskManager.Storage.GetCollectionByClassName(meth.Name);
                    dataGridViewLists.DataSource = list;
                    tabControlUserActions.SelectedTab = tabPageDataList;

                }
                 //MessageBox.Show(string.Format("[{0}] Parameters requested: {1}", Thread.CurrentThread.ManagedThreadId, meth));
                return null;
            }

            List<object> data = null;
            ParamsForm pf = new ParamsForm(meth, vTaskManager);
            var res = pf.ShowDialog();
            if (res == DialogResult.OK) {
                data = pf.GetParams();
                try {
                    vTaskManager.Storage.DoAction(meth.DeclaringType.Name, meth.Name, data);
                } catch (Exception e) {
                    string errMsg=string.Format("I tried to invoke {0}\n but FAILED: {1}",meth,e.Message);
                    MessageBox.Show(errMsg, "Oops!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            pf.Dispose();
            return data;
        }

        public void SessionChangedHandler(UserSession session, SessionChangeArgs e) {
            SessionChangeType changeType = e.ChangeType;
            switch (changeType) {
                case SessionChangeType.Started:
                case SessionChangeType.Stopped:
                case SessionChangeType.MainSessionStopped: {
                    lock (vTaskManager) {
                        int sessionCount = (from UserSession us in vTaskManager.UserSessions where (us.ActionHandler.Status == TaskStatus.Running) select us).ToList().Count;
                        lblUsersLoggedOn.Text = string.Format("Users: {0}", sessionCount);
                    }
                    if (changeType == SessionChangeType.MainSessionStopped) {
                        this.Invoke(new FormSetAuthPage(SetAuthPage));
                    }
                }
                break;
                default:
                break;
            }
        }

        public string[] GetCredentials() {
            string[] credentials = new string[2];
            credentials[0] = comboBoxUserName.SelectedValue.ToString();
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
        }

        private async void button1_Click(object sender, EventArgs e) {
            bool logonOk = false;
            try {
                logonOk = vTaskManager.LogonUser();
                menuStrip1.Enabled = true;
                menuStrip1.Visible = true;
                tablessTabControl1.SelectedTab = tabPageUserActions;
            } catch (Exception exc) {
                lblErrorMessage.Text = "Authorization failed: " + exc.Message;
            }
            if (logonOk) {
                InitializeClassMap();
                InitializeUserActions(vTaskManager.MainUserSession.SessionUser);
                if (vTaskManager.UserSessions.Count < 2) {
                    Task taskBgUsers = Task.Run(() => vTaskManager.LogonBackgroundUsers(10));
                    await taskBgUsers;
                }
            }
        }

        private void InitializeClassMap() { /// most of this code should be moved to ReflectionInfo
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

        private void InitializeUserActions(User user) {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            labelUserActions.Text = string.Format("User actions for {0}", user.UserFullName);
            ReflectionInfo ri = new ReflectionInfo();
            UserTypes userType = user.UserType;
            listViewUserActions.Items.Clear();
            ListViewGroup grp;
            Attribute attr;
            foreach (Type cls in ri.GetAllowedClasses(user)) {
                attr = cls.GetCustomAttribute(typeof(UserAction), false);
                grp = new ListViewGroup((attr as UserAction).Description);
                listViewUserActions.Groups.Add(grp);
                int imgIndex = 0;
                ListViewItem lvi = null;
                foreach (MethodInfo meth in ri.GetAllowedMethodForClass(cls, user)) {
                    attr = meth.GetCustomAttribute(typeof(UserAction), false);
                    imgIndex = rnd.Next(0, listViewUserActions.LargeImageList.Images.Count + 1);
                    lvi = listViewUserActions.Items.Add(Guid.NewGuid().ToString(), (attr as UserAction).Description, imgIndex);
                    lvi.Group = grp;
                    lvi.ToolTipText = lvi.Name;
                    lvi.Tag = meth;
                    //listViewUserActions.Items.Add(new ListViewItem((attr as UserAction).Description,imgIndex, grp));
                }
            }
        }

        private void userActionsToolStripMenuItem_Click(object sender, EventArgs e) {
            tablessTabControl1.SelectedTab = tabPageUserActions;
        }


        private void comboBoxUserName_SelectedIndexChanged(object sender, EventArgs e) {
            if (sender is ComboBox) {
                textBoxPassword.Text = (sender as ComboBox).SelectedValue.ToString();
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

        private void UpdateUserSessionPage() {
            dataGridViewWaiting.Rows.Clear();
            lock (vTaskManager) {
                foreach (UserSession session in vTaskManager.UserSessions) {
                    TaskStatus sessionState = session.ActionHandler.Status;
                    UserSessionTypes sessionType = session.SessionType;
                    string sessionUserAcronym = session.SessionUser.UserAcronym;
                    string sessionUserName = session.SessionUser.UserName;
                    UserTypes sessionUserType = session.SessionUser.UserType;
                    DateTime sessionStartTime = session.SessionStartDateTime;
                    dataGridViewWaiting.Rows.Add(0, sessionStartTime, sessionType, sessionUserAcronym, sessionUserName, sessionUserType, sessionState);
                }
            }
        }

        private void timerWaiting_Tick(object sender, EventArgs e) {
            UpdateUserSessionPage();
        }

        private void tabPageWaiting_Leave(object sender, EventArgs e) {
            dataGridViewWaiting.Rows.Clear();
            timerWaiting.Enabled = false;
        }

        private void sessionMonitorToolStripMenuItem_Click(object sender, EventArgs e) {
            labelWaiting.Text = "User sessions";
            tablessTabControl1.SelectedTab = tabPageWaiting;
        }

        private void tabPageAuthorization_Enter(object sender, EventArgs e) {
            lblErrorMessage.Text = "";
            comboBoxUserName.DataSource = vTaskManager.Storage.Users;
            comboBoxUserName.DisplayMember = "UserFullName";
            comboBoxUserName.ValueMember = "UserName";
            //foreach(User user in vTaskManager.Storage.Users){
            //    comboBoxUserName.Items.Add(string.Format("{0} ({1})",user.UserName,user.UserType));
            //}
        }

        private void listViewUserActions_Click(object sender, EventArgs e) {
            if (sender is ListView) {
                ListViewItem lvi = (sender as ListView).FocusedItem;
                if (lvi == null) { return; }
                vTaskManager.MainUserSession.EnqueueTask(new UserTask(lvi.Tag, Guid.Parse(lvi.Name))); //RRR
                // MessageBox.Show(string.Format("[{0}] {1} {2} {3}", Thread.CurrentThread.ManagedThreadId, lvi.Name, lvi.Text, lvi.Tag.ToString()));
            }
        }

        private List<object> DoAskParameters(UserSession userSession, MethodInfo meth) {
            return (List<object>)this.Invoke(new AskParameters(FormAskParameters), new object[] { userSession, meth });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {

        }
    }
}
