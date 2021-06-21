using System;
using System.Collections.Generic;

namespace MAS_Final
{
    [Serializable]

    // <summary>
    // Klasa reprezentująca kosztorys tworzony dla konkretnego zawodnika przez dyrektora sportowego
    // <summary>
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
                //Wartość musi być większa od zera
                if(value <= 0)
                {
                    throw new Exception("Wprowadzono nieprawidłową wartość");
                }
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
                //Wartość musi być większa od zera
                if (value <= 0)
                {
                    throw new Exception("Wprowadzono nieprawidłową wartość");
                }
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

        //Statyczna lista przechowująca wszystkie obiekty klasy
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