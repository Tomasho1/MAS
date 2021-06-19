using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    [Serializable]
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
                poczatekKadencji = value;
            }
        }

        private DateTime koniecKadencji;

        public DateTime KoniecKadencji
        {
            get
            {
                return poczatekKadencji.AddYears(base.Klub.DlugoscKadencjiPrezesa);
            }
        }

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

        private Prezes(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, DateTime poczatekKadencji) : base(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            PoczatekKadencji = poczatekKadencji;
        }

        private Prezes(Pracownik pracownik, DateTime poczatekKadencji) : base(pracownik.Klub, pracownik.Imie, pracownik.Nazwisko, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, pracownik.Pensja)
        {
            Type typ = typeof(Pracownik);
            Klub klub = pracownik.Klub;
            PoczatekKadencji = poczatekKadencji;

            if (typ == typeof(GlownySkaut))
            {
                klub.UsunGlownegoSkauta((GlownySkaut)pracownik);
            }

            if(typ == typeof(Skaut))
            {
                klub.UsunPracownika(pracownik);
                Skaut.Extent.Remove((Skaut)pracownik);
            }

            if(typ == typeof(Dyrektor))
            {
                klub.UsunPracownika(pracownik);
                Dyrektor.Extent.Remove((Dyrektor)pracownik);
            }
        }

        public static Prezes DodajPrezesa(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, DateTime poczatekKadencji)
        {
            if(klub == null)
            {
                throw new Exception("Nie ma takiego kluub");
            }

            Prezes prezes = new Prezes(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja, poczatekKadencji);
            klub.DodajPracownika(prezes);
            klub.DodajPrezesa(prezes);
            return prezes;
        }

        public static Prezes DodajPrezesa(Pracownik pracownik, DateTime poczatekKadencji)
        {
            Klub klub = pracownik.Klub;
            Prezes prezes = new Prezes(pracownik, poczatekKadencji);
            klub.DodajPracownika(prezes);
            klub.DodajPrezesa(prezes);
            return prezes;
        }

        public GlownySkaut AwansujSkauta(Skaut skaut, double pensja)
        {
            GlownySkaut glownySkaut = GlownySkaut.DodajGlownegoSkauta(skaut, this, DateTime.Now, pensja);
            return glownySkaut;
        }

        public Decyzja PodejmijDecyzje(Zawodnik zawodnik, TypDecyzji typ, String komentarz)
        {
            if (zawodnik.Kosztorys == null)
            {
                throw new Exception("Nnie sporządzono kosztorysu dla tego zawodnika");
            }
            Decyzja decyzja = new Decyzja(this, zawodnik, typ, komentarz);
            return decyzja;
        }
    }
}
