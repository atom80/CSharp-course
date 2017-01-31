using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public interface IStorage {
        void Load();
        User GetUserByName(string userName);
        void Save();
    }

    public class Storage:IStorage {
        private string vUsersStorageFileName = @"";
        private List<User> vUsers = new List<User>();
        public User[] Users{get{return vUsers.ToArray();}}

        public User GetUserByName(string userName){
            //User user=null;
            return User.Factory(userName, UserTypes.Developer);
            //return user;
        }

        public void Load() {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
