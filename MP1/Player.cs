using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MP1
{

    [Serializable]
    public class Player
    {
        private static int LastPlayerId = 0;

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
        private int age;
        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                age = now.Year - this.Birthdate.Year;
                if (now < Birthdate.AddYears(age))
                {
                    age--;
                }
                return age;
            }
        }

        private Dictionary<string, int> ratings;
        public Dictionary<string, int> Ratings
        {
            get
            {
                return ratings;
            }
            set
            {
                ratings = value;
            }
        }
        private String title;
        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        private static List<Player> extent = new List<Player>();

        public Player(String firstname, String lastname, String nationality, DateTime birthdate, Dictionary<string, int> ratings, String title = "No title")
        {
            LastPlayerId++;
            this.PlayerId = LastPlayerId;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Nationality = nationality;
            this.Birthdate = birthdate;
            this.Ratings = ratings;
            this.Title = title;
            AddPlayer(this);
        }

        //Extent methods
        public static List<Player> GetExtent()
        {
            return extent;
        }
        public static void ShowExtent()
        {
            foreach (Player player in extent)
            {
                Console.WriteLine(player + "\n");
            }
        }
        public void AddPlayer(Player player)
        {
            extent.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            extent.Remove(player);
        }

        public static void SaveExtent()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Extent.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, extent);
            stream.Close();
        }

        public static void ReadExtent()
        {
            try
            {
                extent.Clear();
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Extent.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                extent = (List<Player>)formatter.Deserialize(stream);
                ShowExtent();
                stream.Close();
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
 
        //Overrided method
        public override string ToString()
        {
            return $"Player: {this.Firstname} {this.Lastname}" +
                $"\nNationality: {this.Nationality}\nAge: {this.Age}" +
                $"\nTitle: {this.Title}" +
                $"\nStandard rating: {this.Ratings.FirstOrDefault(x => x.Key == "Standard").Value}" +
                $"\nRapid rating: {this.Ratings.FirstOrDefault(x => x.Key == "Rapid").Value}" +
                $"\nBlitz rating: {this.Ratings.FirstOrDefault(x => x.Key == "Blitz").Value}";
        }

        //Overloaded method
        //All 3 categories at the same time
        public string ShowPlayerPosition()
        {
            var standardRanking = new List<PlayerRanking>();
            var blitzRanking = new List<PlayerRanking>();
            var rapidRanking = new List<PlayerRanking>();
            foreach (Player player in extent)
            {
                var standardRating = player.Ratings.FirstOrDefault(x => x.Key == "Standard").Value;
                standardRanking.Add(new PlayerRanking(player.PlayerId, player.Firstname, player.Lastname, standardRating));

                var blitzRating = player.Ratings.FirstOrDefault(x => x.Key == "Blitz").Value;
                blitzRanking.Add(new PlayerRanking(player.PlayerId, player.Firstname, player.Lastname, blitzRating));

                var rapidRating = player.Ratings.FirstOrDefault(x => x.Key == "Rapid").Value;
                rapidRanking.Add(new PlayerRanking(player.PlayerId, player.Firstname, player.Lastname, rapidRating));
            }

            standardRanking = standardRanking.OrderByDescending(x => x.Rating).ToList();
            blitzRanking = blitzRanking.OrderByDescending(x => x.Rating).ToList();
            rapidRanking = rapidRanking.OrderByDescending(x => x.Rating).ToList();

            var standardRankingPosition = standardRanking.FindIndex(x => x.PlayerId == this.PlayerId) + 1;
            var blitzRankingPosition = blitzRanking.FindIndex(x => x.PlayerId == this.PlayerId) + 1;
            var rapidRankingPosition = rapidRanking.FindIndex(x => x.PlayerId == this.PlayerId) + 1;

            return $"{this.Firstname} {this.Lastname} rankings: " +
                $"\nStandard: Ranked #{standardRankingPosition} with {this.Ratings.FirstOrDefault(x => x.Key == "Standard").Value} rating" +
                $"\nBlitz: Ranked #{blitzRankingPosition} with {this.Ratings.FirstOrDefault(x => x.Key == "Blitz").Value} rating" +
                $"\nRapid: Ranked #{rapidRankingPosition} with {this.Ratings.FirstOrDefault(x => x.Key == "Rapid").Value} rating";
        }

        //One chosen category
        public string ShowPlayerPosition(string category)
        {
            if (extent.Count == 0)
            {
                throw new Exception("Extent is empty");
            }
            else
            { 
            var ranking = new List<PlayerRanking>();
            
                foreach (Player player in extent)
                {
                    var rating = player.Ratings.FirstOrDefault(x => x.Key == category).Value;
                    ranking.Add(new PlayerRanking(player.PlayerId, player.Firstname, player.Lastname, rating));
                }

                ranking = ranking.OrderByDescending(x => x.Rating).ToList();
                var rankingPosition = ranking.FindIndex(x => x.PlayerId == this.PlayerId) + 1;

                return $"{this.Firstname} {this.Lastname} is ranked #{rankingPosition} in {category}";
            }
        }

        //General rankings for category
        public static string ShowWorldRankings(string category)
        {
            if (extent.Count == 0)
            {
                throw new Exception("Extent is empty");
            }
            else
            {
                var ranking = new List<PlayerRanking>();
                foreach (Player player in extent)
                {
                    var rating = player.Ratings.FirstOrDefault(x => x.Key == category).Value;
                    ranking.Add(new PlayerRanking(player.PlayerId, player.Firstname, player.Lastname, rating));
                }

                ranking = ranking.OrderByDescending(x => x.Rating).ToList();
                StringBuilder stringRanking = new StringBuilder();
                stringRanking.Append($"World rankings for {category}:\n");

                foreach (PlayerRanking player in ranking)
                {
                    stringRanking.Append($"{ranking.FindIndex(x => x.PlayerId == player.PlayerId) + 1}. {player.Firstname} {player.Lastname} {player.Rating} \n");
                }
                return stringRanking.ToString();
            }
        }
        }
    }     

