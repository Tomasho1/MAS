using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Subset
{
    class Player
    {

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
        private String nationality;
        public String Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                nationality = value;
            }
        }
        private DateTime birthdate;
        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
            }
        }

        private bool isCaptain;
        public bool IsCaptain
        {
            get
            {
                return isCaptain;
            }
            set
            {
                isCaptain = value;
            }
        }

        private Team team;

        public Team Team
        {
            get
            {
                return team;
            }
            set
            {
                team = value;
            }
        }

        public Player(String firstname, String lastname, String nationality, DateTime birthdate)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Nationality = nationality;
            this.Birthdate = birthdate;
        }

        public void SetTeam(Team team)
        {
            if (this.Team != null)
            {
                team.ReleasePlayer(this);
            }
            this.Team = team;
            team.SignPlayer(this);
        }

        public void MakeCaptain()
        {
            IsCaptain = true;
        }

        public void UnmakeCaptain()
        {
            IsCaptain = false;
        }
    }
}
