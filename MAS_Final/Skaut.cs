using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    public class Skaut : Pracownik
    {
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

        private List<KeyValuePair<Skaut, Raport>> raporty;
        public List<KeyValuePair<Skaut, Raport>> Raporty
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

        public Skaut(String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<String> regiony) : base(imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            this.Regiony = regiony;
        }

        public Skaut(Pracownik pracownik, List<String> Regiony) : base(pracownik.Imie, pracownik.Nazwisko, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, pracownik.Pensja)
        {
            this.Regiony = regiony;
        }
        public void DodajRaport(Skaut skaut, Raport raport)
        {
            raporty.Add(new KeyValuePair<Skaut, Raport>(skaut, raport));
        }

        public Raport StworzRaport(Zawodnik zawodnik, Mecz mecz, String komentarz)
        {
            Raport raport = new Raport(this, zawodnik, mecz, komentarz);
            return raport;
        }
    }
    }
