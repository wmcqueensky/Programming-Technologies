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
            string relativePath = @"Instrumentation\GreengroceryDBTest.mdf";
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(directory, relativePath);
            Assert.IsTrue(File.Exists(dbPath), $"Database file not found at: {dbPath}");
            testConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;";
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


    }
}
