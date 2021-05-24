using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Bag
{
    class Lap
    {
        private TimeSpan laptime;
        public TimeSpan Laptime
        {
            get
            {
                return laptime;
            }
            set
            {
                laptime = value;
            }
        }

        private DateTime time;
        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        private Driver driver;
        public Driver Driver
        {
            get
            {
                return driver;
            }
            set
            {
                driver = value;
            }
        }

        private Circuit circuit;
        public Circuit Circuit
        {
            get
            {
                return circuit;
            }
            set
            {
                circuit = value;
            }
        }

        public Lap(Driver driver, Circuit circuit, TimeSpan laptime, DateTime time)
        {
            this.Driver = driver;
            this.Circuit = circuit;
            this.Laptime = laptime;
            this.Time = time;
            driver.AddTime(circuit, this);
            circuit.AddTime(driver, this);
        }


    }
}
