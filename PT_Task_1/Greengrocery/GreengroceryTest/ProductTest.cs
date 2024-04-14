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
            Assert.AreEqual(productName, product.getName());
            Assert.AreEqual(productPrice, product.getPrice());
            Assert.AreEqual(productType, product.getTypeOfProdcut());
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
            product.setPrice(newPrice);

            Assert.AreEqual(newPrice, product.getPrice());
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

            product.setPrice(-1.00f);

        }
    }
}
