using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MP3.Dynamiczne
{
    public enum SubscriptionType { Silver, Gold, Diamond }

    public class AccountPremium : Account
    {
        private DateTime subscribedAt;
        public DateTime SubscribedAt
        {
            get
            {
                return subscribedAt;
            }
            set
            {
                subscribedAt = value;
            }
        }
        private String subscriptionType;
        public String SubscriptionType
        {
            get
            {
                return subscriptionType;
            }
            set
            {
                subscriptionType = value;
            }
        }
        public AccountPremium(string nickname, DateTime creationDate, string country, MailAddress email, DateTime subscribedAt, SubscriptionType subscriptionType) : base(nickname, creationDate, country, email)
        {
            if (DateTime.Compare(creationDate, subscribedAt) > 0)
            {
                throw new Exception("Incorrect dates");
            }
            this.SubscribedAt = subscribedAt;
            this.SubscriptionType = subscriptionType.ToString();
        }

        public AccountPremium(Account oldAccount, DateTime subscribedAt, SubscriptionType subscriptionType) : base(oldAccount.Nickname, oldAccount.CreationDate, oldAccount.Country, oldAccount.Email)
        {
            if (DateTime.Compare(oldAccount.CreationDate, subscribedAt) > 0)
            {
                throw new Exception("Incorrect dates");
            }
            this.SubscribedAt = subscribedAt;
            this.SubscriptionType = subscriptionType.ToString();
        }

        public override string ToString()
        {
            return "\nAccount premium\n"
                + base.ToString() +
                 $"Subscription type: {this.SubscriptionType} " +
                 $"\nSubscribed at: {this.SubscribedAt}";
        }
    }
}
