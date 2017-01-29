using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public enum UserTypes {
        Unknown = -1,
        Administrator = 0,
        Manager = 1,
        Developer = 2
    }

    public enum UserStates {
        Locked = 0,
        Unlocked = 1
    }

    [UserAction("Accounts")]
    public abstract class User {
        private string vUserName = "";
        public string UserName { get { return vUserName; } }

        private UserTypes vUserType = UserTypes.Unknown;
        public UserTypes UserType { get { return vUserType; } }

        private UserStates vUserState = UserStates.Locked;
        public UserStates UserState { get { return vUserState; } }

        [UserAction("Create user account")]
        public void Create() { }

        [UserAction("Delete user account")]
        public void Delete() { }

        [UserAction("Lock user account")]
        public void Lock() { }

        [UserAction("Unlock user account")]
        public void Unlock() { }

        public static User[] GetUsers() {
            User[] users=null;

            return users;
        }

        public User(string userName,UserTypes userType,UserStates userState) {
            vUserName = userName;
            vUserType = userType;
            vUserState = userState;
        }

        public static User UserFactory(string userName, IStorage storage) {
            User user = storage.GetUser(userName);
            switch (user.UserType) {
                case UserTypes.Administrator: { user = new Admin(userName); }
                break;
                case UserTypes.Developer: { user = new Developer(userName); }
                break;
                case UserTypes.Manager: { user = new Manager(userName); }
                break;
                default:
                break;
            }
            return user;
        }

    }
}
