using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskManagerConsole {
    public class TMTimerEventArgs : EventArgs {
        public decimal TickCount { get; set; }
    }

    public class TMTimer {
        public delegate void TMOnTimerhandler(object sender, TMTimerEventArgs e);
        public event TMOnTimerhandler TMOnTimer;
        private Timer vTimer;
        private decimal vTickCount = 0;
        public decimal TickCount { get { return vTickCount; } }
        private int vTimerInterval = 1000; // default - 1 sec
        public int TimerInterval { get { return vTimerInterval; } set { vTimerInterval = value; } }
        public TMTimer(object obj) {
            vTimer = new Timer(OnTimer, obj, System.Threading.Timeout.Infinite, vTimerInterval);
        }

        public void Start() {
            vTimer.Change(0, vTimerInterval);
        }

        public void Stop() {
            vTimer.Change(System.Threading.Timeout.Infinite, vTimerInterval);
            vTickCount = 0;
        }

        private void OnTimer(object obj) {
            vTickCount++;
            if (TMOnTimer != null) {
                TMOnTimer(obj, new TMTimerEventArgs { TickCount = vTickCount });
            }
        }
    }
}
