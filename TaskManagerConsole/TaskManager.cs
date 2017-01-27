﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskManagerConsole {

    public class TaskManager {
        private TMTimer vTimer;
        public TMTimer Timer { get { return vTimer; } }
        private List<User> vUsers = new List<User>();
        
        private IStorage vStorage;
        public IStorage Storage { get { return vStorage; } }

        private IAuthenticator vAuthenticator;

        public string[] Users {
            get {
                string[] userList = new string[vUsers.Count];
                for (int i = 0; i < vUsers.Count; i++) {
                    userList[i] = vUsers[i].ToString(); // RRR
                }
                return userList;
            }
        }


        public TaskManager(IStorage storage, IAuthenticator auth) {
            vTimer = new TMTimer(this);
            vStorage = storage;
            vAuthenticator = auth;
            //vUsers.Load();
        }

        public void Run() {
            //vTimer.TimerInterval = 500;
            //vTimer.Start();
            //Thread.Sleep(5000);
            //vTimer.Stop();
        }
    }
}
