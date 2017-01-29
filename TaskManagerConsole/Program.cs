using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore;

namespace TaskManagerConsole {
    class Program {
        private static void OnTmTimer(object sender, TMTimerEventArgs e) {
            //Console.WriteLine("{0}", ((TaskManager)sender).ToString());
            Console.WriteLine("{0}", e.TickCount);
        }

        static void Main(string[] args) {
            TaskManager vTaskManager = new TaskManager(new Storage(), new AuthConsole());
            Console.Title = "TaskManager v.0.1";
            Console.WriteLine("TaskManager v.0.1");
            bool isLogged=false;
            do {
                try {
                    isLogged = vTaskManager.LogonUser();
                } catch (Exception e) {
                    isLogged = false;
                    Console.WriteLine("\n"+e.Message);
                }

            } while (!isLogged);
            
            //vTaskManager.Timer.TMOnTimer+= OnTmTimer;
            //vTaskManager.Run();
            Console.Write("Done");
            Console.ReadLine();
        }
    }
}
