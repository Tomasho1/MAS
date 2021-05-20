using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Subset
{
    class Team
    {
        private String name;
        public String Name
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
        private String country;
        public String Country
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

        private int foundatedIn;
        public int FoundatedIn
        {
            get
            {
                return foundatedIn;
            }
            set
            {
                foundatedIn = value;
            }
        }

        private Player captain;
        public Player Captain
        {
            get
            {
                return captain;
            }
            set
            {
                captain = value;
            }
        }

        private List<Player> players = new List<Player>();

        public Team(String name, String country, int foundatedIn)
        {
            this.Name = name;
            this.Country = country;
            this.FoundatedIn = foundatedIn;
        }

        public void SignPlayer(Player player)
        {
            if (!players.Contains(player))
            {
                players.Add(player);
                player.SetTeam(this);
            }
        }

        public void ReleasePlayer(Player player)
        {
            if (!players.Contains(player))
            {
                throw new Exception("No player found");
            }

            if (captain == player)
            {
                player.UnmakeCaptain();
                ReleaseCaptain();
            }
                players.Remove(player);
                player.Team = null;
        }

        public void SetCaptain(Player player)
        {
            if (player.Team != this)
            {
                throw new Exception("Player is not in this team");
            }

            else if (Captain == player)
            {
                throw new Exception("Player is already a captain of this team");
            }
            else
            {
                if (Captain != null)
                {
                    ReleaseCaptain();
                }
                Captain = player;
                player.MakeCaptain();
            }
        }

        public void ReleaseCaptain()
        {
            Captain.UnmakeCaptain();
            Captain = null;
        }

        public string GetCaptainInfo()
        {
            return $"{Captain.Firstname} {Captain.Lastname} is the captain of {Name}";
        }

    }
}
