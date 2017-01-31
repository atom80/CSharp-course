using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public class UserAction : Attribute {
        private string vDescription;
        private UserTypes[] vUserTypes;
        public UserAction(string description, UserTypes[] usersAllowed) {
            vDescription = description;
            vUserTypes = usersAllowed;
            // Check authorization here?
        }
    }
}
