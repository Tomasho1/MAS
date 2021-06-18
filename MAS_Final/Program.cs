using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MAS_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Klub k1 = new Klub("Hutnik Warszawa", "Polska", "Stadion Hutnika Warszawa", 1957, "IV Liga", 5);

            Mecz m1 = new Mecz(new DateTime(2021, 06, 15), "Ursus Warszawa", "Varsowia Warszawa", "2:1");

            Zawodnik z1 = new Zawodnik("Mikołaj", "Kwiatkowski", "Polska", new DateTime(1999, 07, 22), "Varsowia Warszawa", 100000);
            Zawodnik z2 = new Zawodnik("Adam", "Kozłowski", "Polska", new DateTime(2001, 12, 19), "Varsowia Warszawa", 750000);

            Skaut s1 = new Skaut(k1, "Tomasz", "Kowalski", new DateTime(1978, 02, 06), new DateTime(2014, 04, 29), 4500, new List<String>() { "Polska" });

            Dyrektor d1 = new Dyrektor(k1, "Konrad", "Wójcicki", new DateTime(1981, 10, 15), new DateTime(2018, 06, 21), 7000, new List<TypDyrektora>() { TypDyrektora.Sportowy, TypDyrektora.Transferowy });

            Prezes p1 = new Prezes(k1, "Daniel", "Lewandowski", new DateTime(1965, 04, 21), new DateTime(2002, 05, 02), 10000, new DateTime(2016, 07, 01));

            GlownySkaut gs1 = new GlownySkaut(k1, "Robert", "Nowak", new DateTime(1970, 11, 10), new DateTime(2007, 08, 17), 6500, p1, new DateTime(2017, 10, 24));


            s1.StworzRaport(z1, m1, "Bardzo dobry występ. Aktywny, strzelił jedynego gola dla swojego zespołu");
            gs1.ZmienStatusZawodnika(z1, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z1, Opinia.Pozytywna);
            d1.StworzKosztorys(z1, 15000000, 200000);
            p1.PodejmijDecyzje(z1, TypDecyzji.Zgoda, "Zawodnik z dużym potencjałem, na którego nas stać");

            Console.WriteLine(z1.Status + z1.Opinia + z1.Kosztorys);

            Helper.SaveExtent<Zawodnik>("Zawodnicy.bin");

            Helper.ReadExtent<Zawodnik>();

            Helper.ShowExtent<Zawodnik>();
            }
        }
    }
