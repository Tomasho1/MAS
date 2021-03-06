using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    [Serializable]

    // <summary>
    // Klasa reprezentująca abstrakcję pracownika
    // <summary>
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

        private Klub klub;
        public Klub Klub
        {
            get
            {
                return klub;
            }
            set
            {
                klub = value;
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
                //Data musi być wcześniejsza niż obecna
                if(value > DateTime.Now)
                {
                    throw new Exception("Wprowadzono nieprawidłową datę");
                }
                dataUrodzenia = value;
            }
        }

        //Obliczenie wieku na podstawie daty urodzenia
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
                //Data musi być wcześniejsza niż obecna
                if (value > DateTime.Now)
                {
                    throw new Exception("Wprowadzono nieprawidłową datę");
                }
                dataZatrudnienia = value;
            }
        }

        //Obliczenie stażu w klubie na podstawie daty zatrudnienia 
        private int stazWKlubie;
        public int StazWKlubie
        {
            get
            {
                DateTime now = DateTime.Today;
                stazWKlubie = now.Year - DataZatrudnienia.Year;
                    if (now < DataZatrudnienia.AddYears(stazWKlubie))
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

        public Pracownik(Klub klub, String imie, String nazwisko, String narodowosc, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja)
        {
            idOstatniPracownik++;
            IdPracownik = idOstatniPracownik;
            Klub = klub;
            Imie = imie;
            Nazwisko = nazwisko;
            Narodowosc = narodowosc;
            DataUrodzenia = dataUrodzenia;
            DataZatrudnienia = dataZatrudnienia;
            Pensja = pensja;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Pracownik pracownik = (Pracownik)obj;

                if (Klub == pracownik.Klub && Imie == pracownik.Imie && Nazwisko == pracownik.Nazwisko && Narodowosc == pracownik.Narodowosc && DataUrodzenia == pracownik.DataUrodzenia && DataZatrudnienia == pracownik.DataZatrudnienia &&Pensja == pracownik.Pensja)
                {
                    return true;
                }
                else return false;
            }
        }
        public override int GetHashCode()
        {
            return new {Klub, Imie, Nazwisko, Narodowosc, DataUrodzenia, DataZatrudnienia, Pensja}.GetHashCode();
        }
    }
    }

