using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole {
    interface IAuthenticator {
        bool AuthenticateUser(string userName);
    }
}
