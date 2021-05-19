using System;
using System.Collections.Generic;
using System.Text;

namespace MP1
{
    class PlayerRanking
    {
        private int playerId;
        public int PlayerId
        {
            get
            {
                return playerId;
            }
            set
            {
                playerId = value;
            }
        }
        private String firstname;
        public String Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        private String lastname;
        public String Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        private int rating;
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
            }
        }

        public PlayerRanking(int playerId, String firstname, String lastname, int rating)
        {
            this.PlayerId = playerId;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Rating = rating;
        }   
    }
}
