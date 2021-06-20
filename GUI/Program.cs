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

            Mecz m1 = new Mecz(new DateTime(2021, 06, 15), "Ursus Warszawa", "Varsowia Warszawa", "2:1");

            Zawodnik z1 = new Zawodnik("Miko³aj", "Kwiatkowski", "Polska", new DateTime(1999, 07, 22), "Varsowia Warszawa", 100000);
            Zawodnik z2 = new Zawodnik("Adam", "Koz³owski", "Polska", new DateTime(2001, 12, 19), "Varsowia Warszawa", 750000);

            Skaut s1 = Skaut.DodajSkauta(k1, "Tomasz", "Kowalski", "Polska", new DateTime(1978, 02, 06), new DateTime(2014, 04, 29), 4500, new List<String>() { "Polska" });
            Skaut s2 = Skaut.DodajSkauta(k1, "Robert", "Nowak", "Polska", new DateTime(1970, 11, 10), new DateTime(2007, 08, 17), 5000, new List<String>() { "Polska" });
            Skaut s3 = Skaut.DodajSkauta(k1, "Damian", "Pacholczyk", "Polska", new DateTime(1985, 04, 08), new DateTime(2020, 10, 09), 4000, new List<String>() { "Polska" });

            Dyrektor d1 = Dyrektor.DodajDyrektora(k1, "Konrad", "Wójcicki", "Polska", new DateTime(1981, 10, 15), new DateTime(2018, 06, 21), 7000, new List<TypDyrektora>() { TypDyrektora.Sportowy, TypDyrektora.Transferowy });

            Prezes p1 = Prezes.DodajPrezesa(k1, "Daniel", "Lewandowski", "Polska", new DateTime(1965, 04, 21), new DateTime(2002, 05, 02), 10000, new DateTime(2016, 07, 01));


            GlownySkaut gs1 = p1.AwansujSkauta(s2, 6000);

            s1.StworzRaport(z1, m1, "Bardzo dobry wystêp. Aktywny, strzeli³ jedynego gola dla swojego zespo³u");
            gs1.ZmienStatusZawodnika(z1, StatusZawodnika.Zarekomendowany);
            d1.WydajOpinie(z1, Opinia.Pozytywna);
            d1.StworzKosztorys(z1, 15000000, 200000);
            p1.PodejmijDecyzje(z1, TypDecyzji.Zgoda, "Zawodnik z du¿ym potencja³em, na którego nas staæ");



            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Skauci());
        }
    }
}
