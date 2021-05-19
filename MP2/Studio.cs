using System;


namespace MP2
{
    public class Studio
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

        private string country;
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        private string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        private Developer developer;
        public Developer Developer
        {
            get
            {
                return developer;
            }
            set
            {
                developer = value;
            }
        }

        private Studio(Developer developer, String name, String country, String city)
        {
            this.Developer = developer;
            this.Name = name;
            this.Country = country;
            this.City = city;
        }

        public static Studio CreateStudio(Developer developer, String name, String country, String city)
        {
            if (developer == null)
            {
                throw new Exception("Developer does not exist");
            }

            Studio studio = new Studio(developer, name, country, city);
            developer.AddStudio(studio);
            return studio;

        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Studio studio = (Studio)obj;

                if (this.Name == studio.Name && this.Country == studio.Country && this.City == studio.City)
                {
                    return true;
                }
                else return false;
            }
        }

        public override int GetHashCode()
        {
            return new { Name, Country, City}.GetHashCode();
        }
        public override string ToString()
        {
           return $"Name: { this.Name}" +
           $"\nCountry: {this.Country}" +
           $"\nCity: {this.City}" + "\n";
        }     
    }
}
