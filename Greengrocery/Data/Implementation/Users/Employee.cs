using Greengrocery.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    public class Employee : IEmployee
    {
        // Implementing properties from the interface
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }

        // Constructor to initialize properties
        public Employee(string surname, string name, string phone, string email, int employeeId, decimal salary)
        {
            this.Surname = surname;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.EmployeeId = employeeId;
            this.Salary = salary;
        }

        // Methods to set employeeId and salary
        public void SetEmployeeId(int value)
        {
            this.EmployeeId = value;
        }

        public void SetSalary(decimal value)
        {
            this.Salary = value;
        }
    }
}