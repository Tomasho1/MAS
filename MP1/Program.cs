using System;
using System.Collections.Generic;

namespace MP1
{
    class Program
    {
        //Creating players
        static void Main(string[] args)
        {
            var player1 = new Player("Magnus", "Carlsen", "Norway", new DateTime(1990, 11, 30), new Dictionary<string, int>
            {
                { "Standard", 2847 },
                { "Rapid", 2881 },
                { "Blitz", 2886 }
            }, "Grandmaster");

            var player2 = new Player("Hikaru", "Nakamura", "USA", new DateTime(1987, 12, 09), new Dictionary<string, int>
            {
                { "Standard", 2736 },
                { "Rapid", 2829 },
                { "Blitz", 2900}
            }, "Grandmaster");

            var player3 = new Player("Anish", "Giri", "Netherlands", new DateTime(1994, 06, 28), new Dictionary<string, int>
            {
                { "Standard", 2776 },
                { "Rapid", 2731 },
                { "Blitz", 2744}
            }, "Grandmaster");

            var player4 = new Player("Bartosz", "Rudecki", "Poland", new DateTime(1999, 04, 14), new Dictionary<string, int>
            {
                { "Standard", 1846 },
                { "Rapid", 1731 },
                { "Blitz", 1743}
            });

            var player5 = new Player("Levy", "Rozman", "USA", new DateTime(1995, 12, 05), new Dictionary<string, int>
            {
                { "Standard", 2343 },
                { "Rapid", 2284 },
                { "Blitz", 2376}
            }, "International Master");


            //Testing methods
            Console.WriteLine(player1.ToString());
            Console.WriteLine("\n" + player2.showPlayerPosition());
            Console.WriteLine("\n" + Player.showWorldRankings("Blitz"));


            Player.saveExtent();
            //Player.readExtent();

            
        }
           
    }

}
