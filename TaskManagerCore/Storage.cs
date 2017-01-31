using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public interface IStorage {
        User[] Users { get; }
        void Load();
        User GetUserByName(string userName);
        void Save();
    }

    public class Storage : IStorage {
        private string vUsersStorageFileName = @"/dev/null";
        private List<User> vUsers = new List<User>();
        public User[] Users { get { return vUsers.ToArray(); } }

        public User GetUserByName(string userName) {
            User user = vUsers.Find(usr => usr.UserName == userName);
            if (user == null) {
                throw new Exception(string.Format("User \"{0}\" not found!",userName));
            }
            return user;
        }

        private void LoadUsers() {
            vUsers.Add(User.Factory("Administrator", UserTypes.Administrator));
            for (int i = 0; i < 20; i++) { vUsers.Add(User.GenerateRandomUser()); }
        }

        public void Load() {
            LoadUsers();
            //Load Projects, Tasks, ...
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
