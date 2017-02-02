using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TaskManagerCore {
    public interface IStorage {
        User[] Users { get; }
        void Load();
        User GetUserByName(string userName);
        void Save();
        List<object> GetCollectionByClassName(string className);
        void DoAction(string className, string methodName, List<object> parameters);
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
            return new List<Project>();
        }

        [UserAction("All Tasks", new UserTypes[] { UserTypes.Administrator, UserTypes.Manager, UserTypes.Developer })]
        public List<BaseTask> ListTasks() {
            return null;
        }

        [UserAction("My Projects", new UserTypes[] { UserTypes.Manager })]
        public List<Project> ListMyProjects(Manager mgr) {
            return null;
        }

        [UserAction("My Development Tasks", new UserTypes[] { UserTypes.Developer })]
        public List<DevTask> ListMyDevTasks(Developer dev) {
            return null;
        }

        [UserAction("My Test Tasks", new UserTypes[] { UserTypes.Developer })]
        public List<TestTask> ListMyTestTasks(Developer dev) {
            return null;
        }

        public void DoAction(string className, string methodName, List<object> parameters) {
            ReflectionInfo ri = new ReflectionInfo();
            Type cls=ri.Classes.First(x=>x.Name==className);
            object[] prm = null;
            if ((parameters != null) && (parameters.Count != 0)) { prm = parameters.ToArray(); }
            object result=cls.GetMethod(methodName,BindingFlags.Public|BindingFlags.Static).Invoke(null, prm);
            switch (className) { // RRR 
                case "User": {
                    User user =(User)result;
                        vUsers.TryAdd(user.UserId,user);
                    }
                break;
                default:
                break;
            }

        }


        public List<object> GetCollectionByClassName(string className) {
            List<object> list = null;
            //object obj=this.GetType().GetMethod(className).Invoke(this, null);
            switch (className) { // RRR
                case "ListProjects":
                case "List<Project>": { list = ListProjects().Cast<object>().ToList(); }
                break;
                case "ListUsers":
                case "List<User>": { list = ListUsers().Cast<object>().ToList(); }
                break;
                default:
                break;
            }
            return list;
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
