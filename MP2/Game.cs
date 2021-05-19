using System;
using System.Collections.Generic;
using System.Text;

namespace MP2
{
    public class Game
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

        private string genre;
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
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

        private Developer developer;

        public Developer Developer
        {
            get
            {
                return developer;
            }
            set
            {
                developer = value; 
            }
        }

        private List<GamePlatform> gamePlatforms = new List<GamePlatform>();

        public Game(string name, string genre, DateTime releaseDate)
  
        {
            this.Name = name;
            this.Genre = genre;
            this.ReleaseDate = releaseDate;
        }

        public void SetDeveloper(Developer developer)
        {
            if (this.developer != null)
            {
                developer.DeleteGame(this);
            }
            this.developer = developer;
            developer.AddGame(this);
        }

        public String GetDeveloperName()
        {
            if (this.Developer == null)
            {
                return "No information";
            }
            else return this.Developer.Name;
        }

        public void AddGamePlatform(GamePlatform gamePlatform)
        {
            if (!gamePlatforms.Contains(gamePlatform))
            {
                gamePlatforms.Add(gamePlatform);
            }
        }

        public void DeleteGamePlatform(GamePlatform gamePlatform)
        {
            if (!gamePlatforms.Contains(gamePlatform))
            {
                throw new Exception("Association not found");
            }
            gamePlatforms.Remove(gamePlatform);
            gamePlatform.Game = null;
        }


        public void ShowAvailablePlatforms()
        {
            List<String> gamesPlatforms = new List<String>();

            foreach (GamePlatform gamePlatform in gamePlatforms)
            {
                gamesPlatforms.Add(gamePlatform.Platform.Name);
            }
            Console.WriteLine($"{this.name} is available on: ");
            gamesPlatforms.ForEach(Console.WriteLine);
            Console.WriteLine();
        }
    }
}
