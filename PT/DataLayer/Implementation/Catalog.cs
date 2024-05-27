using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class Catalog : ICatalog
    {
        public Catalog(int id, decimal price) 
        {
            this.CatalogId = id;
            this.Price = price;
        }
        public int CatalogId { get; set; }
        public decimal Price { get; set; }
    }
}
