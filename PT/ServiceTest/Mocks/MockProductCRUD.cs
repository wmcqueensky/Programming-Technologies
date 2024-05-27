using Service.API;

namespace ServiceTest.FakeItems
{
    internal class MockProductCRUD : IProductCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public async Task AddProduct(int id, string name)
        {
            await _dataRepository.AddProduct(id, name);
        }

        public async Task DeleteProduct(int id)
        {
            await _dataRepository.DeleteProduct(id);
        }

        public async Task<Dictionary<int, IProductDTO>> GetAllProducts()
        {
            return await _dataRepository.GetAllProducts();
        }

        public async Task<IProductDTO> GetProduct(int id)
        {
            return await _dataRepository.GetProduct(id);
        }

        public async Task<int> GetProductsCount()
        {
            return await _dataRepository.GetProductsCount();
        }

        public async Task UpdateProduct(int id, string name)
        {
            await _dataRepository.UpdateProduct(id, name);
        }
    }
}
