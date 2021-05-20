using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Atrybutu
{
    class User
    {
        private int usernameChangesLeft = 2;
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (usernameChangesLeft == 0)
                {
                    throw new Exception("You already changed your username once");
                }
                else
                {
                    username = value;
                    usernameChangesLeft--;
                }
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length < 8)
                {
                    throw new Exception("Password must be at least 8 characters long");
                }
                else password = value;
            }
        }

        private DateTime creationDate;
        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                creationDate = value;
            }
        }

        public User(String username, String password, DateTime creationDate)
        {
            this.Username = username;
            this.Password = password;
            this.CreationDate = creationDate;
        }

        public void ChangeUsername(String newUsername)
        {
            if (Username == newUsername)
            {
                throw new Exception("Usernames must be different");
            }
            Username = newUsername;
        }
    }
}
