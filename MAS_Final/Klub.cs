using System;
using System.Collections.Generic;
using System.Reflection;

namespace MAS_Final
{
    [Serializable]
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


        private List<Pracownik> wszyscyPracownicy = new List<Pracownik>();

        public List<Pracownik> WszyscyPracownicy
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

        public void UsunPrezesa(Prezes prezes)
        {
            if (!Prezes.Equals(prezes))
            {
                throw new Exception("Osoba nie jest prezesem");
            }
            Prezes = null;
        }

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

        public void UsunGlownegoSkauta(GlownySkaut glownySkaut)
        {
            if (GlownySkaut != glownySkaut)
            {
                throw new Exception("Osoba nie jest głównym skautem");
            }
            GlownySkaut = null;
        }

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

    //    public void ZwolnijPracownika(Pracownik pracownik)
    //    {
    //        Type typ = typeof(Pracownik);

    //        if(!pracownicy.Contains(pracownik) && Prezes != pracownik && GlownySkaut != pracownik)
    //        {
    //            throw new Exception("Nie znaleziono osoby");
    //        }

    //        List<Pracownik> extent = (List<Pracownik>)typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

    //        pracownik.DataOdejscia = DateTime.Today;
    //        pracownik.Klub = null;
    //        pracownik.Pensja = 0;

    //    }
    }
}