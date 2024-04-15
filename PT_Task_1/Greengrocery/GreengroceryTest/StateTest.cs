using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greengrocery;

namespace GreengroceryTest
{
    [TestClass]
    public class StateTest
    {
        [TestMethod]
        public void TestStateInitialization()
        {
            GroceryShop shop = new GroceryShop(200.00);
            Catalog catalog = shop.GetCatalog(); // Get the initial catalog
            catalog.AddProduct(new Product(1, "Apple", 1.50f, "Fruit"));
            catalog.AddProduct(new Product(2, "Banana", 0.75f, "Fruit"));
            shop.AddUser(new Customer("Doe", "John", 123456789, "john@example.com", 1, 0)); // Creating a Customer instance for testing
            shop.AddUser(new Customer("Doe", "Alice", 987654321, "alice@example.com", 2, 0)); // Creating a Customer instance for testing

            State state = new State(shop);
            var currentCatalog = state.GetCurrentCatalog();
            var currentUsers = state.GetCurrentUsers();
            var currentBalance = state.GetCurrentBalance();

            Assert.IsNotNull(currentCatalog);
            Assert.IsNotNull(currentUsers);
            Assert.AreEqual(200.00, currentBalance);
            Assert.AreEqual(2, currentUsers.Count);

            int expectedProductCount = 2;
            int actualProductCount = currentCatalog.GetProducts().Count;
            Assert.AreEqual(expectedProductCount, actualProductCount, $"Expected {expectedProductCount} products, but found {actualProductCount} products.");
        }

        [TestMethod]
        public void TestStateWithEmptyShop()
        {
            GroceryShop shop = new GroceryShop(0.00);

            State state = new State(shop);
            var currentCatalog = state.GetCurrentCatalog();
            var currentUsers = state.GetCurrentUsers();
            var currentBalance = state.GetCurrentBalance();

            Assert.IsNotNull(currentCatalog);
            Assert.IsNotNull(currentUsers);
            Assert.AreEqual(0.00, currentBalance);
            Assert.AreEqual(0, currentUsers.Count);

            int expectedProductCount = 0;
            int actualProductCount = currentCatalog.GetProducts().Count;
            Assert.AreEqual(expectedProductCount, actualProductCount, $"Expected {expectedProductCount} products, but found {actualProductCount} products.");
        }
    }
}