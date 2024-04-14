using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    public class Customer : User
    {
        private int customerId;
        private int balance;

        // Constructor to initialize the Customers object
        public Customer(string surname, string name, int phone, string email, int customerId, int balance)
            : base(surname, name, phone, email)
        {
            this.customerId = customerId;
            this.balance = balance;
        }

        public int getCustomerId()
        {
            return this.customerId;
        }

        public void setCustomerId(int value)
        {
            this.customerId = value;
        }
        
        public int getBalance() {return this.balance;}

        public void setBalance(int value) { this.balance = value; }
    }
}
