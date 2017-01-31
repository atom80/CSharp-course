using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public sealed class Admin : User {

        public Admin(string userName)
            : base(userName, UserTypes.Administrator, UserStates.Unlocked) {


        }
    }
}
