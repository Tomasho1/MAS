using MP3.Dynamiczne;
using MP3.Klasa_abstrakcyjna_i_polimorfizm;
using MP3.Overlapping;
using MP3.Wieloaspektowe;
using MP3.Wielodziedziczenie;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace MP3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---Klasa abstrakcyjna i polimorfizm---\n");

            Student s1 = new DomesticStudent("Jacek", "Kowalczyk", "Poland", "s1345", 15, 0);
            Student s2 = new ForeignStudent("Robert", "Muller", "Germany", "s1077");

            Console.WriteLine(s1.CalculateYearlyTuitionFee());
            Console.WriteLine(s2.CalculateYearlyTuitionFee());

            Console.WriteLine("\n---Dziedziczenie overlapping---\n");

            EventParticipant t1 = new EventParticipant("Tomasz", "Kowalski", "Poland", new DateTime(2000, 11, 30), new List<ParticipationType> { ParticipationType.Player }, null, "21");
            EventParticipant t2 = new EventParticipant("Grzegorz", "Lewandowski", "Poland", new DateTime(1976, 01, 06), new List<ParticipationType> { ParticipationType.Referee }, "S982EV", null);
            EventParticipant t3 = new EventParticipant("Paweł", "Nowak", "Poland", new DateTime(1988, 06, 14), new List<ParticipationType> { ParticipationType.Player, ParticipationType.Referee}, "A317B", "33");

            Console.WriteLine(t1.isPlayer());
            Console.WriteLine(t1.isReferee());
            Console.WriteLine(t1.ToString());

            Console.WriteLine(t2.isPlayer());
            Console.WriteLine(t2.isReferee());
            Console.WriteLine(t2.ToString());

            Console.WriteLine(t3.isPlayer());
            Console.WriteLine(t3.isReferee());
            Console.WriteLine(t3.ToString());

            Console.WriteLine("\n---Dziedziczenie dynamiczne---\n");

            Account acc1 = new AccountPremium("Thomas", new DateTime(2020, 05, 11), "England", new MailAddress("thomas1@gmail.com"), new DateTime(2020, 05, 20), SubscriptionType.Silver);
            Account acc2 = new AccountNormal("Janeq", new DateTime(2018, 09, 29), "Poland", new MailAddress("janeqpl@gmail.com"));

            Console.WriteLine(acc1.ToString());
            Console.WriteLine(acc2.ToString());

            acc1 = new AccountNormal(acc1);
            acc2 = new AccountPremium(acc2, new DateTime(2019, 10, 24), SubscriptionType.Diamond);

            Console.WriteLine(acc1.ToString());
            Console.WriteLine(acc2.ToString());

            acc1 = new AccountPremium(acc1, new DateTime(2020, 05, 20), SubscriptionType.Silver);

            Console.WriteLine(acc1.ToString());

            Console.WriteLine("\n---Wielodziedziczenie---\n");

            Car c1 = new CombustionCar("Lamborghini Huracan", 610, 2016, 11.0, 83);
            Car c2 = new ElectricCar("BMW i3", 170, 2013, 260.0, 13.1);
            Car c3 = new HybridCar("Toyota C-HR", 122, 2017, 3.6, 43, 50.0, 2.0);

            Console.WriteLine(c1.CalculateNeededUnit(250.00));
            Console.WriteLine(c2.CalculateNeededUnit(250.00));
            Console.WriteLine(c3.CalculateNeededUnit(250.00) + "\n");

            Console.WriteLine(c3.ToString());

            Console.WriteLine("\n---Wieloaspektowe---\n");

            Device d1 = new Device("JBL", "Flip 5", "Blue", 12);
            Device d2 = new Device("Steelseries", "Arctis 5", "Black", 3.0);

            Mouse m1 = new Mouse("Logitech", "G PRO", "Black", 7, 25600);
            Keyboard k1 = new Keyboard("Razer", "Huntsman", "Black", SwitchType.Mechanical, true);

            Console.WriteLine(d1.GetConnection());
            Console.WriteLine(d2.GetConnection() + "\n");

            Console.WriteLine(d1.ToString());
            Console.WriteLine(d2.ToString());
            Console.WriteLine(m1.ToString());
            Console.WriteLine(k1.ToString());
        }
    }
}
