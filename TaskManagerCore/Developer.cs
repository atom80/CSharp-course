using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public class Developer : User {
        public Developer(string userName) : base(userName, UserTypes.Developer, UserStates.Locked) { }
    }
}
