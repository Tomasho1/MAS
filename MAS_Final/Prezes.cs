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

        public Prezes(String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, DateTime poczatekKadencji) : base(imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            this.PoczatekKadencji = poczatekKadencji;
        }

        public Prezes(Pracownik pracownik, DateTime poczatekKadencji) : base(pracownik.Imie, pracownik.Nazwisko, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, pracownik.Pensja)
        {
            this.PoczatekKadencji = poczatekKadencji;
        }

        public void AwansujSkauta(Skaut skaut)
        {

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
