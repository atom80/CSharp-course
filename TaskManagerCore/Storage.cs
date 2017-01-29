using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public interface IStorage {
         User[] GetUsers();
         User GetUser(string userName);
    }

    public class Storage:IStorage {
        private string vUsersStorageFileName = @"";

        public User[] GetUsers() {
            throw new NotImplementedException();
        }

        public User GetUser(string userName) {
            throw new NotImplementedException();
        }


        public void SaveUser(User user) {
           //(object)user.
        }
    }
}
