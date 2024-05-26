using Greengrocery.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocery
{
    public class Supplier : ISupplier
    {
        // Implementing properties from IUser
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Implementing properties from ISupplier
        public int SupplierId { get; set; }
        public Product[] Products { get; set; }

        // Constructor to initialize properties
        public Supplier(string surname, string name, string phone, string email, int supplierId, Product[] products)
        {
            this.Surname = surname;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.SupplierId = supplierId;
            this.Products = products;
        }

        // Method to set SupplierId
        public void SetSupplierId(int value)
        {
            this.SupplierId = value;
        }

        // Method to set Products
        public void SetProducts(Product[] value)
        {
            this.Products = value;
        }
    }
}
