using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public interface IAuthenticator {
        User AuthenticateUserByPassword(string userName, string userPassword);
        //bool AuthenticateUser(User user);
        UserSession AuthenticateUser();
    }
}
