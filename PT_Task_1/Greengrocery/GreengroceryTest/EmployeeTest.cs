using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Greengrocery;

namespace GreengroceryTest
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestEmployeeConstructor()
        {
            string expectedSurname = "Smith";
            string expectedName = "Jane";
            int expectedPhone = 987654321;
            string expectedEmail = "jane.smith@example.com";
            int expectedEmployeeId = 123;
            int expectedSalary = 50000;

            // Act
            Employee employee = new Employee(expectedSurname, expectedName, expectedPhone, expectedEmail, expectedEmployeeId, expectedSalary);

            // Assert
            Assert.AreEqual(expectedSurname, employee.getSurname());
            Assert.AreEqual(expectedName, employee.getName());
            Assert.AreEqual(expectedPhone, employee.getPhone());
            Assert.AreEqual(expectedEmail, employee.getEmail());
            Assert.AreEqual(expectedEmployeeId, employee.GetEmployeeId());
            Assert.AreEqual(expectedSalary, employee.GetSalary());
        }


        [TestMethod]
        public void Employee_SetEmployeeId_ChangesEmployeeIdCorrectly()
        {
            // Arrange
            Employee employee = new Employee("Smith", "John", 123456789, "john.smith@example.com", 123, 50000);
            int newEmployeeId = 456;

            // Act
            employee.SetEmployeeId(newEmployeeId);

            // Assert
            Assert.AreEqual(newEmployeeId, employee.GetEmployeeId());
        }

        [TestMethod]
        public void Employee_SetSalary_ChangesSalaryCorrectly()
        {
            // Arrange
            Employee employee = new Employee("Smith", "John", 123456789, "john.smith@example.com", 123, 50000);
            int newSalary = 60000;

            // Act
            employee.SetSalary(newSalary);

            // Assert
            Assert.AreEqual(newSalary, employee.GetSalary());
        }

    }

    

}
