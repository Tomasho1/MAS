using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Atrybutu
{
    class User
    {
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        private string password
            ;
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
    }
}
