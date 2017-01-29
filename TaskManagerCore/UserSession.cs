using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public enum UserSessionTypes {
        InteractiveGUI = 0,
        InteractiveConsole=1,
        Automatic = 2
    }

    public class UserSession {
        private readonly UserSessionTypes vSessionType;
        public UserSessionTypes SessionType { get { return vSessionType; } }

        private readonly DateTime vSessionStartDateTime;
        public DateTime SessionStartDateTime { get { return vSessionStartDateTime; } }

        private IAuthenticator vSessionAuthenticator;

        private User vSessionUser;

        public UserSession(IAuthenticator sessionAuth, UserSessionTypes sessionType, User sessionUser) {
            vSessionType = sessionType;
            vSessionAuthenticator = sessionAuth;
            vSessionUser = sessionUser;
            //vSessionAuthenticator.AuthenticateUser(sessionUser);
            vSessionStartDateTime = DateTime.Now;
        }



    }
}
