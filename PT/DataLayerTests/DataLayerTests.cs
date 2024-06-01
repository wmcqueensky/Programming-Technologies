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