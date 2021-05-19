using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MP3.Dynamiczne
{
    public abstract class Account
    {
    
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
        public Account(string nickname, DateTime creationDate, string country, MailAddress email)
        {
            this.Nickname = nickname;
            this.CreationDate = creationDate;
            this.Country = country;
            this.Email = email;
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
