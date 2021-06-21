using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    [Serializable]

    // <summary>
    // Klasa reprezentująca głównego skauta, czyli jednego ze skautów mianowanego przez prezesa
    // <summary>
    public class GlownySkaut : Pracownik
    {
        private Prezes prezes;
        public Prezes Prezes
        {
            get
            {
                return prezes;
            }
            set
            {
                prezes = value;
            }
        }

        private DateTime dataPromocji;
        public DateTime DataPromocji
        {
            get
            {
                return dataPromocji;
            }
            set
            {
                //Data musi być wcześniejsza niż obecna, ale nie może być wcześniejsza od daty zatrudnienia 
                if (value > DateTime.Now || value < DataZatrudnienia)
                {
                    throw new Exception("Wprowadzono nieprawidłową datę");
                }
                dataPromocji = value;
            }
        }

        private GlownySkaut(Skaut skaut, Pracownik prezes, DateTime dataPromocji, double nowaPensja) : base(skaut.Klub, skaut.Imie, skaut.Nazwisko, skaut.Narodowosc, skaut.DataUrodzenia, skaut.DataZatrudnienia, nowaPensja)
        {
                Klub klub = skaut.Klub;
                klub.UsunPracownika(skaut);
                Skaut.Extent.Remove(skaut);
                Prezes = (Prezes)prezes;
                DataPromocji = dataPromocji;
        }

        //Promocja skauta na głównego skauta 
        public static GlownySkaut DodajGlownegoSkauta(Skaut skaut, Pracownik prezes, DateTime dataPromocji, double nowaPensja)
        {
            Klub klub = skaut.Klub;
            GlownySkaut glownySkaut = new GlownySkaut(skaut, prezes, dataPromocji, nowaPensja);
            klub.DodajPracownika(glownySkaut);
            klub.DodajGlownegoSkauta(glownySkaut);
            return glownySkaut;
        }

        //Zmiana statusu zawodnika
        public void ZmienStatusZawodnika(Zawodnik zawodnik, StatusZawodnika status)
        {
            //Zmiana statusu zawodnika może nastąpić tylko wtedy, gdy posiada on domyślny status lub został skierowany do dalszej obserwacji
            if (zawodnik.Status == Helper.GetEnumDescription(StatusZawodnika.PoObserwacji) || zawodnik.Status == Helper.GetEnumDescription(StatusZawodnika.DoDalszejObserwacji))
            {
                zawodnik.Status = Helper.GetEnumDescription(status);
            }
            else throw new Exception("Nie możesz zmienić statusu tego zawodnika");
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                GlownySkaut GlownySkaut = (GlownySkaut)obj;

                if (Klub == GlownySkaut.Klub && Imie == GlownySkaut.Imie && Nazwisko == GlownySkaut.Nazwisko && Narodowosc == GlownySkaut.Narodowosc && DataUrodzenia == GlownySkaut.DataUrodzenia && DataZatrudnienia == GlownySkaut.DataZatrudnienia && Pensja == GlownySkaut.Pensja && DataPromocji == GlownySkaut.DataPromocji && Prezes.Equals(GlownySkaut.Prezes))
                {
                    return true;
                }
                else return false;
            }
        }
        public override int GetHashCode()
        {
            return new { Klub, Imie, Nazwisko, Narodowosc, DataUrodzenia, DataZatrudnienia, Pensja, DataPromocji, Prezes}.GetHashCode();
        }
    }
}
