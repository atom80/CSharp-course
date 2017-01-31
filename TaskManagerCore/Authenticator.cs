using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public class Authenticator : IAuthenticator {
        private IStorage vStorage;
        public IStorage Storage { get { return vStorage; } }
        public virtual UserSession AuthenticateUser() {
            throw new NotImplementedException();
        }
        //public virtual bool AuthenticateUser(User user) {
        //            throw new NotImplementedException();
        //}

        public User AuthenticateUserByPassword(string userName, string userPassword) { // need to seal it!
            //if ((userName == "Administrator") && (userPassword == "Administrator")) { return true; } else {
            if (userName == userPassword) {
                User user = vStorage.GetUserByName(userName);
                return user;
            } else {
                throw new NotImplementedException();
            }
        }

        public Authenticator(IStorage storage) {
            vStorage = storage;
        }
    }
}
