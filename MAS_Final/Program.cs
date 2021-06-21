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

            Prezes p1 = Prezes.DodajPrezesa(k1, "Daniel", "Lewandowski", "Polska", new DateTime(1965, 04, 21), new DateTime(2002, 05, 02), 10000, new DateTime(2016, 07, 01));

            Dyrektor d1 = Dyrektor.DodajDyrektora(k1, "Konrad", "Wójcicki", "Polska", new DateTime(1981, 10, 15), new DateTime(2018, 06, 21), 7000, new List<TypDyrektora>() { TypDyrektora.Sportowy, TypDyrektora.Transferowy });


            Mecz m1 = new Mecz(new DateTime(2021, 04, 15), "Ursus Warszawa", "Varsowia Warszawa", "2:1");
            Mecz m2 = new Mecz(new DateTime(2021, 04, 22), "Pogoń Siedlce", "Varsowia Warszawa", "0:2");
            Mecz m3 = new Mecz(new DateTime(2021, 05, 04), "Dąb Wieliszew", "Okęcie Warszawa", "4:1");
            Mecz m4 = new Mecz(new DateTime(2021, 05, 10), "Okęcie Warszawa", "Rozwój Warszawa", "0:0");
            Mecz m5 = new Mecz(new DateTime(2021, 05, 10), "Huragan Wołomin", "Sokół Serock", "0:6");
            Mecz m6 = new Mecz(new DateTime(2021, 05, 23), "Uniao de Leiria", "Estrela de Amadora", "0:1");
            Mecz m7 = new Mecz(new DateTime(2021, 05, 18), "Bug Wyszków", "Wicher Kobyłka", "2:3");
            Mecz m8 = new Mecz(new DateTime(2021, 05, 18), "Varsowia Warszawa", "Rozwój Warszawa", "3:0");

            Zawodnik z1 = new Zawodnik("Mikołaj", "Kwiatkowski", "Polska", "Środkowy pomocnik", new DateTime(1999, 07, 22), "Varsowia Warszawa", 10000);
            Zawodnik z2 = new Zawodnik("Adam", "Kozłowski", "Polska", "Bramkarz", new DateTime(2001, 12, 19), "Okęcie Warszawa", 7500);
            Zawodnik z3 = new Zawodnik("Sebastian", "Michalski", "Polska", "Lewy obrońca", new DateTime(1996, 02, 06), "Huragan Wołomin", 3000);
            Zawodnik z4 = new Zawodnik("Andre", "Martins", "Portugalia", "Napastnik", new DateTime(1998, 06, 04), "Estrela de Amadora", 40000);
            Zawodnik z5 = new Zawodnik("Arkadiusz", "Filipiuk", "Polska", "Środkowy obrońca", new DateTime(1996, 10, 14), "Wicher Kobyłka", 9000);
            Zawodnik z6 = new Zawodnik("Jakub", "Stefańczyk", "Polska", "Prawy pomocnik", new DateTime(1994, 01, 12), "Varsowia Warszawa", 12000);
            Zawodnik z7 = new Zawodnik("Angel", "Torres", "Hiszpania", "Napastnik", new DateTime(2003, 11, 29), "Uniao de Leiria", 25000);

            Skaut s1 = Skaut.DodajSkauta(k1, "Tomasz", "Kowalski", "Polska", new DateTime(1978, 02, 06), new DateTime(2014, 04, 29), 4500, new List<String>() { "Polska" });
            Skaut s2 = Skaut.DodajSkauta(k1, "Robert", "Nowak", "Polska", new DateTime(1970, 11, 10), new DateTime(2007, 08, 17), 5000, new List<String>() { "Polska" });
            Skaut s3 = Skaut.DodajSkauta(k1, "Damian", "Pacholczyk", "Polska", new DateTime(1985, 04, 08), new DateTime(2020, 10, 09), 4000, new List<String>() { "Polska" });
            Skaut s4 = Skaut.DodajSkauta(k1, "Michał", "Górski", "Polska", new DateTime(1981, 08, 30), new DateTime(2019, 09, 27), 4000, new List<String>() { "Polska, Słowacja" });
            Skaut s5 = Skaut.DodajSkauta(k1, "Luis", "Castro", "Portugalia", new DateTime(1965, 09, 01), new DateTime(2016, 02, 11), 4000, new List<String>() { "Portugalia, Hiszpania" });

            GlownySkaut gs1 = p1.AwansujSkauta(s2, 6000);

            //Przypadek 1 - Modelowy
            s1.StworzRaport(z1, m1, "Bardzo dobry występ. Aktywny, strzelił jedynego gola dla swojego zespołu");
            gs1.ZmienStatusZawodnika(z1, StatusZawodnika.DoDalszejObserwacji);
            s1.StworzRaport(z1, m2, "Kolejny pozytywny występ, choć tym razem bez bramki ani asysty");
            gs1.ZmienStatusZawodnika(z1, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z1, Opinia.Pozytywna);
            d1.StworzKosztorys(z1, 20000, 13000);
            p1.PodejmijDecyzje(z1, TypDecyzji.Zgoda, "Zawodnik z dużym potencjałem, na którego nas stać");

            //Przypadek 2 - Oczekuje na drugą zmianę statusu
            s3.StworzRaport(z6, m1, "Robił dużo wiatru po prawej stronie, ale rzadko kiedy coś z tego wynikało. Nieco egoistyczny na boisku");
            gs1.ZmienStatusZawodnika(z6, StatusZawodnika.DoDalszejObserwacji);
            s1.StworzRaport(z6, m8, "Wszedł na boisko z ławki rezerwowych na ostatni kwadrans, prawie strzelił gola");

            //Przypadek 3 - Negatywna opinia kończy proces
            s3.StworzRaport(z2, m3, "Puścił cztery bramki, jednak pretensje można mieć tylko o jedną z nich. Nieźle wyprowadzał piłkę");
            gs1.ZmienStatusZawodnika(z2, StatusZawodnika.DoDalszejObserwacji);
            s4.StworzRaport(z2, m4, "Tym razem na zero z tyłu, choć popełniał błędy i miał szczęście, że nie zostały one zamienione na bramki");
            gs1.ZmienStatusZawodnika(z2, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z2, Opinia.Negatywna);

            //Przypadek 4 - Zawiszenie obserwacji 
            s4.StworzRaport(z3, m5, "Najsłabszy na boisku, przeciwnicy robili z nim co chcieli");
            gs1.ZmienStatusZawodnika(z3, StatusZawodnika.ZawieszenieObserwacji);

            //Przypadek 5 - Odmowna decyzja prezesa
            s5.StworzRaport(z4, m6, "Strzelec jedynego gola, wypracował też karnego. Pomimo swojego wzrostu bardzo ruchliwy i dynamiczny. Potencjalnie gwiazda ligi");
            gs1.ZmienStatusZawodnika(z4, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z4, Opinia.Pozytywna);
            d1.StworzKosztorys(z4, 100000, 70000);
            p1.PodejmijDecyzje(z1, TypDecyzji.Odrzucenie, "Pomimo niewątpliwego talentu niestety poza naszym zasięgiem finansowym");

            //Przypadek 6 - Modelowy v2
            s1.StworzRaport(z5, m7, "Wygrywał wiele pojedynków powietrznych. Brakuje mu nieco koordynacji, ale myślę, że można nad tym popracować");
            gs1.ZmienStatusZawodnika(z5, StatusZawodnika.DoDalszejObserwacji);
            s1.StworzRaport(z5, m8, "Skała, był wprost nie do przejścia. Dzięki niemu zespół nie stracił żadnej bramki");
            gs1.ZmienStatusZawodnika(z5, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z5, Opinia.Pozytywna);
            d1.StworzKosztorys(z5, 16000, 12000);
            p1.PodejmijDecyzje(z1, TypDecyzji.Zgoda, "Wygląda na stosunkowo tanie wzmocnienie kulejącej u nas obrony");

            //Przypadek 7 - Oczekuje na drugą zmianę statusu
            s5.StworzRaport(z7, m6, "Niski, zwinny napastnik, łatwo dochodził do sytuacji strzeleckich, za to miał problemy z wykończeniem");
            gs1.ZmienStatusZawodnika(z7, StatusZawodnika.DoDalszejObserwacji);


            Helper.SaveExtent<Decyzja>("Decyzje.bin");
            Helper.ReadExtent<Decyzja>();
            Helper.ShowExtent<Decyzja>();

            Helper.SaveExtent<Dyrektor>("Dyrektorzy.bin");
            Helper.ReadExtent<Dyrektor>();
            Helper.ShowExtent<Dyrektor>();

            Helper.SaveExtent<Klub>("Kluby.bin");
            Helper.ReadExtent<Klub>();
            Helper.ShowExtent<Klub>();

            Helper.SaveExtent<Kosztorys>("Kosztorysy.bin");
            Helper.ReadExtent<Kosztorys>();
            Helper.ShowExtent<Kosztorys>();

            Helper.SaveExtent<Mecz>("Mecze.bin");
            Helper.ReadExtent<Mecz>();
            Helper.ShowExtent<Mecz>();

            Helper.SaveExtent<Raport>("Raporty.bin");
            Helper.ReadExtent<Raport>();
            Helper.ShowExtent<Raport>();

            Helper.SaveExtent<Skaut>("Skauci.bin");
            Helper.ReadExtent<Skaut>();
            Helper.ShowExtent<Skaut>();

            Helper.SaveExtent<Zawodnik>("Zawodnicy.bin");
            Helper.ReadExtent<Zawodnik>();
            Helper.ShowExtent<Zawodnik>();
        }
    }
}
