using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TaskManager {
    class Test {
        public string TestProperty { get; set; }
        public void DoTheJob() { }
    }
    class Program {
        static void Main(string[] args) {
            MainForm MainForm1 = new MainForm();
            MainForm1.Show();
            MainForm1.Activate();
            Test test=new Test();
            Type testType=typeof(Test);
            foreach (MethodInfo m in testType.GetMethods(BindingFlags.Public|BindingFlags.Instance)){
            Console.WriteLine("{0}",m);}
            Console.ReadLine();
        }
    }
}
