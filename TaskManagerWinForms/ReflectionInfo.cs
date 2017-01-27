using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagerConsole;
using System.Reflection;

namespace TaskManagerWinForms {
    public partial class FormReflectionInfo : Form {
        public FormReflectionInfo() {
            InitializeComponent();
        }

        private void ReflectionInfo_Load(object sender, EventArgs e) {
            ReflectionInfo refInfo = new ReflectionInfo();
            TreeNode classNode = treeView1.Nodes.Add("Classes");
            Font newFnt = new Font("Arial",10, FontStyle.Bold);
            
            classNode.NodeFont = newFnt;
            foreach (Type refType in (from rt in refInfo.Types where (rt.IsClass && (rt.GetCustomAttributes(typeof(UserAction), false).Length > 0)) orderby rt.Name select rt)) {
                //refType.CustomAttributes.AsQueryable

                TreeNode newNode = classNode.Nodes.Add(refType.Name);
                TreeNode cnstrNode = newNode.Nodes.Add("Constructors");
                cnstrNode.NodeFont = newFnt;
                var constInfo = new List<MethodBase>(from rtCons in refType.GetConstructors() orderby rtCons.Name select rtCons);
                var metInfo = new List<MethodBase>((from mt in refType.GetMethods() orderby mt.Name select mt));
                //foreach (System.Reflection.ConstructorInfo ci in (from rtCons in refType.GetConstructors() orderby rtCons.Name select rtCons)) {
                //    //ci.
                //}
                TreeNode methNode = newNode.Nodes.Add("Methods");
                methNode.NodeFont = newFnt;
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
    }
}
