using System.Collections.Generic;

namespace Greengrocery
{
    public class GroceryShop
    {
        private Catalog catalog;
        private List<User> users;
        private double initialBalance;

        public GroceryShop(double initialBalance)
        {
            this.catalog = new Catalog();
            this.users = new List<User>();
            this.initialBalance = initialBalance;
        }

        public Catalog GetCatalog()
        {
            return catalog;
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public double GetBalance()
        {
            return initialBalance;
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public void AddProduct(Product product)
        {
            catalog.AddProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            catalog.RemoveProduct(product);
        }
    }
}
