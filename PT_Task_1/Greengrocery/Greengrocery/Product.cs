using System;

namespace Greengrocery
{
    public class Product
    {
        private readonly int product_id;
        private readonly string name;
        private float price;
        private readonly string typeOfProduct;
        public Product(int productId, string name, float price, string type)
        {
            this.product_id = productId;
            this.name = name;
            this.price = price;
            this.typeOfProduct = type;
        }

        public int Id
        {
            get { return product_id; }
        }

        public string GetName()
        {
            return name;
        }

        public float GetPrice()
        {
            return price;
        }

        public string GetTypeOfProdcut()
        {
            return typeOfProduct;
        }
    }
}
