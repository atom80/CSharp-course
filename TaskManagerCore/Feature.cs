using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    [UserAction("Features", new UserTypes[] { UserTypes.Administrator,UserTypes.Manager,UserTypes.Developer})]
    class Feature:BaseTask {
        [UserAction("Create feature", new UserTypes[] { UserTypes.Manager})]
        public Feature() {
        }

     
    }
}
