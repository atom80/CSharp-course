using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public abstract class Authenticator : IAuthenticator {
        private IStorage vStorage;
        public IStorage Storage { get { return vStorage; } }
        public virtual UserSession AuthenticateUser() {
            throw new NotImplementedException();
        }
        public virtual bool AuthenticateUser(User user) {
                    throw new NotImplementedException();
        }

        public virtual bool AuthenticateUser(string userName, string userPassword) {
            //if ((userName == "Administrator") && (userPassword == "Administrator")) { return true; } else {
            if (userName == userPassword) { return true; } else {
                throw new NotImplementedException();
            }
        }

        public Authenticator(IStorage storage) {
            vStorage = storage;
        }
    }
}
