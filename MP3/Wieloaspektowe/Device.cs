using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Wieloaspektowe
{
    public enum DeviceType {Wired, Wireless}
    public class Device
    {
        private String producer;
        public String Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
            }
        }
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

        private String colour;
        public String Colour
        {
            get
            {
                return colour;
            }
            set
            {
                colour = value;
            }
        }

        private double cableLength;
        public double CableLength 
        {
            get
            {
                return cableLength;
            }
            set
            {
                cableLength = value;
            }
        }

        private int maxHoursOnBattery;
        public int MaxHoursOnBattery
        {
            get
            {
                return maxHoursOnBattery;
            }
            set
            {
                maxHoursOnBattery = value;
            }
        }

        public Device (String producer, String name, String colour)
        {
            this.Producer = producer;
            this.Name = name;
            this.Colour = colour;
        }

        public Device(String producer, String name, String colour, double cableLength)
        {
            this.Producer = producer;
            this.Name = name;
            this.Colour = colour;
            this.CableLength = cableLength;
        }

        public Device(String producer, String name, String colour, int maxHoursOnBattery)
        {
            this.Producer = producer;
            this.Name = name;
            this.Colour = colour;
            this.MaxHoursOnBattery = maxHoursOnBattery;
        }

        public override string ToString()
        {
            string info = "";
            
            info += $"Producer: { this.Producer}" +
            $"\nName: {this.Name}" +
            $"\nColour: {this.Colour}";

            if (this.cableLength == 0.0 && (this.GetType() != typeof(Mouse) && this.GetType() != typeof(Keyboard)))
            {
                info += $"\nMax hours on battery: {this.MaxHoursOnBattery}\n";
            }
            else if (this.maxHoursOnBattery == 0 && (this.GetType() != typeof(Mouse) && this.GetType() != typeof(Keyboard)))
            {
                info += $"\nCable length: { this.CableLength} meters\n";
            }

            return info;
        }
        public string GetConnection()
        {
            if (this.cableLength == 0.0)
            {
                return $"{this.producer} {this.name} is using a battery that can last to {this.maxHoursOnBattery} hours";
            }

            else return $"{this.producer} {this.name} is using a {this.cableLength} meters cable";
        }


    }
}

