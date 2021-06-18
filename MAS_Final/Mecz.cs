﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MAS_Final
{
    [Serializable]
    public class Mecz
    {
        private static int idOstatniMecz = 0;

        private int idMecz;
        public int IdMecz
        {
            get
            {
                return idMecz;
            }
            set
            {
                idMecz = value;
            }
        }

        private DateTime dataRozegrania;
        public DateTime DataRozegrania
        {
            get
            {
                return dataRozegrania;
            }
            set
            {
                dataRozegrania = value;
            }
        }

        private string gospodarz;
        public string Gospodarz
        {
            get
            {
                return gospodarz;
            }
            set
            {
                gospodarz = value;
            }
        }

        private string gosc;
        public string Gosc
        {
            get
            {
                return gosc;
            }
            set
            {
                gosc = value;
            }
        }

        private string wynik;
        public string Wynik
        {
            get
            {
                return wynik;
            }
            set
            {
                wynik = value;
            }
        }

        private static List<Mecz> extent = new List<Mecz>();

        public static List<Mecz> Extent
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

        public Mecz(DateTime dataRozegrania, string gospodarz, string gosc, string wynik)
        {
            idOstatniMecz++;
            IdMecz = idOstatniMecz;
            DataRozegrania = dataRozegrania;
            Gospodarz = gospodarz;
            Gosc = gosc;
            Wynik = wynik;
            extent.Add(this);
        }
    }
}
