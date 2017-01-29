using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole {
    public abstract class Authenticator : IAuthenticator {
        public bool AuthenticateUser(string userName, string userPassword) {
            if ((userName == "Administrator") && (userPassword == "Administrator")) { return true; } else {
                throw new NotImplementedException();
            }
        }
    }
}
