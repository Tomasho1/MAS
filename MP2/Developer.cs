using System;
using System.Collections.Generic;
using System.Text;

namespace MP2
{
    public class Developer
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

        private DateTime foundationDate;
        public DateTime FoundationDate
        {
            get
            {
                return foundationDate;
            }
            set
            {
                foundationDate = value;
            }
        }
        private List<Game> games = new List<Game>();
        private List<Studio> studios = new List<Studio>();
        private static HashSet<Studio> allStudios = new HashSet<Studio>();

        public Developer(string name, string country, DateTime foundationDate)
        {
            this.Name = name;
            this.Country = country;
            this.FoundationDate = foundationDate;
        }

        public void AddGame(Game game)
        {
            if (!games.Contains(game))
            {
                games.Add(game);
                game.SetDeveloper(this);
            }
        }

        public void DeleteGame(Game game)
        {
            if (!games.Contains(game))
            {
                throw new Exception("Game not found");
            }
            games.Remove(game);
            game.Developer = null;
        }

        public void DeveloperGames()
        {
            List<String> gamesNames = new List<String>();

            foreach (Game game in games)
            {
                gamesNames.Add(game.Name);
            }

            Console.WriteLine($"Games made by {this.name}:");
            gamesNames.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public void AddStudio(Studio studio)
        {
            if (!studios.Contains(studio))
            {
                if (allStudios.Contains(studio))
                {
                    throw new Exception("Studio is owned by another developer");

                }
                studios.Add(studio);
                allStudios.Add(studio);
            }
        }

        public void Remove()
        {
            allStudios.ExceptWith(studios);
            studios.Clear();
        }

        public void ShowStudios()
        {
            if (studios.Count == 0)
            {
                Console.WriteLine($"{this.name} does not own any studio" + "\n");
            }
            else
            {
                Console.WriteLine($"Studios owned by {this.name}:");
                studios.ForEach(Console.WriteLine);
            }
        }
        public override string ToString()
        {
            return $"Name: { this.Name}" +
            $"\nCountry: {this.Country}" +
            $"\nFoundation date: {this.FoundationDate}" + "\n";
        }

    }
}


