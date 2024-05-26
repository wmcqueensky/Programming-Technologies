using Greengrocery.Data.API;

namespace DataTests
{
    [TestClass]
    [DeploymentItem("GreengroceryModel.mdf")]
    public class DataLayerTests
    {
        private static string testConnectionString;

        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(testConnectionString);

        [ClassInitialize]
        public static void InitializeDataLayerTests(TestContext context)
        {
            // Similar initialization as before
        }

        [TestMethod]
        public async Task EmployeeTests()
        {
            int employeeId = 1;

            await _dataRepository.AddEmployeeAsync(employeeId, "John", "Doe", 5000.00m);

            IEmployee employee = await _dataRepository.GetEmployeeAsync(employeeId);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employeeId, employee.EmployeeId);
            Assert.AreEqual("John", employee.Name);
            Assert.AreEqual("Doe", employee.Surname);
            Assert.AreEqual(5000.00m, employee.Salary);

            // Additional assertions if needed
        }

        [TestMethod]
        public async Task SupplierTests()
        {
            int supplierId = 1;

            await _dataRepository.AddSupplierAsync(supplierId, "SupplierName", "supplier@example.com", "123456789", 2001);

            ISupplier supplier = await _dataRepository.GetSupplierAsync(supplierId);

            Assert.IsNotNull(supplier);
            Assert.AreEqual(supplierId, supplier.SupplierId);
            Assert.AreEqual("SupplierName", supplier.Name);
            Assert.AreEqual("supplier@example.com", supplier.Email);
            Assert.AreEqual("123456789", supplier.Phone);

            // Additional assertions if needed
        }

        [TestMethod]
        public async Task CustomerTests()
        {
            int customerId = 1;

            await _dataRepository.AddCustomerAsync(customerId, "CustomerName", "customer@example.com", "987654321", 1001, 1000.50m);

            ICustomer customer = await _dataRepository.GetCustomerAsync(customerId);

            Assert.IsNotNull(customer);
            Assert.AreEqual(customerId, customer.CustomerId);
            Assert.AreEqual("CustomerName", customer.Name);
            Assert.AreEqual("customer@example.com", customer.Email);
            Assert.AreEqual("987654321", customer.Phone);
            Assert.AreEqual(1001, customer.CustomerId);
            //Assert.AreEqual(1000.50m, customer.Balance);???????????

            // Additional assertions if needed
        }
    }
}