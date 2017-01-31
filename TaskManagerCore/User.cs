using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCore {
    public enum UserTypes {
        Unknown = -1,
        Administrator = 0,
        Manager = 1,
        Developer = 2
    }

    public enum UserStates {
        Locked = 0,
        Unlocked = 1
    }

    [UserAction("User Accounts",new UserTypes[]{UserTypes.Administrator})]
    public abstract class User {
        private string vUserName = "";
        public string UserName { get { return vUserName; } }
        public string UserFullName { get { return string.Format("[{0}] {1} ({2})", vUserAcronym, vUserName, vUserType); } }

        private string vUserAcronym = "";
        public string UserAcronym { get { return vUserAcronym; } }

        private UserTypes vUserType = UserTypes.Unknown;
        public UserTypes UserType { get { return vUserType; } }

        private UserStates vUserState = UserStates.Locked;
        public UserStates UserState { get { return vUserState; } }

        [UserAction("Create user account", new UserTypes[] { UserTypes.Administrator })]
        //[ActionGuid("4F34259A-9CE2-42D2-A4F5-B086AF9A93F2")]
        public void Create() { }

        [UserAction("Delete user account", new UserTypes[] { UserTypes.Administrator })]
        //[ActionGuid("59197389-95D0-4B46-B77C-93635C153C06")]
        public void Delete() { }

        [UserAction("Lock user account", new UserTypes[] { UserTypes.Administrator })]
        public void Lock() { }

        [UserAction("Unlock user account", new UserTypes[] { UserTypes.Administrator })]
        public void Unlock() { }

        public static User[] GetUsers() {
            User[] users = null;

            return users;
        }

        public User(string userName, UserTypes userType, UserStates userState) {
            vUserName = userName;
            vUserType = userType;
            vUserState = userState;
            if (userName == "Administrator") { vUserAcronym = "ADMN"; } else {
                string[] nameParts = userName.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                vUserAcronym = "";
                for (int i = 0; i < 2; i++) {
                    vUserAcronym = vUserAcronym + nameParts[i].Substring(0, 1);
                    vUserAcronym = vUserAcronym + nameParts[i].Substring(nameParts[i].Length - 1, 1);
                }
                vUserAcronym = vUserAcronym.ToUpper();
            }
        }

        public static User GenerateRandomUser() {
            // http://fantasynamegenerators.com
            string[] userNames = new string[] { "Wallace Harris", "Tommy Johns", "Lester Huffman", "Dean Gibson", "Theodore Rogers", 
                "Edwin Garner", "Carlos Beard", "Sebastian Washington", "Marco Witt", "Matthew Hampton", "Homer Cherry", "Oliver Leonard",
                "Howard Noble", "Dean Beck", "Gregory Norman", "Austin Saunders", "Joshua Garrett", "Eduardo Bradley", "Darius Perry",
                "Michael Bell", "Bobby Farley", "Delbert Berg", "Ronnie Morgan", "Eric Shepherd", "Lewis Stark", "Dylan Dixon", 
                "Arthur Matthews", "Shane Murray", "Erick Albert", "Alma Roberts", "Fannie Simpson", "Gladys Long", "Marguerite Blevins",
                "Charlene Hendricks", "Patricia Blake", "Laurie Miller", "Melissa Nixon", "Maria Peck", "Brittney Snider", "Geneva Sawyer",
                "Jeannette Mosley", "Carole Burgess", "Pamela O'Neal", "Cheryl Cleveland", "Laura Powell", "Cassie Tyler", 
                "Kristin Webster", "Laura McIntosh", "Arianna Abbott", "Ann McGee", "Irma Bass", "Marianne Morris", "Anne Lawson", 
                "Carol Farmer", "Virginia Baldwin", "Kristina Riley", "Cassandra Small", "Jocelyn Boone", "Krystal Weeks", "Prum Rath", 
                "Thy Sopat", "Su Chann", "Ek Sophea", "Ang Bourey", "Nourn Visothirith", "Iem Nimith", "Sat Munny", "Om Vireakboth", 
                "Khat Vannak", "Seang Chanvatey", "Nhek Sros", "On Bora", "Chey Chanthou", "Sor Rith", "Neak Piseth", "Yous Rathana", 
                "Om Sovanna", "Prum Rath", "Muoy Sothiya", "Iam Kravann", "Moul Bourey", "Toch Vireakboth", "Tep Sopat", "Kim Serey", 
                "Nourn Chhaya", "Lim Mao", "Sieng Sopath", "Jin Visothirith", "Hoy Vichet", "Bun Kolab", "Hun Sokhanya", "Iv Savady", 
                "San Kalianne", "Chhan Sreymom", "Hu Roumduol", "Saluk Kannareth", "Pen Kalliyan", "Chhorn Rottana", "Sok Pheakdei",
                "Sorm Chamroeun", "Mean Chivy", "Mon Punthea", "Sen Chhaya", "Mok Champei", "Yun Putrea", "Chhay Serey", "Chim Dara", 
                "Tang Jorani", "Khai Chakriya", "Saihajdeep Kaushal", "Satprakash Teerwal", "Varunpal Kehal", "Akaltat Tung", "Vikrampal Binar", 
                "Yashbir Jajra", "Sadhnah Ahuja", "Arunvir Jewlia", "Mukhtyar Dabas", "Baksheesh Khichad", "Zareenapal Jhutti", "Sagar Karwasra", 
                "Indermohan Rahar", "Nehchaljot Sahni", "Satyajeet Sarai", "Indrakanta Rhind-Tutt", "Teknam Khaira", "Achraj Dahiya", 
                "Trilochan Munjal", "Sarnagat Janjua", "Nimmarata Faujdar", "Harneez Lehga", "Yuvrani Cheema", "Aboil Goyat", 
                "Amritpreet Bhalothia", "Kanwalroop Aulakh", "Kamalla Mungut", "Humpreet Kang", "Meenakshi Seokhand", "Akalya Thathiala", 
                "Sijh Potaysir", "Prabhgiaan Inania", "Yaad Dhankhar", "Harsukh Dabra", "Kalapi Basram", "Armani Jakhar", "Rasnoor Brar", 
                "Prajna Smith", "Lakhshmi Saini", "Mahansukh Mohil", "Pavit Prakash", "Kritanta Loliyekar", "Mahakala Modi", "Jahnu Sekhon",
                "Abhimanyu Mahajan", "Chandra Sant", "Jatin Chad", "Gautam Agrawal", "Arav Apte", "Saka Lalla", "Parvani Devgan", "Sunila Kade", 
                "Garuda Kamei", "Ranee Lalla", "Ushas Mall", "Anushka Garg", "Durga Pai", "Subha Tata", "Gargi Mulge", "Shyla Munshi" };
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            UserTypes userType = (UserTypes)rnd.Next(0, 3);
            string userName = userNames[rnd.Next(0, userNames.Length)];
            return User.Factory(userName, userType);
        }

        public static User Factory(string userName, UserTypes userType) {
            //User user = storage.GetUserByName(userName);
            //switch (user.UserType) {
            //User user = null;
            //UserTypes userType = UserTypes.Developer;
            User user = null;
            switch (userType) {
                case UserTypes.Administrator: { user = new Admin(userName); }
                break;
                case UserTypes.Developer: { user = new Developer(userName); }
                break;
                case UserTypes.Manager: { user = new Manager(userName); }
                break;
                default:
                break;
            }
            return user;
        }

    }
}
