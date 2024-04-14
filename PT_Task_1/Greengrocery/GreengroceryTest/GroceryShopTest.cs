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
    }
}
