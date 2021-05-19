using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Wielodziedziczenie
{
    public class CombustionCar : Car, ICombustionCar
    {
        private double averageFuelUsage;
   
        private int fuelTankCapacity;
       

        public CombustionCar(string name, int power, int yearOfRelease, double averageFuelUsage, int fuelTankCapacity) : base(name, power, yearOfRelease)
        {
            this.averageFuelUsage = averageFuelUsage;
            this.fuelTankCapacity = fuelTankCapacity;
        }

        override 
        public string CalculateNeededUnit(double tripLength)
        {
            double neededFuel = (tripLength / 100.00) * this.averageFuelUsage;
            return $"Fuel needed for a trip is : {neededFuel}";
        }

        public int GetFuelTankCapacity()
        {
            return this.fuelTankCapacity;
        }

        public void SetFuelTankCapacity(int fuelTankCapacity)
        {
            this.fuelTankCapacity = fuelTankCapacity;
        }

        public double GetAverageFuelUsage()
        {
            return this.averageFuelUsage;
        }
        public void SetAverageFuelUsage(double averageFuelUsage)
        {
            this.averageFuelUsage = averageFuelUsage;
        }
    }
}
