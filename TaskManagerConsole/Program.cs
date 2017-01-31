using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TaskManagerCore;

namespace TaskManagerConsole {
    class Program {
        private static void OnTmTimer(object sender, TMTimerEventArgs e) {
            //Console.WriteLine("{0}", ((TaskManager)sender).ToString());
            Console.WriteLine("{0}", e.TickCount);
        }

        public static void SessionChangeHandler(UserSession userSession, SessionChangeType change) {
            switch (change) {
                case SessionChangeType.Started: {
                    Console.WriteLine("\n[{0}] Session for user {1}({2}) has started", userSession.SessionStartDateTime,userSession.SessionUser.UserName, userSession.SessionUser.UserType);
                }
                break;
                case SessionChangeType.Stopped: {
                    Console.WriteLine("[{0}] Session for user {1}({2}) has ended", userSession.SessionStopDateTime, userSession.SessionUser.UserName, userSession.SessionUser.UserType);
                }
                break;
                default: { Console.WriteLine("[{0}] Unknown session change type for user {1}",DateTime.Now, userSession.SessionUser.UserName); }
                break;
            }
        }

        static void Main(string[] args) {
            IStorage storage = new Storage();
            TaskManager vTaskManager = new TaskManager(storage, new AuthConsole(storage));
            Console.Title = "TaskManager v.0.1";
            Console.WriteLine("TaskManager v.0.1\t(Administrator/Administrator)");
            vTaskManager.SessionChangedEvent += SessionChangeHandler;
            bool isLogged = false;
            do {
                try {
                    vTaskManager.LogonUser();
                    isLogged = true;
                } catch (Exception e) {
                    isLogged = false;
                    Console.WriteLine("\n" + e.Message);
                }
            } while (!isLogged);

            vTaskManager.LogonBackgroundUsers(5);

            Thread.Sleep(5000);
            vTaskManager.Shutdown();
            Console.Write("Done");
            Console.ReadLine();
        }
    }
}
