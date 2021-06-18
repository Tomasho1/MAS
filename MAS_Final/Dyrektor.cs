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

        public Dyrektor(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<TypDyrektora> stanowiska) : base(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
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
            klub.DodajPracownika(this);
        }

        public Dyrektor(Skaut skaut, List<TypDyrektora> stanowiska) : base(skaut.Klub, skaut.Imie, skaut.Nazwisko, skaut.DataUrodzenia, skaut.DataZatrudnienia, skaut.Pensja)
        {
            Klub klub = skaut.Klub;
            klub.UsunPracownika(skaut);
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
            klub.DodajPracownika(this);
        }

        public Dyrektor(GlownySkaut glownySkaut, List<TypDyrektora> stanowiska) : base(glownySkaut.Klub, glownySkaut.Imie, glownySkaut.Nazwisko, glownySkaut.DataUrodzenia, glownySkaut.DataZatrudnienia, glownySkaut.Pensja)
        {
            Klub klub = glownySkaut.Klub;
            klub.UsunGlownegoSkauta(glownySkaut);
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
            klub.DodajPracownika(this);
        }

        public Dyrektor(Prezes prezes, List<TypDyrektora> stanowiska) : base(prezes.Klub, prezes.Imie, prezes.Nazwisko, prezes.DataUrodzenia, prezes.DataZatrudnienia, prezes.Pensja)
        {
            Klub klub = prezes.Klub;
            klub.UsunPrezesa(prezes);
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
            klub.DodajPracownika(this);
        }


        public void WydajOpinie(Zawodnik zawodnik, Opinia opinia)
        {
            if (zawodnik.Status == "ZawieszenieObserwacji")
            {
                throw new Exception("Nie możesz wydać opinii dla tego zawodnika");
            }

            zawodnik.Opinia = opinia.ToString();
        }
        public Kosztorys StworzKosztorys(Zawodnik zawodnik, double szacowanaCena, double szacowanaPensja)
        {
            if(!DyrektorSportowy)
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
