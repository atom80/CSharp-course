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
using TaskManagerConsole;
using System.Reflection;

namespace TaskManagerWinForms {
    public partial class Form1 : Form {
        TaskManagerConsole.TaskManager vTaskManager = new TaskManagerConsole.TaskManager(new TaskManagerConsole.Storage(), new AuthForms());
        public Form1() {
            //this.Visible = false;
            InitializeComponent();
            //Thread.Sleep(2000);
            //this.Visible = true;
            menuStrip1.Enabled = false;
            menuStrip1.Visible = false;
            tablessTabControl1.SelectedTab = tabPageAuthorization;
            lblErrorMessage.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(vTaskManager.Timer.TimerInterval.ToString());
            }

        private void reflectionToolStripMenuItem_Click(object sender, EventArgs e) {
            tablessTabControl1.SelectedTab=tabPageReflection;
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
                if (vTaskManager.TryLogon(comboBoxUserName.Text, textBoxPassword.Text)) {
                    menuStrip1.Enabled = true;
                    menuStrip1.Visible = true;
                    tablessTabControl1.SelectedTab = tabPageUserFunctions;
                }
            } catch (Exception exc) {
                lblErrorMessage.Text = "Authorization failed: "+exc.Message;
            }
        }

        private void userActionsToolStripMenuItem_Click(object sender, EventArgs e) {
            tablessTabControl1.SelectedTab = tabPageUserFunctions;
        }


        private void comboBoxUserName_SelectedIndexChanged(object sender, EventArgs e) {
            if (sender is ComboBox) {
                if ((sender as ComboBox).Text == "Administrator") {
                    textBoxPassword.Text = "Administrator";
                }

            }
        }

    }
}
