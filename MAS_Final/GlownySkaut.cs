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

        public GlownySkaut(Klub klub, String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, Prezes prezes, DateTime dataPromocji) : base(klub, imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            Prezes = prezes;
            DataPromocji = dataPromocji;
            klub.DodajGlownegoSkauta(this);
        }

        public GlownySkaut(Skaut skaut, Prezes prezes, DateTime dataPromocji) : base(skaut.Klub, skaut.Imie, skaut.Nazwisko, skaut.DataUrodzenia, skaut.DataZatrudnienia, skaut.Pensja)
        {
            Klub klub = skaut.Klub;
            klub.UsunPracownika(skaut);
            Skaut.Extent.Remove(skaut);
            Prezes = prezes;
            DataPromocji = dataPromocji;
            klub.DodajGlownegoSkauta(this);
        }

        public GlownySkaut(Prezes byly, Prezes prezes, DateTime dataPromocji) : base(prezes.Klub, prezes.Imie, prezes.Nazwisko, prezes.DataUrodzenia, prezes.DataZatrudnienia, prezes.Pensja)
        {
            Klub klub = byly.Klub;
            Prezes = prezes;
            DataPromocji = dataPromocji;
            klub.DodajGlownegoSkauta(this);
        }

        public GlownySkaut(Dyrektor dyrektor, Prezes prezes, DateTime dataPromocji) : base(dyrektor.Klub, dyrektor.Imie, dyrektor.Nazwisko, dyrektor.DataUrodzenia, dyrektor.DataZatrudnienia, dyrektor.Pensja)
        {
            Klub klub = dyrektor.Klub;
            klub.UsunPracownika(dyrektor);
            Dyrektor.Extent.Remove(dyrektor);
            Prezes = prezes;
            DataPromocji = dataPromocji;
            klub.DodajGlownegoSkauta(this);
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
