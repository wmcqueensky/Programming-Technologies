using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    internal class Employees : User
    {
        int employeeId;
        int salary;

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
            this.setSalary(value);
        }
    }
}
