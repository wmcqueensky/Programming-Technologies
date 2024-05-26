using Greengrocery.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    public class Customer : ICustomer
    {
        // Implementing properties from IUser
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Implementing properties from ICustomer
        public int CustomerId { get; set; }
        public double Balance { get; set; }

        // Constructor to initialize properties
        public Customer(string surname, string name, string phone, string email, int customerId, double balance)
        {
            this.Surname = surname;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.CustomerId = customerId;
            this.Balance = balance;
        }

        // Method to set CustomerId
        public void SetCustomerId(int value)
        {
            this.CustomerId = value;
        }

        // Method to set Balance
        public void SetBalance(double value)
        {
            this.Balance = value;
        }
    }
}