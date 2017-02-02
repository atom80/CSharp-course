using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public class UserAction : Attribute {
        private string vDescription;
        public string Description { get { return vDescription; } set { vDescription = value; } }
        
        private UserTypes[] vAllowed;
        public UserTypes[] Allowed { get { return vAllowed; } set { vAllowed = value; } }

        public UserAction(string description, UserTypes[] usersAllowed) {
            vDescription = description;
            vAllowed = usersAllowed;
            // Check authorization here?
        }
    }
}
