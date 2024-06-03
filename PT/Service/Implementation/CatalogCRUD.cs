using DataLayer.API;
using DataLayer.Instrumentation;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    internal class CatalogCRUD : ICatalogCRUD
    {
        private IDataRepository _repository;

        public CatalogCRUD(IDataRepository repository)
        {
            this._repository = repository;
        }

        public ICatalogDTO Map(ICatalog currentEvent)
        {
            return new CatalogDTO(currentEvent.CatalogId, currentEvent.Price);
        }
        public async Task AddCatalog(int id, decimal price)
        {
            await this._repository.UpdateCatalog(id, price);
        }

        public async Task DeleteCatalog(int id)
        {
            await this._repository.DeleteCatalog(id);
        }

        public async Task<Dictionary<int, ICatalogDTO>> GetAllCatalogs()
        {
            Dictionary<int, ICatalogDTO> result = new Dictionary<int, ICatalogDTO>();

            foreach (ICatalog currentEvent in (await this._repository.GetAllCatalogs()).Values)
            {
                result.Add(currentEvent.CatalogId, this.Map(currentEvent));
            }

            return result;
        }

        public async Task<ICatalogDTO> GetCatalog(int id)
        {
            return this.Map(await this._repository.GetCatalog(id));
        }

        public async Task<int> GetCatalogsCount()
        {
            return await this._repository.GetCatalogsCount();
        }

        public async Task UpdateCatalog(int id, decimal price)
        {
            await this._repository.UpdateCatalog(id, price);
        }
    }
}
