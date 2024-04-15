using System.Collections.Generic;

namespace Greengrocery
{
    public class Catalog
    {
        private List<Product> products;

        public Catalog(List<Product> initialProducts = null)
        {
            products = initialProducts ?? new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(products);
        }
    }
}
