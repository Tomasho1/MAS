using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Wielodziedziczenie
{
    public abstract class Car
    {

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        private int power;
        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
            }
        }

        private int yearOfRelease;
        public int YearOfRelease
        {
            get
            {
                return yearOfRelease;
            }
            set
            {
                yearOfRelease = value;
            }
        }

        public Car(string name, int power, int yearOfRelease)
        {
            this.Name = name;
            this.Power = power;
            this.YearOfRelease = yearOfRelease;
        }

        public abstract string CalculateNeededUnit(double tripLength);

    }
}
