using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.XOR
{
    class Employee
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
        private DateTime birthdate;
        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }
            set
            {
                birthdate = value;
            }
        }

        private EmploymentContract employmentContract;
        public EmploymentContract EmploymentContract
        {
            get
            {
                return employmentContract;
            }
            set
            {
                employmentContract = value;
            }
        }

        private MandateContract mandateContract;
        public MandateContract MandateContract
        {
            get
            {
                return mandateContract;
            }
            set
            {
                mandateContract = value;
            }
        }
        public Employee(String firstname, String lastname, DateTime birthdate)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = birthdate;
        }

        public void SignEmploymentContract(EmploymentContract employmentContract)
        {
            if (mandateContract != null)
            {
                throw new Exception("Employee has a valid mandate contract!");
            }
            else if (employmentContract.Employee != this)
            {
                throw new Exception("This employment contract was signed by another employee!");
            }
            else EmploymentContract = employmentContract;
        }
        public void SignMandateContract(MandateContract mandateContract)
        {
            if (employmentContract != null)
            {
                throw new Exception("Employee has a valid employment contract!");
            }
            else if (mandateContract.Employee != this)
            {
                throw new Exception("This mandate contract was signed by another employee!");
            }
            else MandateContract = mandateContract;
        }
    }
}
