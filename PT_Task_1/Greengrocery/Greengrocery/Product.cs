using System;

namespace Greengrocery
{
    public class Product
    {
        private int product_id;
        private string name;
        private float price;
        private string type;
        public Product(int productId, string name, float price, string type)
        {
            this.product_id = productId;
            this.name = name;
            this.price = price;
            this.type = type;
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

        public string GetType()
        {
            return type;
        }
    }
}
