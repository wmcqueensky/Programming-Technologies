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
            User user = new User("Doe", "John", 123456789, "john@example.com");

            shop.AddUser(user);

            CollectionAssert.Contains(shop.GetUsers(), user);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            GroceryShop shop = new GroceryShop(100.00);
            User user = new User("Doe", "John", 123456789, "john@example.com");
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
            // Arrange
            double initialBalance = 100.00;
            GroceryShop shop = new GroceryShop(initialBalance);

            // Create some products and users for the shop
            Product product1 = new Product(1, "Apple", 1.50f, "Fruit");
            Product product2 = new Product(2, "Banana", 0.75f, "Fruit");
            shop.AddProduct(product1);
            shop.AddProduct(product2);

            User user = new User("Doe", "John", 123456789, "john@example.com");
            shop.AddUser(user);

            // Create a state with the initial state of the shop
            State state = new State(shop);

            // Perform some changes to the shop
            shop.DeleteProduct(product1);
            shop.DeleteUser(user);
            shop.AddProduct(new Product(3, "Orange", 2.00f, "Fruit"));

            // Act
            shop.UpdateGroceryShopState(state);

            // Assert
            // Check if the catalog in the shop has been updated
            //CollectionAssert.AreEqual(state.GetCurrentCatalog().GetProducts(), shop.GetCatalog().GetProducts());

            // Check if the users in the shop have been updated
            //CollectionAssert.AreEqual(state.GetCurrentUsers(), shop.GetUsers());

            // Check if the balance in the shop has been updated
            Assert.AreEqual(state.GetCurrentBalance(), shop.GetBalance());
        }
    }
}
