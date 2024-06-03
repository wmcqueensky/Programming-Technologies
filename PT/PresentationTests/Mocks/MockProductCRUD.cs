using Presentation.Model.API;
using PresentationTests.Mocks;
using Service.API;

namespace PresentationTests.FakeItems
{
    internal class MockProductCRUD : IProductModelOperation
    {
        private readonly MockDataRepository _repository = new MockDataRepository();

        public MockProductCRUD()
        {
        }

        public async Task AddProduct(int id, string name)
        {
            await this._repository.AddProduct(id, name);
        }

        public async Task<IProductModel> GetProduct(int id)
        {
            return await this._repository.GetProduct(id);
        }

        public async Task UpdateProduct(int id, string name)
        {
            await this._repository.UpdateProduct(id, name);
        }

        public async Task DeleteProduct(int id)
        {
            await this._repository.DeleteProduct(id);
        }

        public async Task<Dictionary<int, IProductModel>> GetAllProducts()
        {
            Dictionary<int, IProductModel> result = new Dictionary<int, IProductModel>();

            foreach (IProductModel product in (await this._repository.GetAllProducts()).Values)
            {
                result.Add(product.ProductId, (IProductModel)product);
            }

            return result;
        }

        public async Task<int> GetProductsCount()
        {
            return await this._repository.GetProductsCount();
        }
    }
}
