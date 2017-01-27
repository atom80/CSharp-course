using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole {
    public enum UserTypes {
        Unknown =-1,
        Administrator = 0,
        Manager = 1,
        Developer = 2
    }
    
    public enum UserState {
        Locked=0,
        Unlocked=1
    }
    
    [UserAction("Accounts")]
    public abstract class User {
        private string vName = "";
        public string Name { get { return vName; } }

        private UserTypes vUserType = UserTypes.Unknown;
        public UserTypes UserType { get { return vUserType; } }

        private UserState vUserState = UserState.Locked;
        public UserState UserState { get { return vUserState; } }

        [UserAction("Create user account")]
        public void Create() { }

        [UserAction("Delete user account")]
        public void Delete() { }

        [UserAction("Lock user account")]
        public void Lock() { }

        [UserAction("Unlock user account")]
        public void Unlock() { }

        public static User UserFactory

    }
}
