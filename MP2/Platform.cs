using System;
using System.Collections.Generic;
using System.Text;

namespace MP2
{
    public class Platform
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

        //private DateTime releaseDate;
        //public DateTime ReleaseDate
        //{
        //    get
        //    {
        //        return releaseDate;
        //    }
        //    set
        //    {
        //        releaseDate = value;
        //    }
        //}

        private List<GamePlatform> gamePlatforms = new List<GamePlatform>();


        public Platform(string name, Developer developer)
        {
            this.Name = name;
            this.Developer = developer;
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
            gamePlatform.Platform = null;
        }

        public void ShowAvailableGames()
        {
            List<String> gamesPlatforms = new List<String>();

            foreach (GamePlatform gamePlatform in gamePlatforms)
            {
                gamesPlatforms.Add(gamePlatform.Game.Name);
            }
            Console.WriteLine($"Games available on {this.Name}: ");
            gamesPlatforms.ForEach(Console.WriteLine);
            Console.WriteLine();

        }
    }
}
