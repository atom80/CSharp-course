using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TaskManagerCore {
    [UserAction("Projects", new UserTypes[] { UserTypes.Manager, UserTypes.Developer })]
    class Project {
        [UserAction("Projects", new UserTypes[] { UserTypes.Manager, UserTypes.Developer })]
        public static void ListProjects() { }

        [UserAction("Create project", new UserTypes[] { UserTypes.Manager })]
        public void CreateProject() { }

        [UserAction("Close project", new UserTypes[] { UserTypes.Manager })]
        public void CloseProject() { }

        [UserAction("Open projects", new UserTypes[] { UserTypes.Manager })]
        public void OpenProject() { }
    }
}
