using MP4.Atrybutu;
using MP4.Ordered;
using MP4.Unique;
using System;

namespace MP4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Ograniczenie unique--\n");

            Subject s1 = new Subject("Relacyjne bazy danych", "RBD", 2);
            Subject s2 = new Subject("Systemy baz danych", "SBD", 3);
            //Subject s3 = new Subject("Systemy baz danych", "RBD", 3);

            Console.WriteLine("---Ograniczenie atrybutu--\n");

            User u1 = new User("Thomas", "password", new DateTime(2020, 05, 11));
            //User u2 = new User("Robson", "master", new DateTime(2019, 09, 30));

            Console.WriteLine("---Ograniczenie ordered--\n");

            Line l1 = new Line(179, LineType.Normal);
            Stop st1 = new Stop("Os.Kabaty", 2);
            Stop st2 = new Stop("Metro Kabaty", 4);
            Stop st3 = new Stop("Mielczarskiego", 1);

            l1.AddStop(st1);
            l1.AddStop(st2);
            l1.AddStop(st3);

            Console.WriteLine(l1.ShowStops());
        }
    }
}
