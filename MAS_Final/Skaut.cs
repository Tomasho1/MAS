using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAS_Final
{
    [Serializable]

    // <summary>
    // Klasa reprezentująca obiekt decyzji podejmowanej przez prezesa w sprawie konkretnego zawodnika
    // <summary>
    public class Skaut : Pracownik
    {
        //Lista przechowująca regiony, którymi zajmuje się skaut. Regionem może być państwo lub kontynent. 
        private List<String> regiony;
        public List<String> Regiony
        {
            get 
            {
                return regiony;
            }

            set
            {
                regiony = value;
            }
        }

        //Lista klucz-wartość przechowująca raporty przygotowane przez skauta
        private List<KeyValuePair<Zawodnik, Raport>> raporty = new List<KeyValuePair<Zawodnik, Raport>>();
        public List<KeyValuePair<Zawodnik, Raport>> Raporty
        {
            get
            {
                return raporty;
            }

            set
            {
                raporty = value;
            }

        }

        //Statyczna lista przechowująca wszystkie obiekty klasy
        private static List<Skaut> extent = new List<Skaut>();
        public static List<Skaut> Extent
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

        private Skaut(Klub klub, String imie, String nazwisko, String narodowosc, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<String> regiony) : base(klub, imie, nazwisko, narodowosc, dataUrodzenia, dataZatrudnienia, pensja)
        {
            Regiony = regiony;
            extent.Add(this);
        }

        private Skaut(Pracownik pracownik, List<String> regiony, double nowaPensja) : base(pracownik.Klub, pracownik.Imie, pracownik.Nazwisko, pracownik.Narodowosc, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, nowaPensja)
        {
            Type typ = typeof(Pracownik);
            Klub klub = pracownik.Klub;
            Regiony = regiony;

            if (typ == typeof(GlownySkaut))
            {
                klub.UsunGlownegoSkauta((GlownySkaut)pracownik);
            }

            if (typ == typeof(Dyrektor))
            {
                klub.UsunPracownika(pracownik);
                Dyrektor.Extent.Remove((Dyrektor)pracownik);
            }

            if(typ == typeof(Prezes))
            {
                klub.UsunPrezesa((Prezes)pracownik);
            }

            extent.Add(this);
        }

        //Stworzenie skauta od zera
        public static Skaut DodajSkauta(Klub klub, String imie, String nazwisko, String narodowosc, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<String> regiony)
        {
            if (klub == null)
            {
                throw new Exception("Nie ma takiego klubu");
            }

            Skaut skaut = new Skaut(klub, imie, nazwisko, narodowosc, dataUrodzenia, dataZatrudnienia, pensja, regiony);
            klub.DodajPracownika(skaut);
            return skaut;
        }

        //Stworzenie skauta na podstawie istniejącego obiektu
        public static Skaut DodajSkauta(Pracownik pracownik, List<String> regiony, double nowaPensja)
        {
            Klub klub = pracownik.Klub;
            Skaut skaut = new Skaut(pracownik, regiony, nowaPensja);
            klub.DodajPracownika(skaut);
            return skaut;
        }

        //Dodanie raportu do listy
        public void DodajRaport(Zawodnik zawodnik, Raport raport)
        {
            raporty.Add(new KeyValuePair<Zawodnik, Raport>(zawodnik, raport));
        }

        //Stworzenie raportu
        public Raport StworzRaport(Zawodnik zawodnik, Mecz mecz, String komentarz)
        {
            Raport raport = new Raport(this, zawodnik, mecz, komentarz);
            return raport;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Skaut skaut = (Skaut)obj;

                if (Klub == skaut.Klub && Imie == skaut.Imie && Nazwisko == skaut.Nazwisko && Narodowosc == skaut.Narodowosc && DataUrodzenia == skaut.DataUrodzenia && DataZatrudnienia == skaut.DataZatrudnienia && Pensja == skaut.Pensja && Regiony.SequenceEqual(skaut.Regiony))
                {
                    return true;
                }
                else return false;
            }
        }
        public override int GetHashCode()
        {
            return new {Klub, Imie, Nazwisko, Narodowosc, DataUrodzenia, DataZatrudnienia, Pensja, Regiony}.GetHashCode();
        }
    }
}
