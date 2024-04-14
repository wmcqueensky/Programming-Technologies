using Greengrocery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GreengroceryTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string expectedSurname = "Doe";
            string expectedName = "John";
            int expectedPhone = 123456789;
            string expectedEmail = "john.doe@example.com";

            // Act
            User user = new User(expectedSurname, expectedName, expectedPhone, expectedEmail);

            // Assert
            Assert.AreEqual(expectedSurname, user.getSurname());
            Assert.AreEqual(expectedName, user.getName());
            Assert.AreEqual(expectedPhone, user.getPhone());
            Assert.AreEqual(expectedEmail, user.getEmail());
        }

        [TestMethod]
        public void User_SetSurname_ChangesSurnameCorrectly()
        {
            // Arrange
            User user = new User("Doe", "John", 123456789, "john.doe@example.com");
            string newSurname = "Smith";

            // Act
            user.setSurname(newSurname);

            // Assert
            Assert.AreEqual(newSurname, user.getSurname());
        }

        [TestMethod]
        public void User_SetName_ChangesNameCorrectly()
        {
            // Arrange
            User user = new User("Doe", "John", 123456789, "john.doe@example.com");
            string newName = "Alice";

            // Act
            user.setName(newName);

            // Assert
            Assert.AreEqual(newName, user.getName());
        }

        [TestMethod]
        public void User_SetPhone_ChangesPhoneCorrectly()
        {
            // Arrange
            User user = new User("Doe", "John", 123456789, "john.doe@example.com");
            int newPhone = 987654321;

            // Act
            user.setPhone(newPhone);

            // Assert
            Assert.AreEqual(newPhone, user.getPhone());
        }

        [TestMethod]
        public void User_SetEmail_ChangesEmailCorrectly()
        {
            // Arrange
            User user = new User("Doe", "John", 123456789, "john.doe@example.com");
            string newEmail = "john.smith@example.com";

            // Act
            user.setEmail(newEmail);

            // Assert
            Assert.AreEqual(newEmail, user.getEmail());
        }
    }

}
