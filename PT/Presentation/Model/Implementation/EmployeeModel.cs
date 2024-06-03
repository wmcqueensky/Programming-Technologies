using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class EmployeeModel : IEmployeeModel
    {
        public EmployeeModel(int id, string firstName, string lastName)
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
