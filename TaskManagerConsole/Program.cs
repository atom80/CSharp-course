using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerConsole {
    class Program {
        private static void OnTmTimer(object sender, TMTimerEventArgs e) {
            //Console.WriteLine("{0}", ((TaskManager)sender).ToString());
            Console.WriteLine("{0}", e.TickCount);
        }

        static void Main(string[] args) {
            TaskManager vTaskManager = new TaskManager();
            //Console.Write("Login: ");
            //string login = Console.ReadLine();
            //Console.Write("Password: ");
            //string password = Console.ReadLine();
            vTaskManager.Timer.TMOnTimer+= OnTmTimer;
            vTaskManager.Run();
            Console.Write("Done");
            Console.ReadLine();
        }
    }
}
