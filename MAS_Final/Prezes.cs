using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    [Serializable]

    // <summary>
    // Klasa reprezentująca prezesa klubu
    // <summary>
    public class Prezes : Pracownik
    {
        private DateTime poczatekKadencji;
        public DateTime PoczatekKadencji
        {
            get
            {
                return poczatekKadencji;
            }
            set
            {
                //Data musi być wcześniejsza niż obecna
                if (value > DateTime.Now)
                {
                    throw new Exception("Wprowadzono nieprawidłową datę");
                }
                poczatekKadencji = value;
            }
        }

        //Obliczenie końca kadencjina podstawie daty rozpoczęcia kadencji i długości kadencji prezesa w klubie
        private DateTime koniecKadencji;
        public DateTime KoniecKadencji
        {
            get
            {
                return poczatekKadencji.AddYears(base.Klub.DlugoscKadencjiPrezesa);
            }
        }

        //Lista przechowująca wszystkie decyzje w sprawie transferów zawodników podjęte przez prezesa 
        private List<Decyzja> decyzje;
        public List<Decyzja> Decyzje
        {
            get
            {
                return decyzje;
            }
            set
            {
                decyzje = value;
            }
        }

        private Prezes(Klub klub, String imie, String nazwisko, String narodowosc, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, DateTime poczatekKadencji) : base(klub, imie, nazwisko, narodowosc, dataUrodzenia, dataZatrudnienia, pensja)
        {
            PoczatekKadencji = poczatekKadencji;
        }

        private Prezes(Pracownik pracownik, DateTime poczatekKadencji, double nowaPensja) : base(pracownik.Klub, pracownik.Imie, pracownik.Nazwisko, pracownik.Narodowosc, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, nowaPensja)
        {
            Type typ = typeof(Pracownik);
            Klub klub = pracownik.Klub;
            PoczatekKadencji = poczatekKadencji;

            if (typ == typeof(GlownySkaut))
            {
                klub.UsunGlownegoSkauta((GlownySkaut)pracownik);
            }

            if (typ == typeof(Skaut))
            {
                klub.UsunPracownika(pracownik);
                Skaut.Extent.Remove((Skaut)pracownik);
            }

            if (typ == typeof(Dyrektor))
            {
                klub.UsunPracownika(pracownik);
                Dyrektor.Extent.Remove((Dyrektor)pracownik);
            }
        }

        //Stworzenie prezesa od zera
        public static Prezes DodajPrezesa(Klub klub, String imie, String nazwisko, String narodowosc, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, DateTime poczatekKadencji)
        {
            if (klub == null)
            {
                throw new Exception("Nie ma takiego kluub");
            }

            Prezes prezes = new Prezes(klub, imie, nazwisko, narodowosc, dataUrodzenia, dataZatrudnienia, pensja, poczatekKadencji);
            klub.DodajPrezesa(prezes);
            klub.DodajPracownika(prezes);
            return prezes;
        }

        //Stworzenie prezesa na podstawie istniejącego obiektu
        public static Prezes DodajPrezesa(Pracownik pracownik, DateTime poczatekKadencji, double nowaPensja)
        {
            Klub klub = pracownik.Klub;
            Prezes prezes = new Prezes(pracownik, poczatekKadencji, nowaPensja);
            klub.DodajPracownika(prezes);
            klub.DodajPrezesa(prezes);
            return prezes;
        }

        //Promocja skauta na głównego skauta
        public GlownySkaut AwansujSkauta(Skaut skaut, double pensja)
        {
            GlownySkaut glownySkaut = GlownySkaut.DodajGlownegoSkauta(skaut, this, DateTime.Now, pensja);
            return glownySkaut;
        }

        //Podjęcie decyzji w sprawie zawodnika
        public Decyzja PodejmijDecyzje(Zawodnik zawodnik, TypDecyzji typ, String komentarz)
        {
            //Decyzję można podjąć, jeśli wcześniej stworzono kosztorys
            if (zawodnik.Kosztorys == null)
            {
                throw new Exception("Nnie sporządzono kosztorysu dla tego zawodnika");
            }
            Decyzja decyzja = new Decyzja(this, zawodnik, typ, komentarz);
            return decyzja;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Prezes prezes = (Prezes)obj;

                if (Klub == prezes.Klub && Imie == prezes.Imie && Nazwisko == prezes.Nazwisko && Narodowosc == prezes.Narodowosc && DataUrodzenia == prezes.DataUrodzenia && DataZatrudnienia == prezes.DataZatrudnienia && Pensja == prezes.Pensja && PoczatekKadencji == prezes.PoczatekKadencji)
                {
                    return true;
                }
                else return false;
            }
        }
        public override int GetHashCode()
        {
            return new {Klub, Imie, Nazwisko, Narodowosc, DataUrodzenia, DataZatrudnienia, Pensja, PoczatekKadencji }.GetHashCode();
        }
    }
}

