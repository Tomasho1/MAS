using System;
using System.Collections.Generic;

namespace MAS_Final
{
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

        private List<Pracownik> pracownicy;

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
        }

        public void DodajPracownika(Pracownik pracownik)
        {
            if(pracownicy.Contains(pracownik))
            {
                throw new Exception("Pracownik jest już zatrudniony w tym klubie");
            }
            pracownicy.Add(pracownik);
            pracownik.Klub = this;
        }

        public void UsunPracownika(Pracownik pracownik)
        {
            if (!pracownicy.Contains(pracownik))
            {
                throw new Exception("Pracownik nie pracuje w tym klubie");
            }
            pracownicy.Remove(pracownik);
            pracownik.Klub = null;
        }
    }
}