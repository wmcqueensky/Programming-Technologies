using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class Product : IProduct
    {
        public Product(int id, string name)
        { 
            this.ProductId = id;
            this.Name = name;
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
