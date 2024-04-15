using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greengrocery;
using System.Collections.Generic;

namespace GreengroceryTest
{
    [TestClass]
    public class GroceryShopTest
    {
        [TestMethod]
        public void TestGroceryShopInitialization()
        {
            double initialBalance = 100.00;
            GroceryShop shop = new GroceryShop(initialBalance);

            Assert.IsNotNull(shop.GetCatalog());
            Assert.IsNotNull(shop.GetUsers());
            Assert.AreEqual(initialBalance, shop.GetBalance());
        }

        [TestMethod]
        public void TestAddUser()
        {
            GroceryShop shop = new GroceryShop(100.00);
            Customer user = new Customer("Doe", "John", 123456789, "john@example.com", 1, 0); // Creating a Customer instance for testing

            shop.AddUser(user);

            CollectionAssert.Contains(shop.GetUsers(), user);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            GroceryShop shop = new GroceryShop(100.00);
            Customer user = new Customer("Doe", "John", 123456789, "john@example.com", 1, 0); // Creating a Customer instance for testing
            shop.AddUser(user);

            shop.DeleteUser(user);

            CollectionAssert.DoesNotContain(shop.GetUsers(), user);
        }

        [TestMethod]
        public void TestAddProduct()
        {
            GroceryShop shop = new GroceryShop(100.00);
            Product product = new Product(1, "Apple", 1.50f, "Fruit");

            shop.AddProduct(product);

            CollectionAssert.Contains(shop.GetCatalog().GetProducts(), product);
        }

        [TestMethod]
        public void TestDeleteProduct()
        {
            GroceryShop shop = new GroceryShop(100.00);
            Product product = new Product(1, "Apple", 1.50f, "Fruit");
            shop.AddProduct(product);

            shop.DeleteProduct(product);

            CollectionAssert.DoesNotContain(shop.GetCatalog().GetProducts(), product);
        }

        [TestMethod]
        public void TestUpdateGroceryShopState()
        {
            double initialBalance = 100.00;
            GroceryShop shop = new GroceryShop(initialBalance);

            Product product1 = new Product(1, "Apple", 1.50f, "Fruit");
            Product product2 = new Product(2, "Banana", 0.75f, "Fruit");
            shop.AddProduct(product1);
            shop.AddProduct(product2);

            Customer user = new Customer("Doe", "John", 123456789, "john@example.com", 1, 0); // Creating a Customer instance for testing
            shop.AddUser(user);

            State state = new State(shop);

            shop.DeleteProduct(product1);
            shop.DeleteUser(user);
            shop.AddProduct(new Product(3, "Orange", 2.00f, "Fruit"));

            shop.UpdateGroceryShopState(state);

            int expectedProductCount = state.GetCurrentCatalog().GetProducts().Count;
            int actualProductCount = shop.GetCatalog().GetProducts().Count;
            Assert.AreEqual(expectedProductCount, actualProductCount, $"Expected {expectedProductCount} products, but found {actualProductCount} products.");

            int expectedUserCount = state.GetCurrentUsers().Count;
            int actualUserCount = shop.GetUsers().Count;
            Assert.AreEqual(expectedUserCount, actualUserCount, $"Expected {expectedUserCount} users, but found {actualUserCount} users.");

            Assert.AreEqual(state.GetCurrentBalance(), shop.GetBalance());
        }

    }
}