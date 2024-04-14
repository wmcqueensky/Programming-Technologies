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
            // Arrange
            int productId = 1;
            string productName = "Apple";
            float productPrice = 1.50f;
            string productType = "Fruit";

            // Act
            Product product = new Product(productId, productName, productPrice, productType);

            // Assert
            Assert.AreEqual(productId, product.Id);
            Assert.AreEqual(productName, product.GetName());
            Assert.AreEqual(productPrice, product.GetPrice());
            Assert.AreEqual(productType, product.GetType());
        }
    }
}
