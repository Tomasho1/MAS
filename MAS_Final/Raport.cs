using System;
using System.Collections.Generic;

namespace MAS_Final
{
    [Serializable]
    public class Raport
    {
        private static int idOstatniRaport = 0;
        private int idRaport;
        public int IdRaport
        {
            get
            {
                return idRaport;
            }
            set
            {
                idRaport = value;
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

        private Mecz mecz;

        public Mecz Mecz 
        {
            get
            {
                return mecz;
            }
            set
            {
                mecz = value;
            }
        }

        private string komentarz;
        public string Komentarz
        {
            get
            {
                return komentarz;
            }
            set
            {
                komentarz = value;
            }
        }

        private Skaut skaut;

        public Skaut Skaut
        {
            get
            {
                return skaut;
            }
            set
            {
                skaut = value;
            }
        }

        private static List<Raport> extent = new List<Raport>();

        public static List<Raport> Extent
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

        public Raport(Skaut skaut, Zawodnik zawodnik, Mecz mecz, string komentarz)
        {
            idOstatniRaport++;
            IdRaport = idOstatniRaport;
            Zawodnik = zawodnik;
            Skaut = skaut;
            Mecz = mecz;
            Komentarz = komentarz;
            zawodnik.DodajRaport(skaut, this);
            skaut.DodajRaport(zawodnik, this);
        }
    }
}