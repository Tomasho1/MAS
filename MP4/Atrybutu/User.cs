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

        private DateTime registrationDate;
        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate;
            }
            set
            {
                registrationDate = value;
            }
        }

        public User(String username, String password, DateTime registrationDate)
        {
            this.Username = username;
            this.Password = password;
            this.RegistrationDate = registrationDate;
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
