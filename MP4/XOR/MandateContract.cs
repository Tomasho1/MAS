using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.XOR
{
    class MandateContract
    {
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        private DateTime startDate;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        private double salary;
        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }

        private Employee employee;
        public Employee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
            }
        }

        public MandateContract(string description, double salary, DateTime startDate, DateTime endDate, Employee employee)
        {
            this.Description = description;
            this.Salary = salary;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Employee = employee;
            Employee.SignMandateContract(this);
        }

        public bool ValidationCheck ()
        {
            if (endDate < DateTime.Now)
            {
                Terminate();
                return false;
            }
            else return true; 
        }

        public void Terminate()
        {
            if (Employee.MandateContract == null)
            {
                throw new Exception("No mandate contract signed for this employee");
            }
            employee.MandateContract = null;
        }
    }
}
