using Greengrocery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GreengroceryTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void Customers_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string expectedSurname = "Brown";
            string expectedName = "David";
            int expectedPhone = 123987456;
            string expectedEmail = "david.brown@example.com";
            int expectedCustomerId = 789;
            int expectedBalance = 100;

            // Act
            Customers customer = new Customers(expectedSurname, expectedName, expectedPhone, expectedEmail, expectedCustomerId, expectedBalance);

            // Assert
            Assert.AreEqual(expectedSurname, customer.GetSurname());
            Assert.AreEqual(expectedName, customer.GetName());
            Assert.AreEqual(expectedPhone, customer.GetPhone());
            Assert.AreEqual(expectedEmail, customer.GetEmail());
            Assert.AreEqual(expectedCustomerId, customer.getCustomerId());
            Assert.AreEqual(expectedBalance, customer.getBalance());
        }

        [TestMethod]
        public void Customers_SetCustomerId_ChangesCustomerIdCorrectly()
        {
            // Arrange
            Customers customer = new Customers("Brown", "David", 123987456, "david.brown@example.com", 789, 100);
            int newCustomerId = 456;

            // Act
            customer.setCustomerId(newCustomerId);

            // Assert
            Assert.AreEqual(newCustomerId, customer.getCustomerId());
        }

        [TestMethod]
        public void Customers_SetBalance_ChangesBalanceCorrectly()
        {
            // Arrange
            Customers customer = new Customers("Brown", "David", 123987456, "david.brown@example.com", 789, 100);
            int newBalance = 200;

            // Act
            customer.setBalance(newBalance);

            // Assert
            Assert.AreEqual(newBalance, customer.getBalance());
        }
    }
}
