using DataLayer.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest.Mocks
{
    internal class MockEmployeeDTO : IEmployeeDTO
    {
        public MockEmployeeDTO(int id, string firstName, string lastName)
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
