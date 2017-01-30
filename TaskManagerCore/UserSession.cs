using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskManagerCore {
    public enum UserSessionTypes {
        InteractiveGUI = 0,
        InteractiveConsole = 1,
        Automatic = 2
    }

    public enum SessionChangeType {
        Started = 0,
        Stopped = 1
    }

    public delegate void SessionChangedHandler(UserSession session, SessionChangeType change);
    public class UserSession {
        
        public event SessionChangedHandler SessionChangedEvent;

        private Guid vSessionId = Guid.NewGuid();
        public Guid SessionId { get { return vSessionId; } }
        private Task vActionHandler;
        public Task ActionHandler { get { return vActionHandler; } }
        public CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        private readonly UserSessionTypes vSessionType;
        public UserSessionTypes SessionType { get { return vSessionType; } }

        private readonly DateTime vSessionStartDateTime;
        public DateTime SessionStartDateTime { get { return vSessionStartDateTime; } }

        private DateTime vSessionStopDatetime;
        public DateTime SessionStopDateTime { get { return vSessionStopDatetime; }set{vSessionStopDatetime=value;} }

        private IAuthenticator vSessionAuthenticator;

        private User vSessionUser;
        public User SessionUser { get { return vSessionUser; } }

        public void DoHandleActions(object sender) {
            UserSession userSession = sender as UserSession;
            if (SessionChangedEvent != null) {
                SessionChangedEvent(userSession,SessionChangeType.Started);
            }
            int counter = 0;
            while (!userSession.CancellationTokenSource.IsCancellationRequested) {
                Console.Write("{0}",Task.CurrentId);
                Thread.Sleep(2000); // do some heavy work
                if (counter++ > 10) { break; }
            }
            Thread.Sleep(2000);
            userSession.SessionStopDateTime=DateTime.Now;
            if (SessionChangedEvent != null) {
                SessionChangedEvent(userSession,SessionChangeType.Stopped);
            }
        }

        public UserSession(IAuthenticator sessionAuth, UserSessionTypes sessionType, User sessionUser) {
            vSessionType = sessionType;
            vSessionAuthenticator = sessionAuth;
            vSessionUser = sessionUser;
            //vSessionAuthenticator.AuthenticateUser(sessionUser);
            vSessionStartDateTime = DateTime.Now;

            vActionHandler = new Task(DoHandleActions, (object)this, CancellationTokenSource.Token, TaskCreationOptions.AttachedToParent | TaskCreationOptions.PreferFairness);
            
            //vActionHandler=Task.Factory.StartNew(()=>DoHandleActions(this),vCancellationTokenSource.Token);
            vActionHandler.Start();
            //Thread.Sleep(10000);
            //CancellationTokenSource.Cancel(false);

            //Console.WriteLine("UserSession done!");
        }

    }
}
