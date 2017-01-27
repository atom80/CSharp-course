using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TaskManagerConsole {
    public class Authorization : Attribute {

    }
    public class UserAction : Attribute {
        private string vDescription;
        public UserAction(string description) {
            vDescription = description;
            // Check authorization here

        }
    }
}
