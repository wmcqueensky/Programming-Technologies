using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greengrocery;

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
    }
}
