using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace MP2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Asocjacja zwykła---" + "\n");

            Developer dev1 = new Developer("Valve", "United States", new DateTime(1996, 08, 24));

            Game game1 = new Game("Counter-Strike: Global Offensive", "FPS", new DateTime(2013, 08, 21));
            Game game2 = new Game("Dota 2", "MOBA", new DateTime(2013, 07, 09));
            Game game3 = new Game("Portal 2", "Puzzle-platform", new DateTime(2011, 04, 18));

            dev1.AddGame(game1);
            dev1.AddGame(game2);
            dev1.AddGame(game3);
            dev1.DeveloperGames();

            dev1.DeleteGame(game1);
            Console.WriteLine(game1.GetDeveloperName());
            Console.WriteLine(game2.GetDeveloperName());
            Console.WriteLine(game3.GetDeveloperName() + "\n");
            dev1.DeveloperGames();

            Console.WriteLine("---Asocjacja z atrybutem---" + "\n");

            Developer dev2 = new Developer("Electronic Arts", "United States", new DateTime(1982, 05, 27));
            Developer dev3 = new Developer("Sony", "United States", new DateTime(1993, 11, 16));
            Developer dev4 = new Developer("Microsoft", "United States", new DateTime(1975, 04, 04));
            Developer dev5 = new Developer("Ubisoft", "France", new DateTime(1986, 03, 28));

            Game game4 = new Game("FIFA 21", "Sports", new DateTime(2020, 10, 09));
            Game game5 = new Game("Rainbow Six: Siege", "Tactical shooter", new DateTime(2015, 12, 01));

            dev2.AddGame(game4);
            dev5.AddGame(game5);

            Platform plat1 = new Platform("PlayStation 5", dev3);
            Platform plat2 = new Platform("Windows", dev4);
            Platform plat3 = new Platform("PlayStation 4", dev3);

            GamePlatform gameplat1 = new GamePlatform(plat1, game4, new DateTime(2020, 12, 03));
            GamePlatform gameplat2 = new GamePlatform(plat2, game4, new DateTime(2020, 10, 09));
            GamePlatform gameplat3 = new GamePlatform(plat2, game5, new DateTime(2015, 12, 01));
            GamePlatform gameplat4 = new GamePlatform(plat3, game5, new DateTime(2015, 12, 01));
            GamePlatform gameplat5 = new GamePlatform(plat3, game4, new DateTime(2020, 10, 09));

            game5.ShowAvailablePlatforms();
            game4.ShowAvailablePlatforms();
            plat2.ShowAvailableGames();

            gameplat3.Delete();

            game5.ShowAvailablePlatforms();
            plat2.ShowAvailableGames();

            Console.WriteLine("---Asocjacja kwalifikowana---" + "\n");

            Developer dev6 = new Developer("Apple", "United States", new DateTime(1976, 04, 01));

            Platform plat4 = new Platform("macOS", dev6);

            Service serv1 = new Service("Steam", new DateTime(2003, 09, 12), new List<Platform>() { plat2, plat4});
            Service serv2 = new Service("Origin", new DateTime(2011, 06, 03), new List<Platform>() { plat2, plat4 });

            Account acc1 = new Account("Thomas", new DateTime(2020, 05, 11), "England", new MailAddress("thomas1@gmail.com"));
            Account acc2 = new Account("Janeq", new DateTime(2018, 09, 29), "Poland", new MailAddress("janeqpl@gmail.com"));
            Account acc3 = new Account("roberto-", new DateTime(2019, 01, 17), "Spain", new MailAddress("soyroberto@gmail.com"));
            Account acc4 = new Account("Lucas", new DateTime(2016, 10, 24), "Brazil", new MailAddress("lucass@gmail.com"));

            acc1.AddServiceQualif(serv1);
            acc2.AddServiceQualif(serv1);
            acc3.AddServiceQualif(serv2);
            acc4.AddServiceQualif(serv2);

            serv1.ShowAccounts();
            serv2.ShowAccounts();
            Console.WriteLine(acc1.FindServiceQualif("Steam"));

            Console.WriteLine("\n" + "---Kompozycja---" + "\n");

            Studio.CreateStudio(dev2, "EA Gothenburg", "Sweden", "Gothenburg");
            Studio.CreateStudio(dev2, "EA Galway", "Ireland", "Galway");
            Studio.CreateStudio(dev5, "Ubisoft Barcelona", "Spain", "Barcelona");
            //Studio.CreateStudio(dev3, "Ubisoft Barcelona", "Spain", "Barcelona"); 

            dev2.ShowStudios();

            dev2.Remove();

            dev2.ShowStudios();
            dev5.ShowStudios();

        }
    }
}
