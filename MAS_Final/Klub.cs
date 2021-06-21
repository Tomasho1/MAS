using System;
using System.Collections.Generic;
using System.Reflection;

namespace MAS_Final
{
    [Serializable]

    // <summary>
    // Klasa reprezentująca klub zapisany do systemu
    // <summary>
    public class Klub
    {
        private static int idOstatniKlub = 0;

        private int idKlub;

        public int IdKlub
        {
            get
            {
                return idKlub;
            }
            set
            {
                idKlub = value;
            }
        }

        private string nazwa;
        public string Nazwa
        {
            get
            {
                return nazwa;
            }
            set
            {
                nazwa = value;
            }
        }


        private string krajPochodzenia;
        public string KrajPochodzenia
        {
            get
            {
                return krajPochodzenia;
            }
            set
            {
                krajPochodzenia = value;
            }
        }
        private string stadion;
        public string Stadion
        {
            get
            {
                return stadion;
            }
            set
            {
                stadion = value;
            }
        }

        private int rokZalozenia;

        public int RokZalozenia
        {
            get
            {
                return rokZalozenia;
            }
            set
            {
                //Rok założenia nie może być większy od aktualnego
                if (value > DateTime.Now.Year)
                {
                    throw new Exception("Wprowadzono nieprawidłowy rok");
                }
                rokZalozenia = value;
            }
        }

        private string aktualnyPoziomRozgrywkowy;
        public string AktualnyPoziomRozgrywkowy
        {
            get
            {
                return aktualnyPoziomRozgrywkowy;
            }
            set
            {
                aktualnyPoziomRozgrywkowy = value;
            }
        }

        private int dlugoscKadencjiPrezesa;

        public int DlugoscKadencjiPrezesa
        {
            get
            {
                return dlugoscKadencjiPrezesa;
            }
            set
            {
                dlugoscKadencjiPrezesa = value;
            }
        }

        private Prezes? prezes;
        public Prezes? Prezes
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

        private GlownySkaut? glownySkaut;
        public GlownySkaut? GlownySkaut
        {
            get
            {
                return glownySkaut;
            }
            set
            {
                glownySkaut = value;
            }
        }

        //Kolekcja przechowująca wszystkich pracowników we wszystkich klubach podpiętych do systemu
        private static HashSet<Pracownik> wszyscyPracownicy = new HashSet<Pracownik>();
        public HashSet<Pracownik> WszyscyPracownicy
        {
            get
            {
                return wszyscyPracownicy;
            }
            set
            {
                wszyscyPracownicy = value;
            }
        }

        //Lista przechowująca wszystkich pracowników w danym klubie
        private List<Pracownik> pracownicy = new List<Pracownik>();
        public List<Pracownik> Pracownicy
        {
            get
            {
                return pracownicy;
            }
            set
            {
                pracownicy = value;
            }
        }

        //Statyczna lista przechowująca wszystkie obiekty klasy
        private static List<Klub> extent = new List<Klub>();
        public static List<Klub> Extent
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

        public Klub(String nazwa, String krajPochodzenia, String stadion, int rokZalozenia, String aktualnyPoziomRozgrywkowy, int dlugoscKadencjiPrezesa)
        {
            idOstatniKlub++;
            IdKlub = idOstatniKlub;
            Nazwa = nazwa;
            KrajPochodzenia = krajPochodzenia;
            Stadion = stadion;
            RokZalozenia = rokZalozenia;
            AktualnyPoziomRozgrywkowy = aktualnyPoziomRozgrywkowy;
            DlugoscKadencjiPrezesa = dlugoscKadencjiPrezesa;
            extent.Add(this);
        }

        //Ustanowienie prezesa
        public void DodajPrezesa(Prezes prezes)
        {
            if (Prezes != null)
            {
                new Exception("Klub już ma prezesa");
            }

            if (Prezes != null && Prezes != prezes)
            {
                throw new Exception("Osoba już jest prezesem");
            }

            Prezes = prezes;
            Prezes.Klub = this;
        }

        //Usunięcie aktualnego prezesa ze stanowiska
        public void UsunPrezesa(Prezes prezes)
        {
            if (!Prezes.Equals(prezes))
            {
                throw new Exception("Osoba nie jest prezesem");
            }
            Prezes = null;
        }

        //Ustanowienie głównego skauta
        public void DodajGlownegoSkauta(GlownySkaut glownySkaut)
        {
            if (GlownySkaut == glownySkaut)
            {
                throw new Exception("Osoba już jest głównym skautem");
            }

            if (GlownySkaut != null)
            {
                throw new Exception("Klub już ma głównego skauta");
            }

            GlownySkaut = glownySkaut;
        }

        //Usunięcie aktualnego głównego skauta ze stanowiska
        public void UsunGlownegoSkauta(GlownySkaut glownySkaut)
        {
            if (GlownySkaut != glownySkaut)
            {
                throw new Exception("Osoba nie jest głównym skautem");
            }
            GlownySkaut = null;
        }

        //Zatrudnienie pracownika
        public void DodajPracownika(Pracownik pracownik)
        {
            if(pracownicy.Contains(pracownik))
            {
                throw new Exception("Pracownik już pracuje w tym klubie");
            }

            if (!pracownicy.Contains(pracownik))
            {
                if (wszyscyPracownicy.Contains(pracownik))
                {
                    throw new Exception("Pracownik pracuje już w innym klubie");
                }

                pracownicy.Add(pracownik);
                wszyscyPracownicy.Add(pracownik);
            }
        }

        //Zwolnienie pracownika
        public void UsunPracownika(Pracownik pracownik)
        {
            Type typ = typeof(Pracownik);

            if (!pracownicy.Contains(pracownik))
            {
                throw new Exception("Pracownik nie pracuje w tym klubie");
            }
            pracownicy.Remove(pracownik);
            wszyscyPracownicy.Remove(pracownik);

            if(typ == typeof(Dyrektor) || typ == typeof(Skaut))
            {
                List<Pracownik> extent = (List<Pracownik>)typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);
                extent.Remove(pracownik);
            }
        }

        //Usunięcie klubu z systemu, tożsame z usunięciem wszystkich pracowników
        public void Remove()
        {
            extent.Remove(this);
            wszyscyPracownicy.ExceptWith(pracownicy);
            pracownicy.Clear();
            Skaut.Extent.Clear();
            Dyrektor.Extent.Clear();
        }
    }
}