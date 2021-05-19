using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Klasa_abstrakcyjna_i_polimorfizm
{
    public class DomesticStudent : Student
    {

        private int scholarshipReduction;
        public int ScholarshipReduction
        {
            get
            {
                return scholarshipReduction;
            }
            set
            {
                scholarshipReduction = value;
            }

        }

        private int socialReduction;
        public int SocialReduction
        {
            get
            {
                return socialReduction;
            }
            set
            {
                socialReduction = value;
            }

        }

        public DomesticStudent(string firstname, string lastname, string nationality, string indexNumber, int scholarshipReduction, int socialReduction) : base(firstname, lastname, nationality, indexNumber)
        {
            if (((scholarshipReduction < 0 || scholarshipReduction > 25 || scholarshipReduction %5 != 0) || (socialReduction < 0 || socialReduction > 20 || socialReduction % 5 != 0)) || (scholarshipReduction < 0 || scholarshipReduction > 25 || scholarshipReduction % 5 != 0) && (socialReduction < 0 || socialReduction > 20 || socialReduction % 5 != 0)) {
                throw new Exception("Wrong reduction value");
            }
            if (nationality != "Poland")
            {
                throw new Exception("Domestic student must be a Pole");
            }
            else
            {
                this.ScholarshipReduction = scholarshipReduction;
                this.SocialReduction = socialReduction;
            }
        }

        public override double CalculateYearlyTuitionFee()
        {
            int totalReductions = scholarshipReduction + socialReduction;
            if (totalReductions == 0)
            {
                return Student.TuitionFee * 10;
            }
            double annualTuitionFee = Student.TuitionFee * 10 - (Student.TuitionFee * totalReductions / 10);
            return annualTuitionFee;
        }
    }
}
