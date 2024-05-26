using Greengrocery.Data.API;
using System.Collections.Generic;

namespace Greengrocery
{
    public class Catalog : ICatalog
    {
        private Dictionary<int, Product> products;

        public int Id { get; set; }
        public string Name { get; set; }

        public Catalog(Dictionary<int, Product> initialProducts = null)
        {
            products = initialProducts ?? new Dictionary<int, Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product.Id, product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product.Id);
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(products.Values);
        }
    }
}
