using DataLayer.API;
using Presentation.Model.Implementation;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface ICatalogModelOperation
    {
        static ICatalogModelOperation CreateModelOperation(ICatalogCRUD? catalogCrud = null)
        {
            return new CatalogModelOperation(catalogCrud ?? ICatalogCRUD.CreateCatalogCRUD());
        }

        Task AddCatalog(int id, decimal price);
        Task<ICatalogModel> GetCatalog(int id);
        Task UpdateCatalog(int id, decimal price);
        Task DeleteCatalog(int id);
        Task<Dictionary<int, ICatalogModel>> GetAllCatalogs();
        Task<int> GetCatalogsCount();
    }
}
