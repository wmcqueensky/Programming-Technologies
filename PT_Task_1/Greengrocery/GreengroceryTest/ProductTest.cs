using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greengrocery;

namespace GreengroceryTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestProductProperties()
        {
            int productId = 1;
            string productName = "Apple";
            float productPrice = 1.50f;
            string productType = "Fruit";

            Product product = new Product(productId, productName, productPrice, productType);

            Assert.AreEqual(productId, product.Id);
            Assert.AreEqual(productName, product.GetName());
            Assert.AreEqual(productPrice, product.GetPrice());
            Assert.AreEqual(productType, product.GetTypeOfProdcut());
        }
    }
}
