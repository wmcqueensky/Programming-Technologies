using System.Collections.Generic;

namespace Greengrocery
{
    public class Catalog
    {
        private List<Product> products;

        public Catalog()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
