using Greengrocery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GreengroceryTest
{
    [TestClass]
    public class SupplierTest
    {
        [TestMethod]
        public void Suppliers_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string expectedSurname = "Johnson";
            string expectedName = "Alice";
            int expectedPhone = 987123456;
            string expectedEmail = "alice.johnson@example.com";
            int expectedSupplierId = 456;

            // Act
            Suppliers supplier = new Suppliers(expectedSurname, expectedName, expectedPhone, expectedEmail, expectedSupplierId);

            // Assert
            Assert.AreEqual(expectedSurname, supplier.GetSurname());
            Assert.AreEqual(expectedName, supplier.GetName());
            Assert.AreEqual(expectedPhone, supplier.GetPhone());
            Assert.AreEqual(expectedEmail, supplier.GetEmail());
            Assert.AreEqual(expectedSupplierId, supplier.GetSupplierId());
        }

        [TestMethod]
        public void Suppliers_SetSupplierId_ChangesSupplierIdCorrectly()
        {
            // Arrange
            Suppliers supplier = new Suppliers("Johnson", "Alice", 987123456, "alice.johnson@example.com", 456);
            int newSupplierId = 789;

            // Act
            supplier.SetSupplierId(newSupplierId);

            // Assert
            Assert.AreEqual(newSupplierId, supplier.GetSupplierId());
        }

        [TestMethod]
        public void Suppliers_SetProducts_ChangesProductsCorrectly()
        {
            // Arrange
            Suppliers supplier = new Suppliers("Johnson", "Alice", 987123456, "alice.johnson@example.com", 456);
            Product[] newProducts = new Product[]
            {
                new Product(1, "Apple", 1.99f, "Fruit"),
                new Product(2, "Banana", 0.99f, "Fruit"),
            };

            // Act
            supplier.SetProducts(newProducts);

            // Assert
            Assert.AreEqual(newProducts, supplier.GetProducts());
        }
    }
}
