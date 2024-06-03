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

        
    }
}
