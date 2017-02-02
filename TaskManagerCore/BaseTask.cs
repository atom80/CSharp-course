using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    [UserAction("Tasks", new UserTypes[] { UserTypes.Administrator,UserTypes.Manager,UserTypes.Developer})]
    public abstract class BaseTask {
        [UserAction("Assign task", new UserTypes[] { UserTypes.Manager})]
        public void Assign() { }

        [UserAction("Close task", new UserTypes[] { UserTypes.Manager, UserTypes.Developer })]
        public void Close() { }

        [UserAction("Reject task", new UserTypes[] { UserTypes.Manager })]
        public void Reject() { }
    }
}
