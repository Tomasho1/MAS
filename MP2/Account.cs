using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MP2
{
    public class Account
    {
        private static int LastAccountId = 0;
        private int accountId;
        public int AccountId
        {
            get
            {
                return accountId;
            }
            set
            {
                accountId = value;
            }
        }
        private string nickname;
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
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

        private string country;
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        private MailAddress email;
        public MailAddress Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        private SortedDictionary<String, Service> servicesQualif = new SortedDictionary<String, Service>();

        public Account(string nickname, DateTime creationDate, string country, MailAddress email) 
        {
            LastAccountId++;
            this.AccountId = LastAccountId;
            this.Nickname = nickname;
            this.CreationDate = creationDate;
            this.Country = country;
            this.Email = email;
        }


        public void AddServiceQualif(Service service)
        {
            if (!servicesQualif.ContainsKey(service.Name))
            {
                servicesQualif.Add(service.Name, service);

                service.AddAccount(this);
            }
        }

        public Service FindServiceQualif(String name)
        {
            if (!servicesQualif.ContainsKey(name)) {
                throw new Exception($"Service {name} not found");
            }

            Service service; 
            servicesQualif.TryGetValue(name, out service);
            return service;

        }

        public override string ToString()
        {
            return $"Nickname: { this.Nickname}" +
            $"\nCreation date: {this.creationDate}" + 
            $"\nCountry: {this.Country}" +
            $"\nMail: {this.Email}" + "\n";
        }

    }
}
