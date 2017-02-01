using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using TaskManagerCore;

namespace TaskManagerWinForms {
    public partial class ParamsForm : Form {
        private MethodInfo vMethodInfo;
        private TaskManager vTaskManager;
        public ParamsForm(MethodInfo meth,TaskManager taskManager) {
            vMethodInfo = meth;
            vTaskManager = taskManager;
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid() {
            int rowIndex = 0;
            foreach (ParameterInfo pi in vMethodInfo.GetParameters()) {
                //pi.GetCustomAttributes(typeof(),false);
                //MessageBox.Show(string.Format("Parameter name: {0}\nParameter type: {1}",pi.Name,pi.GetType()));
                rowIndex = dataGridView1.Rows.Add(pi.Name, pi.ParameterType.Name, "");
                if (!(pi.ParameterType.IsPrimitive || pi.ParameterType.Equals(typeof(string)))) {
                    DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                    //if (pi.ParameterType.IsEnum) {
                    //    cell.DataSource=Enum.GetNames(pi.ParameterType.GetType()).ToList(); //doesn't work
                    //}
                    switch (pi.ParameterType.Name) {  // RRR
                        case "UserStates": { cell.DataSource = Enum.GetNames(typeof(UserStates)).ToList(); }
                        break;
                        case "UserTypes": { cell.DataSource = Enum.GetNames(typeof(UserTypes)).ToList(); }
                        break;
                        default: {
                            cell.DataSource = vTaskManager.Storage.Users;
                            cell.DisplayMember = "UserFullName";
                            cell.ValueMember = "UserId";
                        };
                        break;
                    }
                    dataGridView1.Rows[rowIndex].Cells[2] = cell;
                }
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
