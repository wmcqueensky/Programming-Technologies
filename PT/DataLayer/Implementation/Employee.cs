using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class Employee : IEmployee
    {
        public Employee(int id, string firstName, string lastName)
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
