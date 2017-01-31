using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TaskManagerCore {
    public class ReflectionInfo {
        private Assembly vAssembly = Assembly.GetExecutingAssembly();
        public Assembly Assembly { get { return vAssembly; } }

        private Type[] vTypes;
        public Type[] Types { get { return vTypes; } }

        //        private Type[] vClasses;
        public Type[] Classes { get { return (from rt in vTypes where rt.IsClass orderby rt.Name select rt).ToArray(); } }

        //        private Type[] vInterfaces;
        public Type[] Interfaces { get { return (from rt in vTypes where rt.IsInterface orderby rt.Name select rt).ToArray(); } }

        public ReflectionInfo() {
            vTypes = vAssembly.GetTypes();
            //vAssembly.GetCustomAttributes();
        }

        public List<string> GetUserActionTopics(User user) {
            List<string> topicsList = new List<string>();
            foreach (Type cls in GetAllowedClasses(user)) {

            }
            return topicsList;
        }

        public List<Type> GetAllowedClasses(User user) {
            UserTypes userType = user.UserType;
            List<Type> clsList = new List<Type>();
            foreach (Type cls in this.Classes) {
                object[] attrs = cls.GetCustomAttributes(typeof(UserAction), false);
                if (attrs.Length == 0)
                    continue;  // class has the UserAction attribute
                if (!(attrs[0] as UserAction).Allowed.Contains(userType))
                    continue; // userType is in Allowed list
                clsList.Add(cls);
            }
            return clsList;
        }

        public List<MethodInfo> GetAllowedMethodForClass(Type cls, User user) {
            UserTypes userType = user.UserType;
            List<MethodInfo> methList = new List<MethodInfo>();
            foreach (MethodInfo meth in cls.GetMethods()) {
                object[] attrs = meth.GetCustomAttributes(typeof(UserAction), false);
                if (attrs.Length == 0)
                    continue;  // class has the UserAction attribute
                if (!(attrs[0] as UserAction).Allowed.Contains(userType))
                    continue; // userType is in Allowed list
                methList.Add(meth);
            }
            return methList;
        }

    }
}
