using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    internal class Suppliers : User
    {
        private int supplierId;
        //private Product[] products;

        // Constructor to initialize the Suppliers object
        public Suppliers(string surname, string name, int phone, string email, int supplierId)
            : base(surname, name, phone, email)
        {
            this.supplierId = supplierId;

        }

        public int getSupplierId()
        {
            return this.supplierId;
        }

        public void setSupplierId(int value)
        {
            this.supplierId = value;
        }
    }
}
