using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    internal class Employees : User
    {
        private int employeeId;
        private int salary;

        public Employees(string surname, string name, int phone, string email, int employeeId, int salary)
            : base(surname, name, phone, email)
        {
            this.employeeId = employeeId;
            this.salary = salary;
        }

        public int getEmployeeId()
        {
            return this.employeeId;
        }

        public void setEmployeeId(int value)
        {
            this.employeeId = value;
        }

        public int getSalary() { return this.salary; }

        public void setSalary(int value) {
            this.salary = value;
        }
    }
}
