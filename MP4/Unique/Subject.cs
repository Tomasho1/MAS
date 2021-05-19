using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.Unique
{
    class Subject
    {
        private static HashSet<String> names = new HashSet<string>();
        private static HashSet<String> shortnames = new HashSet<string>();

        private String name;
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                if (names.Contains(value))
                {
                    throw new Exception("Name must be a unique value!");
                }

                else
                {
                    name = value;
                    names.Add(value);
                }
            }
        }
        private String shortname;
        public String Shortname
        {
            get
            {
                return shortname;
            }
            set
            {
                if (shortnames.Contains(value))
                {
                    throw new Exception("Shortname must be a unique value!");
                }
                else
                {
                    shortname = value;
                    shortnames.Add(value);
                }
            }
        }
        private int semester;
        public int Semester
        {
            get
            {
                return semester;
            }
            set
            {
                semester = value;
            }
        }

        public Subject(String name, String shortname, int semester)
        {
            this.Name = name;
            this.Shortname = shortname;
            this.Semester = semester;
        }
    }
}
