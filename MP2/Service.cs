using System;
using System.Collections.Generic;
using System.Text;

namespace MP2
{
    public class Service
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }
            set
            {
                releaseDate = value;
            }
        }
        private List<Platform> platforms;
        public List<Platform> Platforms
        {
            get
            {
                return platforms;
            }
            set
            {
                platforms = value;
            }
        }

        private List<Account> accounts = new List<Account>();

        public Service(string name, DateTime releaseDate, List<Platform> platforms)
        {
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.Platforms = platforms;
        }

        public void AddAccount(Account account)
        {
            if (!accounts.Contains(account))
            {
                accounts.Add(account);
            }
        }

        public void DeleteAccount(Account account)
        {
            if (!accounts.Contains(account))
            {
                throw new Exception("Game not found");
            }
            accounts.Remove(account);
        }

        public void ShowAccounts()
        {
            Console.WriteLine($"Accounts registered in {this.name}:");
            this.accounts.ForEach(Console.WriteLine);
        }

        public override string ToString()
        {
            return $"Name: { this.Name}" +
            $"\nRelease date: {this.ReleaseDate}";
        }
    }
}
