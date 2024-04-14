using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greengrocery;
using System;

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
            Assert.AreEqual(productType, product.GetType());
        }

        [TestMethod]
        public void TestSetPrice()
        {
            int productId = 1;
            string productName = "Apple";
            float productPrice = 1.50f;
            string productType = "Fruit";
            Product product = new Product(productId, productName, productPrice, productType);

            float newPrice = 2.00f;
            product.SetPrice(newPrice);

            Assert.AreEqual(newPrice, product.GetPrice());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetNegativePrice()
        {
            int productId = 1;
            string productName = "Apple";
            float productPrice = 1.50f;
            string productType = "Fruit";
            Product product = new Product(productId, productName, productPrice, productType);

            product.SetPrice(-1.00f);

        }
    }
}
