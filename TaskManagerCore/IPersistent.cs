using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    interface IPersistent {
        IStorage Storage{get;}
        void Save();
        void Load();
    }
}
