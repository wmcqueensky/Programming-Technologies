using DataLayer.API;
using Service.API;
using ServiceTest.FakeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest.Mocks
{
    internal class MockCatalogCRUD : ICatalogCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public async Task AddCatalog(int id, decimal price)
        {
            await _dataRepository.AddCatalog(id, price);
        }

        public async Task DeleteCatalog(int id)
        {
            await _dataRepository.DeleteCatalog(id);
        }

        public async Task<Dictionary<int, ICatalogDTO>> GetAllCatalogs()
        {
            return await _dataRepository.GetAllCatalogs();
        }

        public async Task<ICatalogDTO> GetCatalog(int id)
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
