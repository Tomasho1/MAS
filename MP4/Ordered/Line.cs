using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Ordered
{
    public enum LineType { Normal, Night}
    class Line
    {
        public List<Stop> Stops = new List<Stop>();
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public Line(int number, LineType lineType) 
        {
            this.Number = number;
            this.Type = lineType.ToString();
        }

        public void AddStop(Stop stop)
        {
            if (Stops.Contains(stop))
            {
                throw new Exception($"This stop is already added to line {this.Number}");
            }
            else
            {
                Stops.Add(stop);
                stop.AddLine(this);
            }
        }

        public string ShowStops()
        {
            string info = $"List of stops for line {this.Number}\n";

            foreach (Stop stop in Stops)
            {
                info += stop.Name + "\n";
            }

            return info;
        }
    }
}
