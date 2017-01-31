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
        Stopped = 1,
        MainSessionStopped = 2
    }

    public class SessionChangeArgs : EventArgs {
        public SessionChangeType ChangeType { get; set; }
    }

    public delegate void SessionChangedHandler(UserSession session, SessionChangeArgs e);
    public class UserSession : IDisposable {
        private bool vIsDisposed = false;

        public event SessionChangedHandler SessionChangedEvent;

        private Guid vSessionId = Guid.NewGuid();
        public Guid SessionId { get { return vSessionId; } }
        private Task vActionHandler;
        public Task ActionHandler { get { return vActionHandler; } }
        public CancellationTokenSource SessionCancellationTokenSource = new CancellationTokenSource();
        private readonly UserSessionTypes vSessionType;
        public UserSessionTypes SessionType { get { return vSessionType; } }

        private DateTime vSessionStartDateTime;
        public DateTime SessionStartDateTime { get { return vSessionStartDateTime; } }

        private DateTime vSessionStopDatetime;
        public DateTime SessionStopDateTime { get { return vSessionStopDatetime; } set { vSessionStopDatetime = value; } }

        private IAuthenticator vSessionAuthenticator;

        private User vSessionUser;
        public User SessionUser { get { return vSessionUser; } }

        public void DoHandleActions(object sender) {
            UserSession userSession = sender as UserSession;
            if (SessionChangedEvent != null) {
                SessionChangedEvent(userSession, new SessionChangeArgs { ChangeType = SessionChangeType.Started });
            }
            int counter = 0;
            while (!userSession.SessionCancellationTokenSource.IsCancellationRequested) {
                Console.Write("{0}", Task.CurrentId);
                Thread.Sleep(2000); // do some heavy work
                if (userSession.SessionType == UserSessionTypes.Automatic) {
                    if (counter++ > 10) { break; }
                }
            }
            Thread.Sleep(2000);
            userSession.SessionStopDateTime = DateTime.Now;
            if (SessionChangedEvent != null) {
                SessionChangedEvent(userSession, new SessionChangeArgs { ChangeType = SessionChangeType.Stopped });
            }
        }

        public void Start() {
            vSessionStartDateTime = DateTime.Now;
            vActionHandler.Start();
        }

        public UserSession(IAuthenticator sessionAuth, UserSessionTypes sessionType, User sessionUser) {
            vSessionType = sessionType;
            vSessionAuthenticator = sessionAuth;
            vSessionUser = sessionUser;
            //vSessionAuthenticator.AuthenticateUser(sessionUser);

            vActionHandler = new Task(DoHandleActions, (object)this, SessionCancellationTokenSource.Token, TaskCreationOptions.AttachedToParent | TaskCreationOptions.PreferFairness);

            //vActionHandler=Task.Factory.StartNew(()=>DoHandleActions(this),vCancellationTokenSource.Token);
            //vActionHandler.Start();
            //Thread.Sleep(10000);
            //CancellationTokenSource.Cancel(false);

            //Console.WriteLine("UserSession done!");
        }

        /// <summary>
        /// https://msdn.microsoft.com/ru-ru/library/system.idisposable(v=vs.110).aspx
        /// </summary>
        public void Dispose() {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        /// <summary>
        /// https://msdn.microsoft.com/ru-ru/library/system.idisposable(v=vs.110).aspx
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            // Check to see if Dispose has already been called.
            if (!this.vIsDisposed) {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing) {
                    // Dispose managed resources.
                    vActionHandler.Dispose();
                    SessionCancellationTokenSource.Dispose();

                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                //CloseHandle(handle);
                //handle = IntPtr.Zero;

                // Note disposing has been done.
                vIsDisposed = true;

            }
        }
    }
}

