using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class CustomerModel : ICustomerModel
    {
        public CustomerModel(int id, string firstName, string lastName, decimal balance)
        {
            this.CustomerId = id;
            this.Name = firstName;
            this.Surname = lastName;
            this.Balance = balance;
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Balance { get; set; }
    }
}
