using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    public enum TypDyrektora { 
        Sportowy, 
        Transferowy
    }

    [Serializable]
    public class Dyrektor : Pracownik
    {
        private bool dyrektorSportowy;
        public bool DyrektorSportowy
        {
            get
            {
                return dyrektorSportowy;
            }
            set
            {
                dyrektorSportowy = value;
            }
        }

        private bool dyrektorTransferowy;
        public bool DyrektorTransferowy
        {
            get
            {
                return dyrektorTransferowy;
            }
            set
            {
                dyrektorTransferowy = value;
            }
        }

        private List<Kosztorys> kosztorysy = new List<Kosztorys>();
        public List<Kosztorys> Kosztorysy
        {
            get
            {
                return kosztorysy;
            }
            set
            {
                kosztorysy = value;
            }
        }

        private static List<Dyrektor> extent = new List<Dyrektor>();

        public static List<Dyrektor> Extent
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

        private Dyrektor(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<TypDyrektora> stanowiska) : base(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            if (stanowiska.Contains(TypDyrektora.Sportowy))
            {
                DyrektorSportowy = true;
            }

            if (stanowiska.Contains(TypDyrektora.Transferowy))
            {
                DyrektorTransferowy = true;
            }

            if (stanowiska.Contains(TypDyrektora.Sportowy) && stanowiska.Contains(TypDyrektora.Transferowy))
            {
                DyrektorSportowy = true; 
                DyrektorTransferowy = true;
            }
            extent.Add(this);
        }

        private Dyrektor(Pracownik pracownik, List<TypDyrektora> stanowiska) : base(pracownik.Klub, pracownik.Imie, pracownik.Nazwisko, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, pracownik.Pensja)
        {
            Type typ = typeof(Pracownik);
            Klub klub = pracownik.Klub;

            if (stanowiska.Contains(TypDyrektora.Sportowy))
            {
                DyrektorSportowy = true;
            }

            if (stanowiska.Contains(TypDyrektora.Transferowy))
            {
                DyrektorTransferowy = true;
            }

            if (stanowiska.Contains(TypDyrektora.Sportowy) && stanowiska.Contains(TypDyrektora.Transferowy))
            {
                DyrektorSportowy = true;
                DyrektorTransferowy = true;
            }

            if (typ == typeof(Skaut))
            {
                klub.UsunPracownika(pracownik);
                Skaut.Extent.Remove((Skaut)pracownik);
            }

            if (typ == typeof(GlownySkaut))
            {
                klub.UsunGlownegoSkauta((GlownySkaut)pracownik);
            }

            if (typ == typeof(Prezes))
            {
                klub.UsunPrezesa((Prezes)pracownik);
            }

            extent.Add(this);
        }

        public static Dyrektor DodajDyrektora(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<TypDyrektora> stanowiska)
        {
            if (klub == null)
            {
                throw new Exception("Nie ma takiego klubu");
            }

            Dyrektor dyrektor = new Dyrektor(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja, stanowiska);
            klub.DodajPracownika(dyrektor);
            return dyrektor;
        }

        public static Dyrektor DodajDyrektora(Pracownik pracownik, List<TypDyrektora> stanowiska)
        {
            Klub klub = pracownik.Klub;
            Dyrektor dyrektor = new Dyrektor(pracownik, stanowiska);
            klub.DodajPracownika(dyrektor);
            return dyrektor;
        }

        public void WydajOpinie(Zawodnik zawodnik, Opinia opinia)
        {
            if (zawodnik.Status == Helper.GetEnumDescription(StatusZawodnika.ZawieszenieObserwacji))
            {
                throw new Exception("Nie możesz wydać opinii dla tego zawodnika");
            }

            zawodnik.Opinia = Helper.GetEnumDescription(opinia);
        }
        public Kosztorys StworzKosztorys(Zawodnik zawodnik, double szacowanaCena, double szacowanaPensja)
        {
            if(!DyrektorSportowy)
            {
                throw new Exception("Tylko dyrektor sportowy może tworzyć kosztorys");
            }

            if (zawodnik.Opinia != Helper.GetEnumDescription(Opinia.Pozytywna))
            {
                throw new Exception("Zawodnik nie otrzymał pozytywnej opinii dyrektora ds. transferów");
            }

            Kosztorys kosztorys = new Kosztorys(this, zawodnik, szacowanaCena, szacowanaPensja);
            return kosztorys;
        }
    }
}
