using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    [Serializable]
    public class UserException:Exception {
          public UserException()
    {
    }

    public UserException(string message)
        : base("[OOPS]: "+message)
    {
    }

    public UserException(string message, Exception inner)
        : base("[OOPS]: "+message, inner)
    {
    }
    }
}
