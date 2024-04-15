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
                this.currentCatalog.AddProduct(new Product(product.Id, product.GetName(), product.GetPrice(), product.GetTypeOfProdcut()));
            }

            this.currentUsers = new List<User>();
            foreach (var user in shop.GetUsers())
            {
                this.currentUsers.Add(new User(user.GetSurname(), user.GetName(), user.GetPhone(), user.GetEmail()));
            }

            this.currentBalance = shop.GetBalance();
        }

        public Catalog GetCurrentCatalog()
        {
            return new Catalog(currentCatalog.GetProducts());
        }

        public void SetCurrentCatalog(Catalog catalog)
        {
            this.currentCatalog = catalog;
        }

        public List<User> GetCurrentUsers()
        {
            return new List<User>(currentUsers);
        }

        public void SetCurrentUsers(List<User> users)
        {
            this.currentUsers = users;
        }

        public double GetCurrentBalance()
        {
            return currentBalance;
        }

        public void SetCurrentBalance(double value)
        {
            this.currentBalance = value;
        }
    }
}
