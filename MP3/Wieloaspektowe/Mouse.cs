using System;


namespace MP3.Wieloaspektowe
{
    class Mouse : Device 
    {
        private int numberOfButtons;
        public int NumberOfButtons
        {
            get
            {
                return numberOfButtons;
            }
            set
            {
                numberOfButtons = value;
            }
        }

        private int maxDPI;
        public int MaxDPI
        {
            get
            {
                return maxDPI;
            }
            set
            {
                maxDPI = value;
            }
        }

        public Mouse(String producer, String name, String colour, int numberOfButtons, int maxDPI) : base(producer, name, colour)
        {
            this.NumberOfButtons = numberOfButtons;
            this.MaxDPI = maxDPI;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nNumber of buttons: {this.NumberOfButtons}" +
                $"\nMax DPI: {this.MaxDPI}\n";
        }
    }
}
