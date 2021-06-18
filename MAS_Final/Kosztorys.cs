using System;
using System.Collections.Generic;

namespace MAS_Final
{
    [Serializable]
    public class Kosztorys
    {

        private static int idOstatniKosztorys = 0;

        private int idKosztorys;
        public int IdKosztorys
        {
            get
            {
                return idKosztorys;
            }
            set
            {
                idKosztorys = value;
            }
        }

        private double szacowanaCena;
        public double SzacowanaCena
        {
            get
            {
                return szacowanaCena;
            }
            set
            {
                szacowanaCena = value;
            }
        }

        private double szacowanaPensja;
        public double SzacowanaPensja
        {
            get
            {
                return szacowanaPensja;
            }
            set
            {
                szacowanaPensja = value;
            }
        }

        private Zawodnik zawodnik;

        public Zawodnik Zawodnik
        {
            get
            {
                return zawodnik;
            }
            set
            {
                zawodnik = value;
            }
        }

        private Dyrektor dyrektor;

        public Dyrektor Dyrektor
        {
            get
            {
                return dyrektor;
            }
            set
            {
                dyrektor = value;
            }
        }

        private static List<Kosztorys> extent = new List<Kosztorys>();
        public static List<Kosztorys> Extent
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

        public Kosztorys(Dyrektor dyrektor, Zawodnik zawodnik, double szacowanaCena, double szacowanaPensja)
        {
            idOstatniKosztorys++;
            IdKosztorys = idOstatniKosztorys;
            Dyrektor = dyrektor;
            Zawodnik = zawodnik;
            SzacowanaCena = szacowanaCena;
            SzacowanaPensja = szacowanaPensja;
            extent.Add(this);
            zawodnik.Kosztorys = this;
        }
    }
}