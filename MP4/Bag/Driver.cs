using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MP4.Bag
{
    class Driver
    {
        private String firstname;
        public String Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        private String lastname;
        public String Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        private String nationality;
        public String Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                nationality = value;
            }
        }

        private List<KeyValuePair<Circuit, Lap>> times = new List<KeyValuePair<Circuit, Lap>>();

        public Driver(String firstname, String lastname, String nationality)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Nationality = nationality;
        }

        public void AddTime(Circuit circuit, Lap lap)
        {
            times.Add(new KeyValuePair<Circuit, Lap>(circuit, lap));
        }

        public string ShowTimes()
        {
            string info = "";

            foreach (KeyValuePair<Circuit, Lap> circuitPair in times)
            {
                info += $"Circuit: {circuitPair.Key.Name}, time: {circuitPair.Value.Laptime.Minutes}:{circuitPair.Value.Laptime.Seconds}:{circuitPair.Value.Laptime.Milliseconds}\n";
            }

            return info;
        }

        public string LapsOnCircuit(Circuit circuit)
        {
            int laps = times.Count(x => x.Key == circuit);

            return $"{this.Firstname} {this.Lastname} made {laps} laps on {circuit.Name}\n";
        }
    }
}
