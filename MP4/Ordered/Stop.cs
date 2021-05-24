using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Ordered
{
    class Stop
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
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private List<Line> Lines = new List<Line>();

        public Stop(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public void AddLine(Line line)
        {
            if (Lines.Contains(line))
            {
                throw new Exception($"Line already added to stop {this.Name}");
            }
            else Lines.Add(line);
        }

        public string ShowLines()
        {
            string info = $"List of lines for stop {this.Name}\n";

            foreach (Line line in Lines)
            {
                info += line.Number + "\n";
            }

            return info;
        }
    }
}
