using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore;

namespace TaskManagerWinForms {
    class AuthForms : Authenticator {
        Form1 vForm;
        public AuthForms(Form1 form, IStorage storage)
            : base(storage) {
            vForm = form;
        }

        public override UserSession AuthenticateUser() {
            UserSession session = null;
            string[] userCreds = vForm.GetCredentials();
            string userName = userCreds[0];
            string userPassword = userCreds[1];
            User user = User.Factory(userName, this.Storage);
            if (AuthenticateUser(userName, userPassword)) {
                session = new UserSession(this, UserSessionTypes.InteractiveGUI, user);
            }
            return session;
        }
    }

}
