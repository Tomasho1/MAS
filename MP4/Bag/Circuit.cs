using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Bag
{
    class Circuit
    {
        private String name;
        public String Name
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
        private double length;
        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        private int turns;
        public int Turns
        {
            get
            {
                return turns;
            }
            set
            {
                turns = value;
            }
        }

        private List<KeyValuePair<Driver, Lap>> times = new List<KeyValuePair<Driver, Lap>>();

        public Circuit(String name, double length, int turns)
        {
            this.Name = name;
            this.Length = length;
            this.Turns = turns;
        }

        public void AddTime(Driver driver, Lap lap)
        {
            times.Add(new KeyValuePair<Driver, Lap>(driver, lap));
        }

        public string ShowTimes()
        {
            string info = "";

            foreach (KeyValuePair<Driver, Lap> driverPair in times) 
            {
                info += $"Driver: {driverPair.Key.Firstname} {driverPair.Key.Lastname}, time: {driverPair.Value.Laptime.Minutes}:{driverPair.Value.Laptime.Seconds}:{driverPair.Value.Laptime.Milliseconds}\n";
            }

            return info;
        }
    }
}
