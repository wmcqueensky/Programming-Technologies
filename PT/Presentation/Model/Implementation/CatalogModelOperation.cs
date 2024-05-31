using DataLayer.Implementation;
using DataLayer.Instrumentation;
using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class CatalogModelOperation : ICatalogModelOperation
    {
        private ICatalogCRUD _catalogCrud;

        public CatalogModelOperation(ICatalogCRUD? catalogCrud = null)
        {
            this._catalogCrud = catalogCrud ?? ICatalogCRUD.CreateCatalogCRUD();
        }

        private ICatalogModel Map(ICatalogDTO catalog)
        {
            return new CatalogModel(catalog.CatalogId, catalog.Price);
        }

        public async Task AddCatalog(int id, decimal price)
        {
            await this._catalogCrud.AddCatalog(id, price);
        }

        public async Task DeleteCatalog(int id)
        {
            await this._catalogCrud.DeleteCatalog(id);
        }

        public async Task<Dictionary<int, ICatalogModel>> GetAllCatalogs()
        {
            Dictionary<int, ICatalogModel> result = new Dictionary<int, ICatalogModel>();

            foreach (ICatalogDTO catalog in (await this._catalogCrud.GetAllCatalogs()).Values)
            {
                result.Add(catalog.CatalogId, this.Map(catalog));
            }

            return result;
        }

        public async Task<ICatalogModel> GetCatalog(int id)
        {
            return this.Map(await this._catalogCrud.GetCatalog(id));
        }

        public async Task<int> GetCatalogsCount()
        {
            return await this._catalogCrud.GetCatalogsCount();
        }

        public async Task UpdateCatalog(int id, decimal price)
        {
            await this._catalogCrud.UpdateCatalog(id, price);
        }
    }
}
