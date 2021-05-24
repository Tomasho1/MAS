using System;
using System.Collections.Generic;
using System.Text;

namespace MP4.XOR
{
    class EmploymentContract
    {
        private string position;
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
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

        private int hoursPerWeek;
        public int HoursPerWeek
        {
            get
            {
                return hoursPerWeek;
            }
            set
            {
                hoursPerWeek = value;
            }
        }
      
        private int noticePeriod; 
        public int NoticePeriod
        {
            get
            {
                return noticePeriod;
            }
            set
            {
                noticePeriod = value;
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

        public EmploymentContract(string position, double salary, DateTime startDate, DateTime endDate, int hoursPerWeek, int noticePeriod, Employee employee)
        {
            this.Position = position;
            this.Salary = salary;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.HoursPerWeek = hoursPerWeek;
            this.NoticePeriod = noticePeriod;
            this.Employee = employee;
            Employee.SignEmploymentContract(this);
        }

        public bool ValidationCheck()
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
            if (Employee.EmploymentContract == null)
            {
                throw new Exception("No employment contract signed for this employee");
            }
            Employee.EmploymentContract = null;
        } 
    }
}
