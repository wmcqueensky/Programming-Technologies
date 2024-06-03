using DataLayer.API;

namespace DataLayerTests
{
    [TestClass]
    [DeploymentItem(@"Instrumentation\GreengrocersDBTest.mdf", @"Instrumentation")]
    public class DataLayerTests
    {
        private static string testConnectionString;

        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(testConnectionString);

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            string relativePath = @"Instrumentation\GreengrocersDBTest.mdf";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(directory, relativePath);
            Assert.IsTrue(File.Exists(dbPath), $"Database file not found at: {dbPath}");
            testConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;";
        }

        [TestMethod]
        public async Task AddProductTest()
        {
            int productId = 12;
            string productName = "Moby Dick";

            await _dataRepository.AddProduct(productId, productName);
            IProduct product = await _dataRepository.GetProduct(productId);

            Assert.IsNotNull(product);
            Assert.AreEqual(productId, product.ProductId);
            Assert.AreEqual(productName, product.Name);

            await _dataRepository.DeleteProduct(productId);
        }

        [TestMethod]
        public async Task GetProductTest()
        {
            int productId = 12;
            string productName = "Moby Dick";

            await _dataRepository.AddProduct(productId, productName);
            IProduct product = await _dataRepository.GetProduct(productId);

            Assert.IsNotNull(product);
            Assert.AreEqual(productId, product.ProductId);
            Assert.AreEqual(productName, product.Name);

            await _dataRepository.DeleteProduct(productId);
        }

        [TestMethod]
        public async Task GetAllProductsTest()
        {
            Assert.IsNotNull(await _dataRepository.GetAllProducts());
        }


        [TestMethod]
        public async Task AddStateTest()
        {
            int catalogId = 3;
            int stateId = 3;
            int quantity = 100;

            await _dataRepository.AddCatalog(catalogId, 49.99m);
            await _dataRepository.AddState(stateId, catalogId, quantity);
            IState state = await _dataRepository.GetState(stateId);

            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.StateId);
            Assert.AreEqual(catalogId, state.CatalogId);
            Assert.AreEqual(quantity, state.Quantity);

            await _dataRepository.DeleteState(stateId);
            await _dataRepository.DeleteCatalog(catalogId);
        }


        [TestMethod]
        public async Task GetStateTest()
        {
            int catalogId = 3;
            int stateId = 3;
            int quantity = 100;

            await _dataRepository.AddCatalog(catalogId, 49.99m);
            await _dataRepository.AddState(stateId, catalogId, quantity);
            IState state = await _dataRepository.GetState(stateId);

            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.StateId);
            Assert.AreEqual(catalogId, state.CatalogId);
            Assert.AreEqual(quantity, state.Quantity);

            await _dataRepository.DeleteState(stateId);
            await _dataRepository.DeleteCatalog(catalogId);
        }

        [TestMethod]
        public async Task GetAllStatesTest()
        {
            Assert.IsNotNull(await _dataRepository.GetAllStates());
        }

        [TestMethod]
        public async Task AddCatalogTest()
        {
            int catalogId = 12;
            decimal price = 25.99m;

            await _dataRepository.AddCatalog(catalogId, price);
            ICatalog catalog = await _dataRepository.GetCatalog(catalogId);

            Assert.IsNotNull(catalog);
            Assert.AreEqual(catalogId, catalog.CatalogId);
            Assert.AreEqual(price, catalog.Price);

            await _dataRepository.DeleteCatalog(catalogId);
        }


        [TestMethod]
        public async Task GetCatalogTest()
        {
            int catalogId = 12;
            decimal price = 25.99m;

            await _dataRepository.AddCatalog(catalogId, price);
            ICatalog catalog = await _dataRepository.GetCatalog(catalogId);

            Assert.IsNotNull(catalog);
            Assert.AreEqual(catalogId, catalog.CatalogId);
            Assert.AreEqual(price, catalog.Price);

            await _dataRepository.DeleteCatalog(catalogId);
        }


        [TestMethod]
        public async Task GetAllCatalogsTest()
        {
            Assert.IsNotNull(await _dataRepository.GetAllCatalogs());
        }

        [TestMethod]
        public async Task GetAllEmployeesTest()
        {
            Assert.IsNotNull(await _dataRepository.GetAllEmployees());
        }


        [TestMethod]
        public async Task GetAllCustomersTest()
        {
            Assert.IsNotNull(await _dataRepository.GetAllCustomers());
        }


        [TestMethod]
        public async Task GetAllEventsTest()
        {
            Assert.IsNotNull(await _dataRepository.GetAllEvents());
        }
    }
}
