using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    internal class EmployeeDTO : IEmployeeDTO
    {
        public EmployeeDTO(int id, string firstName, string lastName)
        {
            this.EmployeeId = id;
            this.Name = firstName;
            this.Surname = lastName;
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
