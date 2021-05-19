using System;


namespace MP3.Wieloaspektowe
{
    public enum SwitchType { Mechanical, Membrane, Hybrid}
    class Keyboard : Device
    {
        private String switchType;
        public String SwitchType
        {
            get
            {
                return switchType;
            }
            set
            {
                switchType = value;
            }
        }

        private bool isFullSize;
        public bool IsFullSize
        {
            get
            {
                return isFullSize;
            }
            set
            {
                isFullSize = value;
            }
        }

        public Keyboard(String producer, String name, String colour, SwitchType switchType, bool isFullSize) : base(producer, name, colour)
        {
            this.SwitchType = switchType.ToString();
            this.isFullSize = isFullSize;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nSwitch type: {this.SwitchType}" +
                $"\nFull size: {this.isFullSize}\n";
        }
    }
}
