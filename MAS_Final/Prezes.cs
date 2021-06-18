using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
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

        public Prezes(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, DateTime poczatekKadencji) : base(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            PoczatekKadencji = poczatekKadencji;
            klub.DodajPrezesa(this);
        }

        public Prezes(GlownySkaut glownySkaut, DateTime poczatekKadencji) : base(glownySkaut.Klub, glownySkaut.Imie, glownySkaut.Nazwisko, glownySkaut.DataUrodzenia, glownySkaut.DataZatrudnienia, glownySkaut.Pensja)
        {
            Klub klub = glownySkaut.Klub;
            klub.UsunGlownegoSkauta(glownySkaut);
            PoczatekKadencji = poczatekKadencji;
            klub.DodajPrezesa(this);
        }

        public Prezes(Skaut skaut, DateTime poczatekKadencji) : base(skaut.Klub, skaut.Imie, skaut.Nazwisko, skaut.DataUrodzenia, skaut.DataZatrudnienia, skaut.Pensja)
        {
            Klub klub = skaut.Klub;
            klub.UsunPracownika(skaut);
            Skaut.Extent.Remove(skaut);
            PoczatekKadencji = poczatekKadencji;
            klub.DodajPrezesa(this);
        }

        public Prezes(Dyrektor dyrektor, DateTime poczatekKadencji) : base(dyrektor.Klub, dyrektor.Imie, dyrektor.Nazwisko, dyrektor.DataUrodzenia, dyrektor.DataZatrudnienia, dyrektor.Pensja)
        {
            Klub klub = dyrektor.Klub;
            klub.UsunPracownika(dyrektor);
            Dyrektor.Extent.Remove(dyrektor);
            PoczatekKadencji = poczatekKadencji;
            klub.DodajPrezesa(this);
        }

        public GlownySkaut AwansujSkauta(Skaut skaut)
        {
            GlownySkaut glownySkaut = new GlownySkaut(skaut, this, DateTime.Now);
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
