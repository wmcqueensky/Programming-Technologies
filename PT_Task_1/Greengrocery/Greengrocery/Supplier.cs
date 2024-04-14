using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    public class Suppliers : User
    {
        private int supplierId;
        private Product[] products;

        // Constructor to initialize the Suppliers object
        public Suppliers(string surname, string name, int phone, string email, int supplierId)
            : base(surname, name, phone, email)
        {
            this.supplierId = supplierId;

        }

        public int GetSupplierId()
        {
            return this.supplierId;
        }

        public void SetSupplierId(int value)
        {
            this.supplierId = value;
        }

        public Product[] GetProducts()
        {
            return this.products;
        }

        public void SetProducts(Product[] value)
        {
            this.products = value;
        }
    }
}
