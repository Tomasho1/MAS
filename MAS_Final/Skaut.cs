using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    [Serializable]
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

        private List<KeyValuePair<Skaut, Raport>> raporty = new List<KeyValuePair<Skaut, Raport>>();
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

        public Skaut(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<String> regiony) : base(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            Regiony = regiony;
            extent.Add(this);
            klub.DodajPracownika(this);
        }

        public Skaut(GlownySkaut glownySkaut, List<String> regiony) : base(glownySkaut.Klub, glownySkaut.Imie, glownySkaut.Nazwisko, glownySkaut.DataUrodzenia, glownySkaut.DataZatrudnienia, glownySkaut.Pensja)
        {
            Klub klub = glownySkaut.Klub;
            klub.UsunGlownegoSkauta(glownySkaut);
            Regiony = regiony;
            extent.Add(this);
            klub.DodajPracownika(this);
        }

        public Skaut(Prezes prezes, List<String> regiony) : base(prezes.Klub, prezes.Imie, prezes.Nazwisko, prezes.DataUrodzenia, prezes.DataZatrudnienia, prezes.Pensja)
        {
            Klub klub = prezes.Klub;
            klub.UsunPrezesa(prezes);
            Regiony = regiony;
            extent.Add(this);
            klub.DodajPracownika(this);
        }

        public Skaut(Dyrektor dyrektor, List<String> regiony) : base(dyrektor.Klub, dyrektor.Imie, dyrektor.Nazwisko, dyrektor.DataUrodzenia, dyrektor.DataZatrudnienia, dyrektor.Pensja)
        {
            Klub klub = dyrektor.Klub; 
            klub.UsunPracownika(dyrektor);
            Regiony = regiony;
            Dyrektor.Extent.Remove(dyrektor);
            extent.Add(this);
            klub.DodajPracownika(this);
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
