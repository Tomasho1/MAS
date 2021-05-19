using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MP3.Dynamiczne
{
    public class AccountNormal : Account
    {
        public static int maxDownloadsPerDay = 10;
        public AccountNormal(string nickname, DateTime creationDate, string country, MailAddress email) : base(nickname, creationDate, country, email)
        {

        }

        public AccountNormal(Account oldAccount) : 
            base(oldAccount.Nickname, oldAccount.CreationDate, oldAccount.Country, oldAccount.Email)
        {

        }
        public override string ToString()
        {
            return "\nAccount normal\n" + base.ToString();
        }
    }
}
