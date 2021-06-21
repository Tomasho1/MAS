using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MAS_Final
{
    //Enum przechowujący możliwe wartości dla właściwości Typ
    public enum TypDecyzji
    {
        [Description("Zgoda na transfer")] Zgoda,
        [Description("Odrzucenie transferu")] Odrzucenie
    }
    [Serializable]

    // <summary>
    // Klasa reprezentująca decyzję podejmowaną przez prezesa w sprawie konkretnego zawodnika
    // <summary>
    public class Decyzja
    {
        private static int idOstatniaDecyzja = 0;

        private int idDecyzja;
        public int IdDecyzja
        {
            get
            {
                return idDecyzja;
            }
            set
            {
                idDecyzja = value;
            }
        }

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


        private String typ;
        public String Typ
        {
            get
            {
                return typ;
            }
            set
            {
                typ = value;
            }
        }

        private String komentarz;
        public String Komentarz
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

        //Statyczna lista przechowująca wszystkie obiekty klasy
        private static List<Decyzja> extent = new List<Decyzja>();
        public static List<Decyzja> Extent
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

        public Decyzja(Prezes prezes, Zawodnik zawodnik, TypDecyzji typ, String komentarz)
        {
            idOstatniaDecyzja++;
            IdDecyzja = idOstatniaDecyzja;
            Prezes = prezes;
            Zawodnik = zawodnik;
            Typ = Helper.GetEnumDescription(typ);
            Komentarz = komentarz;
            extent.Add(this);
        }
    }
}
