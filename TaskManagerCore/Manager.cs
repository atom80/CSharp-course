using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public class Manager:User {
        public Manager(string userName)
            : base(userName, UserTypes.Manager, UserStates.Unlocked) {

        }
    }
}
