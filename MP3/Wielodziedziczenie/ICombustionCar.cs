using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Wielodziedziczenie
{
    public interface ICombustionCar
    {
        public string CalculateNeededUnit(double tripLength);
        public int GetFuelTankCapacity();
        public void SetFuelTankCapacity(int fuelTankCapacity);
        public double GetAverageFuelUsage();
        public void SetAverageFuelUsage(double averageFuelUsage);
    }
}
