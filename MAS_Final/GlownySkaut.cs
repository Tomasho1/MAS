using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    class GlownySkaut : Pracownik
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
        public GlownySkaut(String imie, String nazwisko, DateTime dataUrodzenia, DateTime dataZatrudnienia, double pensja, Prezes prezes, DateTime dataPromocji) : base(imie, nazwisko, dataUrodzenia, dataZatrudnienia, pensja)
        {
            this.Prezes = prezes;
            this.dataPromocji = dataPromocji;
        }

        public GlownySkaut(Pracownik pracownik, Prezes prezes, DateTime dataPromocji) : base(pracownik.Imie, pracownik.Nazwisko, pracownik.DataUrodzenia, pracownik.DataZatrudnienia, pracownik.Pensja)
        {
            this.Prezes = prezes;
            this.dataPromocji = dataPromocji;
        }
    }
}
