using MP4.Atrybutu;
using MP4.Bag;
using MP4.Ordered;
using MP4.Subset;
using MP4.Unique;
using MP4.XOR;
using System;

namespace MP4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ograniczenie unique//

            Subject s1 = new Subject("Relacyjne bazy danych", "RBD", 2);
            Subject s2 = new Subject("Systemy baz danych", "SBD", 3);
            //Subject s3 = new Subject("Systemy baz danych", "RBD", 3); //błąd, powielone nazwy

            Console.WriteLine("---Ograniczenie atrybutu i własne--\n");

            User u1 = new User("Thomas", "password", new DateTime(2020, 05, 11));
            //User u2 = new User("Robson", "master", new DateTime(2019, 09, 30)); //błąd, hasło poniżej 8 znaków

            u1.ChangeUsername("Thomas1");
            //u1.ChangeUsername("Thomas123"); błąd, druga zmiana nazwy użytkownika 

            //Ograniczenie ordered//

            Line l1 = new Line(179, LineType.Normal);
            Stop st1 = new Stop("Os.Kabaty", 2);
            Stop st2 = new Stop("Metro Kabaty", 4);
            Stop st3 = new Stop("Mielczarskiego", 1);

            l1.AddStop(st1);
            l1.AddStop(st2);
            l1.AddStop(st3);

            Console.WriteLine(l1.ShowStops());

            Console.WriteLine("---Ograniczenie bag---\n");

            Driver d1 = new Driver("Tomasz", "Kowalski", "Poland");
            Circuit c1 = new Circuit("Monza", 5.793, 11);

            Lap lap1 = new Lap(d1, c1, new TimeSpan(0, 0, 2, 18, 343), new DateTime(2019, 06, 14, 10, 23, 47));
            Lap lap2 = new Lap(d1, c1, new TimeSpan(0, 0, 2, 17, 891), new DateTime(2019, 06, 14, 10, 30, 04));
            Lap lap3 = new Lap(d1, c1, new TimeSpan(0, 0, 2, 20, 164), new DateTime(2019, 07, 05, 18, 04, 36));

            Console.WriteLine(d1.ShowTimes());
            Console.WriteLine(c1.ShowTimes());
            Console.WriteLine(d1.LapsOnCircuit(c1));

            Console.WriteLine("---Ograniczenie subset---\n");

            Team t1 = new Team("FC Barcelona", "Spain", 1989);
            Player p1 = new Player("Leo", "Messi", "Argentina", new DateTime(1987, 06, 24));

            Team t2 = new Team("Real Madrid", "Spain", 1902);
            Player p2 = new Player("Sergio", "Ramos", "Spain", new DateTime(1986, 03, 30));

            t1.SignPlayer(p1);
            t2.SignPlayer(p2);

            t1.SetCaptain(p1);
            t2.SetCaptain(p2);

            Console.WriteLine(t1.GetCaptainInfo());
            Console.WriteLine(t2.GetCaptainInfo());

            //t1.SetCaptain(p2); //błąd, gracz p2 nie jest zawodnikiem t1
            t2.ReleasePlayer(p2);

            t1.SignPlayer(p2);
            t1.SetCaptain(p2);

            Console.WriteLine(t1.GetCaptainInfo());

            Console.WriteLine("---Ograniczenie XOR---\n");

            Employee e1 = new Employee("Marek", "Nowak", new DateTime(1996, 10, 17));
            EmploymentContract ec1 = new EmploymentContract("Junior C# Developer", 3000, new DateTime(2021, 09, 17), 40, 90, e1);
            MandateContract mc1 = new MandateContract("Create mobile app", 5000, new DateTime(2021, 05, 13), new DateTime(2021, 08, 13), e1); //błąd, pracownik ma już umowę o pracę
        }
    }
}
