using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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

    [UserAction("General", new UserTypes[] { UserTypes.Administrator, UserTypes.Manager, UserTypes.Developer })]
    public class Storage : IStorage {
        private string vUsersStorageFileName = @"/dev/null";
        private ConcurrentDictionary<Guid, User> vUsers = new ConcurrentDictionary<Guid, User>();
        public User[] Users { get { return vUsers.Values.ToArray<User>(); } }


        public User GetUserByName(string userName) {
            User user = vUsers.Values.First(usr => usr.UserName == userName);
            if (user == null) {
                throw new Exception(string.Format("User \"{0}\" not found!", userName));
            }
            return user;
        }

        private void LoadUsers() {
            User user = User.Factory("Administrator", UserTypes.Administrator);
            vUsers.TryAdd(user.UserId, user);
            for (int i = 0; i < 20; i++) {
                user = User.GenerateRandomUser();
                vUsers.TryAdd(user.UserId, user);
            }
        }

        [UserAction("All Users", new UserTypes[] { UserTypes.Administrator })]
        public List<User> ListUsers() {
            return vUsers.Values.ToList<User>();
        }

        [UserAction("All Projects", new UserTypes[] { UserTypes.Administrator, UserTypes.Manager, UserTypes.Developer })]
        public List<Project> ListProjects() {
            return null;
        }

        [UserAction("All Tasks", new UserTypes[] { UserTypes.Administrator, UserTypes.Manager, UserTypes.Developer })]
        public List<BaseTask> ListTasks() {
            return null;
        }

        [UserAction("My Projects", new UserTypes[] { UserTypes.Manager})]
        public List<Project> ListMyProjects(Manager mgr) {
            return null;
        }

        [UserAction("My Tasks", new UserTypes[] { UserTypes.Developer})]
        public List<Project> ListMyProjects(Developer dev) {
            return null;
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
