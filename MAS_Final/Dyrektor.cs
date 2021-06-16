using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    public enum TypDyrektora { 
        Sportowy, 
        Transferowy
    }
    public class Dyrektor : Pracownik
    {
        private string typ;
        public string Typ
        {
            get
            {
                return typ;
            }
            set
            {
                typ = value;
            }
        }

        private List<Kosztorys> kosztorysy;

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

        public Dyrektor(String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, TypDyrektora typ) : base(imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            this.Typ = typ.ToString();
        }

        public Dyrektor(Pracownik pracownik, TypDyrektora typ) : base(pracownik.Imie, pracownik.Nazwisko, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, pracownik.Pensja)
        {
            this.Typ = typ.ToString();
        }

        public Kosztorys StworzKosztorys(Zawodnik zawodnik, double szacowanaCena, double szacowanaPensja)
        {
            if(this.Typ == TypDyrektora.Sportowy.ToString())
            {
                throw new Exception("Tylko dyrektor sportowy może tworzyć kosztorys");
            }

            if (zawodnik.Opinia != Opinia.Pozytywna.ToString())
            {
                throw new Exception("Zawodnik nie otrzymał pozytywnej opinii dyrektora ds. transferów");
            }

            Kosztorys kosztorys = new Kosztorys(this, zawodnik, szacowanaCena, szacowanaPensja);
            return kosztorys;
        }
    }
}
