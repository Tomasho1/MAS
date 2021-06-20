using EnumsNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MAS_Final
{
    public enum StatusZawodnika
    {
        [Description("Po obserwacji")] PoObserwacji,
        [Description("Do dalszej obserwacji")] DoDalszejObserwacji,
        [Description("Zawieszenie obserwacji")] ZawieszenieObserwacji,
        Zarekomendowany
    }

    public enum Opinia
    {
        [Description("Zaopiniowany pozytywnie")] Pozytywna,
        [Description("Zaopiniowany negatywnie")] Negatywna
    }

    [Serializable]
    public class Zawodnik
    {

        private static int idOstatniZawodnik = 0;

        private int idZawodnik;
        public int IdZawodnik
        {
            get
            {
                return idZawodnik;
            }
            set
            {
                idZawodnik = value;
            }
        }

        private string imie;
        public string Imie
        {
            get
            {
                return imie;
            }
            set
            {
                imie = value;
            }
        }

        private string nazwisko;
        public string Nazwisko
        {
            get
            {
                return nazwisko;
            }
            set
            {
                nazwisko = value;
            }
        }

        private string narodowosc;
        public string Narodowosc
        {
            get
            {
                return narodowosc;
            }
            set
            {
                narodowosc = value;
            }
        }

        private DateTime dataUrodzenia;
        public DateTime DataUrodzenia
        {
            get
            {
                return dataUrodzenia;
            }
            set
            {
                dataUrodzenia = value;
            }
        }
        private int wiek;
        public int Wiek
        {
            get
            {
                DateTime now = DateTime.Today;
                wiek = now.Year - this.DataUrodzenia.Year;
                if (now < DataUrodzenia.AddYears(wiek))
                {
                    wiek--;
                }
                return wiek;
            }
        }
        private string aktualnyKlub;
        public string AktualnyKlub
        {
            get
            {
                return aktualnyKlub;
            }
            set
            {
                aktualnyKlub = value;
            }
        }

        private double wartosc;
        public double Wartosc
        {
            get
            {
                return wartosc;
            }
            set
            {
                wartosc = value;
            }
        }


        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        private string opinia;
        public string Opinia
        {
            get
            {
                return opinia;
            }
            set
            {
                opinia = value;
            }
        }


        private Kosztorys? kosztorys;

        public Kosztorys? Kosztorys
        {
            get
            {
                return kosztorys;
            }
            set
            {
                kosztorys = value;
            }
        }

        private Decyzja? decyzja;

        public Decyzja? Decyzja
        {
            get
            {
                return decyzja;
            }
            set
            {
                decyzja = value;
            }
        }

        private List<KeyValuePair<Skaut, Raport>> raporty = new List<KeyValuePair<Skaut, Raport>>();
        public List<KeyValuePair<Skaut, Raport>> Raporty
        {
            get
            {
                return raporty;
            }

            set
            {
                raporty = value;
            }
        }

        public static List<Zawodnik> extent = new List<Zawodnik>();

        public static List<Zawodnik> Extent
        {
            get
            {
                return extent;
            }
            set
            {
                extent = value;
            }
        }

        public Zawodnik(String imie, String nazwisko, String narodowosc, DateTime dataUrodzenia, String aktualnyKlub, double wartosc)
        {
            
            idOstatniZawodnik++;
            IdZawodnik = idOstatniZawodnik;
            Imie = imie;
            Nazwisko = nazwisko;
            Narodowosc = narodowosc;
            DataUrodzenia = dataUrodzenia;
            AktualnyKlub = aktualnyKlub;
            Wartosc = wartosc;
            Status = Helper.GetEnumDescription(StatusZawodnika.PoObserwacji);
            extent.Add(this);
        }

        public List<Zawodnik> ZnajdzZawodnikowPoStatusie(StatusZawodnika status)
        {
            var lista = extent.Where(p => p.Status == status.ToString()).ToList();
            return lista;
        }

        public void DodajRaport(Skaut skaut, Raport raport)
        {
            raporty.Add(new KeyValuePair<Skaut, Raport>(skaut, raport));
        }

    }
}
