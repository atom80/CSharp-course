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

namespace TaskManagerWinForms {
    public partial class Form1 : Form {
        TaskManagerConsole.TaskManager vTaskManager = new TaskManagerConsole.TaskManager(new TaskManagerConsole.Storage(), new AuthForms());
        public Form1() {
            this.Visible = false;
            InitializeComponent();
            Thread.Sleep(2000);
            this.Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(vTaskManager.Timer.TimerInterval.ToString());
            }

        private void tabPage2_Click(object sender, EventArgs e) {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void reflectionToolStripMenuItem_Click(object sender, EventArgs e) {
            FormReflectionInfo fmReflectionInfo = new FormReflectionInfo();
            fmReflectionInfo.Show();
        }

    }
}
