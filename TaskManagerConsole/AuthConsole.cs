using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore;


namespace TaskManagerConsole {
    public class AuthConsole : Authenticator {
        public AuthConsole(IStorage storage) : base(storage) { }

        public override UserSession AuthenticateUser() {
            UserSession session = null;
            Console.Write("Login: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string userPassword = "";
            ConsoleKeyInfo cki;
            do {
                cki = Console.ReadKey(true);
                if (cki.Key != ConsoleKey.Enter) {
                    userPassword += cki.KeyChar;
                    Console.Write("*");
                }
            } while (cki.Key != ConsoleKey.Enter);

            User user = AuthenticateUserByPassword(userName, userPassword);
            session = new UserSession(this, UserSessionTypes.InteractiveConsole, user);
            return session;
        }


    }
}
