using System.Collections.Generic;

namespace Greengrocery
{
    public class State
    {
        private Catalog currentCatalog;
        private List<User> currentUsers;
        private double currentBalance;

        public State(GroceryShop shop)
        {
            this.currentCatalog = new Catalog();
            foreach (var product in shop.GetCatalog().GetProducts())
            {
                this.currentCatalog.AddProduct(new Product(product.Id, product.getName(), product.getPrice(), product.getTypeOfProdcut()));
            }

            this.currentUsers = new List<User>();
            foreach (var user in shop.GetUsers())
            {
                this.currentUsers.Add(new User(user.getSurname(), user.getName(), user.getPhone(), user.getEmail()));
            }

            this.currentBalance = shop.GetBalance();
        }

        public Catalog GetCurrentCatalog()
        {
            return currentCatalog;
        }

        public List<User> GetCurrentUsers()
        {
            return currentUsers;
        }

        public double GetCurrentBalance()
        {
            return currentBalance;
        }
    }
}
