using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MAS_Final
{
    //Enum przechowujący możliwe wartości dla właściwości Typ
    public enum TypDyrektora {
        [Description("Sportowy")] Sportowy,
        [Description("ds. Transferów")] Transferowy
    }

    [Serializable]

    // <summary>
    // Klasa realizująca dziedziczenie overlapping pomiędzy Dyrektorem Sportowym i Dyrektorem ds. Transferów
    // <summary>
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
        //Lista przechowująca wszystkie kosztorysy stworzone przez dyrektora
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

        //Statyczna lista przechowująca wszystkie obiekty klasy
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
        private Dyrektor(Klub klub, String imie, String nazwisko, String narodowosc, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<TypDyrektora> stanowiska) : base(klub, imie, nazwisko, narodowosc, dataUrodzenia, dataZatrudnienia, pensja)
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

        private Dyrektor(Pracownik pracownik, List<TypDyrektora> stanowiska, double nowaPensja) : base(pracownik.Klub, pracownik.Imie, pracownik.Nazwisko, pracownik.Narodowosc, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, nowaPensja)
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

        //Stworzenie dyrektora od zera
        public static Dyrektor DodajDyrektora(Klub klub, String imie, String nazwisko, String narodowosc, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<TypDyrektora> stanowiska)
        {
            if (klub == null)
            {
                throw new Exception("Nie ma takiego klubu");
            }

            Dyrektor dyrektor = new Dyrektor(klub, imie, nazwisko, narodowosc, dataUrodzenia, dataZatrudnienia, pensja, stanowiska);
            klub.DodajPracownika(dyrektor);
            return dyrektor;
        }
        //Stworzenie dyrektora na podstawie istniejącego obiektu
        public static Dyrektor DodajDyrektora(Pracownik pracownik, List<TypDyrektora> stanowiska, double nowaPensja)
        {
            Klub klub = pracownik.Klub;
            Dyrektor dyrektor = new Dyrektor(pracownik, stanowiska, nowaPensja);
            klub.DodajPracownika(dyrektor);
            return dyrektor;
        }

        //Wydanie opinii na temat konkretnego zawodnika
        public void WydajOpinie(Zawodnik zawodnik, Opinia opinia)
        {
            //Opinię można wydać tylko dla zawodników zarekomendowanych przez głównego skauta
            if (zawodnik.Status == Helper.GetEnumDescription(StatusZawodnika.Zarekomendowany))
            {
                zawodnik.Opinia = Helper.GetEnumDescription(opinia);
            }

            else throw new Exception("Nie możesz wydać opinii dla tego zawodnika");      
        }

        public Kosztorys StworzKosztorys(Zawodnik zawodnik, double szacowanaCena, double szacowanaPensja)
        {
            //Tylko dyrektor sportowy ma prawo stworzyć kosztorys
            if(!DyrektorSportowy)
            {
                throw new Exception("Tylko dyrektor sportowy może tworzyć kosztorys");
            }
            //Kosztorys dla zawodnika jest tworzony po wydaniu pozytywnej opinii przez dyrektora ds. transferów
            if (zawodnik.Opinia != Helper.GetEnumDescription(Opinia.Pozytywna))
            {
                throw new Exception("Zawodnik nie otrzymał pozytywnej opinii dyrektora ds. transferów");
            }

            Kosztorys kosztorys = new Kosztorys(this, zawodnik, szacowanaCena, szacowanaPensja);
            return kosztorys;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Dyrektor dyrektor = (Dyrektor)obj;

                if (Klub == dyrektor.Klub && Imie == dyrektor.Imie && Nazwisko == dyrektor.Nazwisko && Narodowosc == dyrektor.Narodowosc && DataUrodzenia == dyrektor.DataUrodzenia && DataZatrudnienia == dyrektor.DataZatrudnienia && Pensja == dyrektor.Pensja && DyrektorSportowy == dyrektor.DyrektorSportowy && DyrektorTransferowy == dyrektor.DyrektorTransferowy)
                {
                    return true;
                }
                else return false;
            }
        }
        public override int GetHashCode()
        {
            return new { Klub, Imie, Nazwisko, Narodowosc, DataUrodzenia, DataZatrudnienia, Pensja, DyrektorSportowy, DyrektorTransferowy}.GetHashCode();
        }
    }
}

