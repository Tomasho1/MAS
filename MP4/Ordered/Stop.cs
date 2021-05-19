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

        public Stop(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

    }
}
