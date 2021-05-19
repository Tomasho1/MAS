using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Wielodziedziczenie
{
    class HybridCar : ElectricCar, ICombustionCar
    {
        private CombustionCar combustionCar;
        public CombustionCar CombustionCar
        {
            get
            {
                return combustionCar;
            }
            set
            {
                combustionCar = value;
            }
        }
        public HybridCar(string name, int power, int yearOfRelease, double averageFuelUsage, int fuelTankCapacity, double averageRange, double averageEnergyUsage) : base(name, power, yearOfRelease, averageRange, averageEnergyUsage)
        {
            combustionCar = new CombustionCar(name, power, yearOfRelease, averageFuelUsage, fuelTankCapacity);
        }

        override
        public string CalculateNeededUnit(double tripLength)
        {
            double neededFuel = (tripLength / 100.00) * this.CombustionCar.GetAverageFuelUsage();
            double neededEnergy = (tripLength / 100.00) * this.AverageEnergyUsage;
            return $"Fuel needed for a trip is : {neededFuel}, energy needed for a trip is : {neededEnergy}";
        }

        public int GetFuelTankCapacity()
        {
            return combustionCar.GetFuelTankCapacity();
        }

        public void SetFuelTankCapacity(int fuelTankCapacity)
        {
            combustionCar.SetFuelTankCapacity(fuelTankCapacity);
        }

        public double GetAverageFuelUsage()
        {
            return combustionCar.GetAverageFuelUsage();
        }

        public void SetAverageFuelUsage(double averageFuelUsage)
        {
            combustionCar.SetAverageFuelUsage(averageFuelUsage);
        }
        public override string ToString()
        {
            return $"Name: { this.Name}" +
            $"\nPower: {this.Power}" +
            $"\nYear of release: {this.YearOfRelease}" +
            $"\nAverage fuel usage: {this.GetAverageFuelUsage()}" +
            $"\nFuel tank capacity: {this.GetFuelTankCapacity()}" +
            $"\nAverage range: {this.AverageRange}" +
            $"\nAverage energy usage: {this.AverageEnergyUsage}";
        }
    }
}
