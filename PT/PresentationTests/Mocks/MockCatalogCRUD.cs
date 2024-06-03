using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.Mocks
{
    public class MockCatalogCRUD : ICatalogModelOperation
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public MockCatalogCRUD() { }

        public async Task AddCatalog(int id, decimal price)
        {
            await _dataRepository.AddCatalog(id, price);
        }

        public async Task DeleteCatalog(int id)
        {
            await _dataRepository.DeleteCatalog(id);
        }

        public async Task<Dictionary<int, ICatalogModel>> GetAllCatalogs()
        {
            return await _dataRepository.GetAllCatalogs();
        }

        public async Task<ICatalogModel> GetCatalog(int id)
        {
            return await _dataRepository.GetCatalog(id);
        }

        public async Task<int> GetCatalogsCount()
        {
            return await _dataRepository.GetCatalogsCount();
        }

        public async Task UpdateCatalog(int id, decimal price)
        {
            await _dataRepository.UpdateCatalog(id, price);
        }
    }
}
