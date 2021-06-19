using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    [Serializable]
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
                dataPromocji = value;
            }
        }

        private GlownySkaut(Skaut skaut, Pracownik prezes, DateTime dataPromocji, double nowaPensja) : base(skaut.Klub, skaut.Imie, skaut.Nazwisko, skaut.DataUrodzenia, skaut.DataZatrudnienia, nowaPensja)
        {
                Klub klub = skaut.Klub;
                klub.UsunPracownika(skaut);
                Skaut.Extent.Remove(skaut);
                Prezes = (Prezes)prezes;
                DataPromocji = dataPromocji;
        }

        public static GlownySkaut DodajGlownegoSkauta(Skaut skaut, Pracownik prezes, DateTime dataPromocji, double nowaPensja)
        {
            Klub klub = skaut.Klub;
            GlownySkaut glownySkaut = new GlownySkaut(skaut, prezes, dataPromocji, nowaPensja);
            klub.DodajPracownika(glownySkaut);
            klub.DodajGlownegoSkauta(glownySkaut);
            return glownySkaut;
        }

        public void ZmienStatusZawodnika(Zawodnik zawodnik, StatusZawodnika status)
        {
            if (zawodnik.Status != Helper.GetEnumDescription(StatusZawodnika.PoObserwacji))
            {
                throw new Exception("Nie możesz zmienić statusu tego zawodnika");
            }
            zawodnik.Status = Helper.GetEnumDescription(status);
        }
    }
}
