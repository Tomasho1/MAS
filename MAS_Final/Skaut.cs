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

        private Skaut(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<String> regiony) : base(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            Regiony = regiony;
            extent.Add(this);
        }

        private Skaut(Pracownik pracownik, List<String> regiony) : base(pracownik.Klub, pracownik.Imie, pracownik.Nazwisko, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, pracownik.Pensja)
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

        public static Skaut DodajSkauta(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, List<String> regiony)
        {
            if (klub == null)
            {
                throw new Exception("Nie ma takiego klubu");
            }

            Skaut skaut = new Skaut(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja, regiony);
            klub.DodajPracownika(skaut);
            return skaut;
        }

        public static Skaut DodajSkauta(Pracownik pracownik, List<String> regiony)
        {
            Klub klub = pracownik.Klub;
            Skaut skaut = new Skaut(pracownik, regiony);
            klub.DodajPracownika(skaut);
            return skaut;
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

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Skaut pracownik = (Skaut)obj;

                if (Imie == pracownik.Imie && Nazwisko == pracownik.Nazwisko && Narodowosc == pracownik.Narodowosc && DataUrodzenia == pracownik.DataUrodzenia && DataZatrudnienia == pracownik.DataZatrudnienia && DataOdejscia == pracownik.DataOdejscia && Pensja == pracownik.Pensja && Regiony == pracownik.Regiony)
                {
                    return true;
                }
                else return false;
            }
        }
        public override int GetHashCode()
        {
            return new { Imie, Nazwisko, Narodowosc, DataUrodzenia, DataZatrudnienia, DataOdejscia, Pensja, Regiony}.GetHashCode();
        }
    }
}
