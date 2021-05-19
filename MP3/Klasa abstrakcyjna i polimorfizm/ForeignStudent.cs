using System;
using System.Collections.Generic;
using System.Text;

namespace MP3.Klasa_abstrakcyjna_i_polimorfizm
{
    class ForeignStudent : Student
    {

        private static int reduction = 40;
        public ForeignStudent(string firstname, string lastname, string nationality, string indexNumber) : base(firstname, lastname, nationality, indexNumber)
        {
            if (nationality == "Poland")
            {
                throw new Exception("Domestic student can't be a Pole");
            }
        }

        public override double CalculateYearlyTuitionFee()
        {
            
            double annualTuitionFee = Student.TuitionFee * 10 - (Student.TuitionFee * reduction / 10);
            return annualTuitionFee;
        }
    }
}
