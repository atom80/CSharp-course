using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace TaskManagerCore {

    public class TaskManager {
        private TMTimer vTimer;
        public TMTimer Timer { get { return vTimer; } }
        private UserSession vMainUserSession;
        public UserSession MainUserSession { get { return vMainUserSession; } }

        private bool vIsInShutdown = false;

        private List<UserSession> vUserSessions;
        public List<UserSession> UserSessions { get { return vUserSessions; } }

        private IStorage vStorage;
        public IStorage Storage { get { return vStorage; } }

        private IAuthenticator vAuthenticator;

        public event SessionChangedHandler SessionChangedEvent;

        public void SessionChangedHandler(UserSession session, SessionChangeArgs e) {
            SessionChangeType changeType = e.ChangeType;
            if ((session.SessionType != UserSessionTypes.Automatic) && (changeType != SessionChangeType.Started)) {
                vMainUserSession = null;
                changeType = SessionChangeType.MainSessionStopped;
            }
            if (changeType != SessionChangeType.Started) {
                lock (this) {
                    vUserSessions.Remove(session);
                }
            }
            if ((SessionChangedEvent != null) /*&& (!vIsInShutdown)*/) { // RRR
                SessionChangedEvent(session, e);
            }
        }

        public bool LogonUser() {
            vMainUserSession = vAuthenticator.AuthenticateUser();
            vMainUserSession.SessionChangedEvent += SessionChangedHandler;
            lock (this) {
                vUserSessions.Add(vMainUserSession);
            }
            vMainUserSession.Start();
            return true;
        }

        public void LogonBackgroundUsers(int userCount) {
            UserSession bgUserSession = null;
            User bgUser = null;
            //            string bgUserName;
            for (int i = 0; i < userCount; i++) {
                //bgUserName = string.Format("BackgroundUser{0}", i);
                //bgUser=vAuthenticator.AuthenticateUserByPassword(bgUserName,bgUserName); // cheat
                bgUser = vStorage.Users[i];
                if (bgUser == vMainUserSession.SessionUser) { continue; }
                bgUserSession = new UserSession(null, UserSessionTypes.Automatic, bgUser);
                lock (this) { vUserSessions.Add(bgUserSession); }
                bgUserSession.SessionChangedEvent += SessionChangedHandler;
                bgUserSession.Start();
            }
        }

        public void LogoffUser() {
            vMainUserSession.SessionCancellationTokenSource.Cancel(false);
            Task.WaitAll(vMainUserSession.ActionHandler);
            lock (this) {
                vUserSessions.Remove(vMainUserSession);
            }
            if (SessionChangedEvent != null) {
                SessionChangedEvent(vMainUserSession, new SessionChangeArgs { ChangeType = SessionChangeType.MainSessionStopped });
            }
            vMainUserSession = null;
            Thread.Sleep(2000);
        }

        public TaskManager(IStorage storage, IAuthenticator auth) {
            vTimer = new TMTimer(this);
            vStorage = storage;
            vAuthenticator = auth;
            vUserSessions = new List<UserSession>();
            vStorage.Load();
            //vUsers.Load();
        }

        public void Run() {
            //vTimer.TimerInterval = 500;
            //vTimer.Start();
            //Thread.Sleep(5000);
            //vTimer.Stop();
        }

        public void Shutdown() {
            vIsInShutdown = true;
            List<Task> taskList = new List<Task>();
            foreach (UserSession session in vUserSessions) {
                session.SessionCancellationTokenSource.Cancel(true);
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
