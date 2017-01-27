using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole {
    [UserAction("Tasks")]
    public abstract class Task {
        [UserAction("Assign task")]
        public void Assign() { }

        [UserAction("Close task")]
        public void Close() { }

        [UserAction("Reject task")]
        public void Reject() { }
    }
}
