using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Klasa_abstrakcyjna_i_polimorfizm
{
    public abstract class Student
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

        private String indexNumber;
        public String IndexNumber
        {
            get
            {
                return indexNumber;
            }
            set
            {
                indexNumber = value;
            }
        }

        private static double tuitionFee = 1200.00;
        public static double TuitionFee
        {
            get
            {
                return tuitionFee;
            }
            set
            {
                tuitionFee = value;
            }
        }


        public Student(string firstname, string lastname, string nationality, string indexNumber)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Nationality = nationality;
            this.IndexNumber = indexNumber;
        }

        public abstract double CalculateYearlyTuitionFee();
    }
}
