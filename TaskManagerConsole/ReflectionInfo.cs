using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TaskManagerConsole {
    public class ReflectionInfo {
        private Assembly vAssembly = Assembly.GetExecutingAssembly();
        public Assembly Assembly { get { return vAssembly; } }
        
        private Type[] vTypes;
        public Type[] Types { get { return vTypes; } }
        //public String[] Classes{get{
        //return (from rt in vTypes where rt.IsClass orderby rt.Name select rt).ToArray();
        //}
        public ReflectionInfo() {
            vTypes=vAssembly.GetTypes();
            //vAssembly.GetCustomAttributes();
        }

    }
}
