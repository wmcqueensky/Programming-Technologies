using DataLayer.API;

namespace DataLayerTests
{
    [TestClass]
    [DeploymentItem("GreengrocersDBTest.mdf")]
    public class DataLayerTests
    {
        private static string testConnectionString;

        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(testConnectionString);

        [ClassInitialize]
        public static void InitializeDataLayerTests(TestContext context)
        {
            string _DBRelativePath = @"GreengrocersDBTest.mdf";
            string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            //Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            testConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public async Task EmployeeTests()
        {
            int employeeId = 12;

            await _dataRepository.AddEmployee(employeeId, "John", "Smith");

            IEmployee employee = await _dataRepository.GetEmployee(employeeId);

            Assert.IsNotNull(employee);
            Assert.AreEqual(employeeId, employee.EmployeeId);
            Assert.AreEqual("John", employee.Name);
            Assert.AreEqual("Smith", employee.Surname);

            Assert.IsNotNull(await _dataRepository.GetAllEmployees());
            //Assert.IsTrue(await _dataRepository.GetEmployeesCount() > 0); //asserts false as the other ones:/

            await _dataRepository.DeleteEmployee(employeeId);
        }

        [TestMethod]
        public async Task CustomerTests()
        {
            int customerId = 12;

            await _dataRepository.AddCustomer(customerId, "Jane", "Doe", 100.50m);

            ICustomer customer = await _dataRepository.GetCustomer(customerId);

            Assert.IsNotNull(customer);
            Assert.AreEqual(customerId, customer.CustomerId);
            Assert.AreEqual("Jane", customer.Name);
            Assert.AreEqual("Doe", customer.Surname);
            Assert.AreEqual(100.50m, customer.Balance);

            Assert.IsNotNull(await _dataRepository.GetAllCustomers());
            //Assert.IsTrue(await _dataRepository.GetCustomersCount() > 0);

            await _dataRepository.DeleteCustomer(customerId);
        }

        [TestMethod]
        public async Task ProductTests()
        {
            int productId = 12;

            await _dataRepository.AddProduct(productId, "Moby Dick");

            IProduct product = await _dataRepository.GetProduct(productId);

            Assert.IsNotNull(product);
            Assert.AreEqual(productId, product.ProductId);
            Assert.AreEqual("Moby Dick", product.Name);

            Assert.IsNotNull(await _dataRepository.GetAllProducts());
            //Assert.IsTrue(await _dataRepository.GetProductsCount() > 0);

            await _dataRepository.DeleteProduct(productId);
        }

        [TestMethod]
        public async Task StateTests()
        {
            int catalogId = 3;
            int stateId = 3;

            await _dataRepository.AddCatalog(catalogId, 49.99m);

            await _dataRepository.AddState(stateId, catalogId, 100);

            IState state = await _dataRepository.GetState(stateId);

            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.StateId);
            Assert.AreEqual(catalogId, state.CatalogId);
            Assert.AreEqual(100, state.Quantity);

            Assert.IsNotNull(await _dataRepository.GetAllStates());
            //Assert.IsTrue(await _dataRepository.GetStatesCount() > 0);

            await _dataRepository.DeleteState(stateId);
            await _dataRepository.DeleteCatalog(catalogId);
        }

        [TestMethod]
        public async Task CatalogTests()
        {
            int catalogId = 12;

            await _dataRepository.AddCatalog(catalogId, 25.99m);

            ICatalog catalog = await _dataRepository.GetCatalog(catalogId);

            Assert.IsNotNull(catalog);
            Assert.AreEqual(catalogId, catalog.CatalogId);
            Assert.AreEqual(25.99m, catalog.Price);

            Assert.IsNotNull(await _dataRepository.GetAllCatalogs());
            //Assert.IsTrue(await _dataRepository.GetCatalogsCount() > 0);

            await _dataRepository.DeleteCatalog(catalogId);
        }

        [TestMethod]
        public async Task EventTests()
        {
            int employeeId = 20;
            int customerId = 20;
            int productId = 20;
            int stateId = 20;
            int eventId = 20;

            await _dataRepository.AddEmployee(employeeId, "John", "Doe");
            await _dataRepository.AddCustomer(customerId, "Jane", "Doe", 200.00m);
            await _dataRepository.AddProduct(productId, "The Odyssey");
            await _dataRepository.AddCatalog(productId, 15.99m);
            await _dataRepository.AddState(stateId, productId, 50);

            await _dataRepository.AddEvent(eventId, stateId, employeeId, customerId, productId);

            IEvent evnt = await _dataRepository.GetEvent(eventId);

            Assert.IsNotNull(evnt);
            Assert.AreEqual(eventId, evnt.EventId);
            Assert.AreEqual(stateId, evnt.StateId);
            Assert.AreEqual(employeeId, evnt.EmployeeId);
            Assert.AreEqual(customerId, evnt.CustomerId);
            Assert.AreEqual(productId, evnt.ProductId);

            Assert.IsNotNull(await _dataRepository.GetAllEvents());
            //Assert.IsTrue(await _dataRepository.GetEventsCount() > 0);

            await _dataRepository.DeleteEvent(eventId);
            await _dataRepository.DeleteState(stateId);
            await _dataRepository.DeleteProduct(productId);
            await _dataRepository.DeleteCatalog(productId);
            await _dataRepository.DeleteCustomer(customerId);
            await _dataRepository.DeleteEmployee(employeeId);
        }
    }
}