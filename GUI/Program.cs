using MAS_Final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Klub k1 = new Klub("Hutnik Warszawa", "Polska", "Stadion Hutnika Warszawa", 1957, "IV Liga", 5);

            Prezes p1 = Prezes.DodajPrezesa(k1, "Daniel", "Lewandowski", "Polska", new DateTime(1965, 04, 21), new DateTime(2002, 05, 02), 10000, new DateTime(2016, 07, 01));

            Dyrektor d1 = Dyrektor.DodajDyrektora(k1, "Konrad", "Wójcicki", "Polska", new DateTime(1981, 10, 15), new DateTime(2018, 06, 21), 7000, new List<TypDyrektora>() { TypDyrektora.Sportowy, TypDyrektora.Transferowy });


            Mecz m1 = new Mecz(new DateTime(2021, 04, 15), "Ursus Warszawa", "Varsowia Warszawa", "2:1");
            Mecz m2 = new Mecz(new DateTime(2021, 04, 22), "Pogoñ Siedlce", "Varsowia Warszawa", "0:2");
            Mecz m3 = new Mecz(new DateTime(2021, 05, 04), "D¹b Wieliszew", "Okêcie Warszawa", "4:1");
            Mecz m4 = new Mecz(new DateTime(2021, 05, 10), "Okêcie Warszawa", "Rozwój Warszawa", "0:0");
            Mecz m5 = new Mecz(new DateTime(2021, 05, 10), "Huragan Wo³omin", "Sokó³ Serock", "0:6");
            Mecz m6 = new Mecz(new DateTime(2021, 05, 23), "Uniao de Leiria", "Estrela de Amadora", "0:1");
            Mecz m7 = new Mecz(new DateTime(2021, 05, 18), "Bug Wyszków", "Wicher Koby³ka", "2:3");
            Mecz m8 = new Mecz(new DateTime(2021, 05, 18), "Varsowia Warszawa", "Rozwój Warszawa", "3:0");

            Zawodnik z1 = new Zawodnik("Miko³aj", "Kwiatkowski", "Polska", "Œrodkowy pomocnik", new DateTime(1999, 07, 22), "Varsowia Warszawa", 10000);
            Zawodnik z2 = new Zawodnik("Adam", "Koz³owski", "Polska", "Bramkarz", new DateTime(2001, 12, 19), "Okêcie Warszawa", 7500);
            Zawodnik z3 = new Zawodnik("Sebastian", "Michalski", "Polska", "Lewy obroñca", new DateTime(1996, 02, 06), "Huragan Wo³omin", 3000);
            Zawodnik z4 = new Zawodnik("Andre", "Martins", "Portugalia", "Napastnik", new DateTime(1998, 06, 04), "Estrela de Amadora", 40000);
            Zawodnik z5 = new Zawodnik("Arkadiusz", "Filipiuk", "Polska", "Œrodkowy obroñca", new DateTime(1996, 10, 14), "Wicher Koby³ka", 9000);
            Zawodnik z6 = new Zawodnik("Jakub", "Stefañczyk", "Polska", "Prawy pomocnik", new DateTime(1994, 01, 12), "Varsowia Warszawa", 12000);
            Zawodnik z7 = new Zawodnik("Angel", "Torres", "Hiszpania", "Napastnik", new DateTime(2003, 11, 29), "Uniao de Leiria", 25000);

            Skaut s1 = Skaut.DodajSkauta(k1, "Tomasz", "Kowalski", "Polska", new DateTime(1978, 02, 06), new DateTime(2014, 04, 29), 4500, new List<String>() { "Polska" });
            Skaut s2 = Skaut.DodajSkauta(k1, "Robert", "Nowak", "Polska", new DateTime(1970, 11, 10), new DateTime(2007, 08, 17), 5000, new List<String>() { "Polska" });
            Skaut s3 = Skaut.DodajSkauta(k1, "Damian", "Pacholczyk", "Polska", new DateTime(1985, 04, 08), new DateTime(2020, 10, 09), 4000, new List<String>() { "Polska" });
            Skaut s4 = Skaut.DodajSkauta(k1, "Micha³", "Górski", "Polska", new DateTime(1981, 08, 30), new DateTime(2019, 09, 27), 4000, new List<String>() { "Polska, S³owacja" });
            Skaut s5 = Skaut.DodajSkauta(k1, "Luis", "Castro", "Portugalia", new DateTime(1965, 09, 01), new DateTime(2016, 02, 11), 4000, new List<String>() { "Portugalia, Hiszpania" });

            GlownySkaut gs1 = p1.AwansujSkauta(s2, 6000);

            //Przypadek 1 - Modelowy
            s1.StworzRaport(z1, m1, "Bardzo dobry wystêp. Aktywny, strzeli³ jedynego gola dla swojego zespo³u");
            gs1.ZmienStatusZawodnika(z1, StatusZawodnika.DoDalszejObserwacji);
            s1.StworzRaport(z1, m2, "Kolejny pozytywny wystêp, choæ tym razem bez bramki ani asysty");
            gs1.ZmienStatusZawodnika(z1, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z1, Opinia.Pozytywna);
            d1.StworzKosztorys(z1, 20000, 13000);
            p1.PodejmijDecyzje(z1, TypDecyzji.Zgoda, "Zawodnik z du¿ym potencja³em, na którego nas staæ");

            //Przypadek 2 - Oczekuje na drug¹ zmianê statusu
            s3.StworzRaport(z6, m1, "Robi³ du¿o wiatru po prawej stronie, ale rzadko kiedy coœ z tego wynika³o. Nieco egoistyczny na boisku");
            gs1.ZmienStatusZawodnika(z6, StatusZawodnika.DoDalszejObserwacji);
            s1.StworzRaport(z6, m8, "Wszed³ na boisko z ³awki rezerwowych na ostatni kwadrans, prawie strzeli³ gola");

            //Przypadek 3 - Negatywna opinia koñczy proces
            s3.StworzRaport(z2, m3, "Puœci³ cztery bramki, jednak pretensje mo¿na mieæ tylko o jedn¹ z nich. NieŸle wyprowadza³ pi³kê");
            gs1.ZmienStatusZawodnika(z2, StatusZawodnika.DoDalszejObserwacji);
            s4.StworzRaport(z2, m4, "Tym razem na zero z ty³u, choæ pope³nia³ b³êdy i mia³ szczêœcie, ¿e nie zosta³y one zamienione na bramki");
            gs1.ZmienStatusZawodnika(z2, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z2, Opinia.Negatywna);

            //Przypadek 4 - Zawiszenie obserwacji 
            s4.StworzRaport(z3, m5, "Najs³abszy na boisku, przeciwnicy robili z nim co chcieli");
            gs1.ZmienStatusZawodnika(z3, StatusZawodnika.ZawieszenieObserwacji);

            //Przypadek 5 - Odmowna decyzja prezesa
            s5.StworzRaport(z4, m6, "Strzelec jedynego gola, wypracowa³ te¿ karnego. Pomimo swojego wzrostu bardzo ruchliwy i dynamiczny. Potencjalnie gwiazda ligi");
            gs1.ZmienStatusZawodnika(z4, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z4, Opinia.Pozytywna);
            d1.StworzKosztorys(z4, 100000, 70000);
            p1.PodejmijDecyzje(z1, TypDecyzji.Odrzucenie, "Pomimo niew¹tpliwego talentu niestety poza naszym zasiêgiem finansowym");

            //Przypadek 6 - Modelowy v2
            s1.StworzRaport(z5, m7, "Wygrywa³ wiele pojedynków powietrznych. Brakuje mu nieco koordynacji, ale myœlê, ¿e mo¿na nad tym popracowaæ");
            gs1.ZmienStatusZawodnika(z5, StatusZawodnika.DoDalszejObserwacji);
            s1.StworzRaport(z5, m8, "Ska³a, by³ wprost nie do przejœcia. Dziêki niemu zespó³ nie straci³ ¿adnej bramki");
            gs1.ZmienStatusZawodnika(z5, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z5, Opinia.Pozytywna);
            d1.StworzKosztorys(z5, 16000, 12000);
            p1.PodejmijDecyzje(z1, TypDecyzji.Zgoda, "Wygl¹da na stosunkowo tanie wzmocnienie kulej¹cej u nas obrony");

            //Przypadek 7 - Oczekuje na drug¹ zmianê statusu
            s5.StworzRaport(z7, m6, "Niski, zwinny napastnik, ³atwo dochodzi³ do sytuacji strzeleckich, za to mia³ problemy z wykoñczeniem");
            gs1.ZmienStatusZawodnika(z7, StatusZawodnika.DoDalszejObserwacji);


            Helper.SaveExtent<Decyzja>("Decyzje.bin");
            Helper.ReadExtent<Decyzja>();

            Helper.SaveExtent<Dyrektor>("Dyrektorzy.bin");
            Helper.ReadExtent<Dyrektor>();

            Helper.SaveExtent<Klub>("Kluby.bin");
            Helper.ReadExtent<Klub>();

            Helper.SaveExtent<Kosztorys>("Kosztorysy.bin");
            Helper.ReadExtent<Kosztorys>();

            Helper.SaveExtent<Mecz>("Mecze.bin");
            Helper.ReadExtent<Mecz>();

            Helper.SaveExtent<Raport>("Raporty.bin");
            Helper.ReadExtent<Raport>();

            Helper.SaveExtent<Skaut>("Skauci.bin");
            Helper.ReadExtent<Skaut>();

            Helper.SaveExtent<Zawodnik>("Zawodnicy.bin");
            Helper.ReadExtent<Zawodnik>();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Skauci());
        }
    }
}
