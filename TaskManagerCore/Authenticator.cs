using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public abstract class Authenticator : IAuthenticator {
        public virtual UserSession AuthenticateUser(IStorage storage) {
            throw new NotImplementedException();
        }
        public virtual bool AuthenticateUser(User user) {
                    throw new NotImplementedException();
        }

        public virtual bool AuthenticateUser(string userName, string userPassword) {
            if ((userName == "Administrator") && (userPassword == "Administrator")) { return true; } else {
                throw new NotImplementedException();
            }
        }
    }
}
