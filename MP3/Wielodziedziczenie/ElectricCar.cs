using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Wielodziedziczenie
{
    class ElectricCar : Car
    {
        private double averageRange;
        public double AverageRange
        {
            get
            {
                return averageRange;
            }
            set
            {
                averageRange = value;
            }
        }

        private double averageEnergyUsage;
        public double AverageEnergyUsage
        {
            get
            {
                return averageEnergyUsage;
            }
            set
            {
                averageEnergyUsage = value;
            }
        }

        public ElectricCar(string name, int power, int yearOfRelease, double averageRange, double averageEnergyUsage) : base(name, power, yearOfRelease)
        {
            this.AverageRange = averageRange;
            this.AverageEnergyUsage = averageEnergyUsage;
        }
        override
        public string CalculateNeededUnit(double tripLength)
        {
            double neededEnergy = (tripLength / 100.00) * this.AverageEnergyUsage;
            return $"Energy needed for a trip is : {neededEnergy}";
        }
    }
}
