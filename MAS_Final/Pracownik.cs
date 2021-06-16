using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    public abstract class Pracownik
    {
        private static int idOstatniPracownik = 0;

        private int idPracownik;
        public int IdPracownik
        {
            get
            {
                return idPracownik;
            }
            set
            {
                idPracownik = value;
            }
        }

        private Klub? klub;
        public Klub? Klub
        {
            get
            {
                return klub;
            }
            set
            {
                if (this.klub != null)
                {
                    klub.UsunPracownika(this);
                }
                this.klub = value;
                value.DodajPracownika(this);
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

        private DateTime dataZatrudnienia;
        public DateTime DataZatrudnienia
        {
            get
            {
                return dataZatrudnienia;
            }
            set
            {
                dataZatrudnienia = value;
            }
        }

        private int stazWKlubie;
        public int StazWKlubie
        {
            get
            {
                DateTime now = DateTime.Today;
                stazWKlubie = now.Year - this.DataUrodzenia.Year;
                if (now < DataUrodzenia.AddYears(stazWKlubie))
                {
                    stazWKlubie--;
                }
                return stazWKlubie;
            }
        }

        private double pensja;
        public double Pensja
        {
            get
            {
                return pensja;
            }
            set
            {
                pensja = value;
            }
        }

        public Pracownik(String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja)
        {
            idOstatniPracownik++;
            IdPracownik = idOstatniPracownik;
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
            DataZatrudnienia = dataZatrudnienia;
            Pensja = pensja;
        }
    }
}
