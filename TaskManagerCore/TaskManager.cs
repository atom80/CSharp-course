using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskManagerCore {

    public class TaskManager {
        private TMTimer vTimer;
        public TMTimer Timer { get { return vTimer; } }
        private List<User> vUsers = new List<User>();
        UserSession vMainUserSession;

        private List<UserSession> vUserSessions;
        public List<UserSession> UserSessions { get { return vUserSessions; } }

        private IStorage vStorage;
        public IStorage Storage { get { return vStorage; } }

        private IAuthenticator vAuthenticator;

        public event SessionChangedHandler SessionChangedEvent;

        public void SessionChangedHandler(UserSession session, SessionChangeType change) {
            if (SessionChangedEvent != null) {
                SessionChangedEvent(session, change);
            }
        }

        public void LogonUser() {
            vMainUserSession = vAuthenticator.AuthenticateUser();
            vMainUserSession.SessionChangedEvent += SessionChangedHandler;
            vUserSessions.Add(vMainUserSession);
        }

        public void LogonUser(int userCount) {
            UserSession bgUser = null;
            string bgUserName;

            for (int i = 0; i < userCount; i++) {
                bgUserName = string.Format("BackgroundUser{0}", i);
                bgUser = new UserSession(null, UserSessionTypes.Automatic, TaskManagerCore.User.Factory(bgUserName, vStorage));
                vUserSessions.Add(bgUser);
                bgUser.SessionChangedEvent += SessionChangedHandler;
            }
        }

        public void LogoffUser() {
            vMainUserSession.CancellationTokenSource.Cancel(false);
            Task.WaitAll(vMainUserSession.ActionHandler);
            vUserSessions.Remove(vMainUserSession);
            if (SessionChangedEvent != null) {
                SessionChangedEvent(vMainUserSession, SessionChangeType.Stopped);
            }
            vMainUserSession = null;
            Thread.Sleep(5000);
        }

        public string[] Users {
            get {
                string[] userList = new string[vUsers.Count];
                for (int i = 0; i < vUsers.Count; i++) {
                    userList[i] = vUsers[i].ToString(); // RRR
                }
                return userList;
            }
        }

        public TaskManager(IStorage storage, IAuthenticator auth) {
            vTimer = new TMTimer(this);
            vStorage = storage;
            vAuthenticator = auth;
            vUserSessions = new List<UserSession>();
            //vUsers.Load();
        }

        public void Run() {
            //vTimer.TimerInterval = 500;
            //vTimer.Start();
            //Thread.Sleep(5000);
            //vTimer.Stop();
        }

        public void Shutdown() {
            List<Task> taskList = new List<Task>();
            foreach (UserSession session in vUserSessions) {
                session.CancellationTokenSource.Cancel(true);
                taskList.Add(session.ActionHandler);
            }
            Task.WaitAll(taskList.ToArray());
            Thread.Sleep(5000);
            //Task.WhenAll(taskList.ToArray());
            //Task taskWait=Task.Run(()=>Task.WaitAll(taskList.ToArray()));
            //await Task.WaitAll(taskList.ToArray());
            //await taskWait;
        }
    }
}
