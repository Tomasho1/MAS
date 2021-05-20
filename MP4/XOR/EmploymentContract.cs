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

        public EmploymentContract(string position, double salary, DateTime startDate, int hoursPerWeek, int noticePeriod, Employee employee)
        {
            this.Position = position;
            this.Salary = salary;
            this.StartDate = startDate;
            this.HoursPerWeek = hoursPerWeek;
            this.NoticePeriod = noticePeriod;
            this.Employee = employee;
            Employee.SignEmploymentContract(this);
        }

        public void Terminate()
        {
            employee.EmploymentContract = null;
        } 
    }
}
