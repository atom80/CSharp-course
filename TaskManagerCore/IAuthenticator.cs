using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public interface IAuthenticator {
        bool AuthenticateUser(string userName, string userPassword);
        bool AuthenticateUser(User user);
        UserSession AuthenticateUser(IStorage storage);
    }
}
