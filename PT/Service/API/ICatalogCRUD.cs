using DataLayer.API;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface ICatalogCRUD
    {
        static ICatalogCRUD CreateCatalogCRUD(IDataRepository? dataRepository = null)
        {
            return new CatalogCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
        }

        Task AddCatalog(int id, decimal price);
        Task<ICatalogDTO> GetCatalog(int id);
        Task UpdateCatalog(int id, decimal price);
        Task DeleteCatalog(int id);
        Task<Dictionary<int, ICatalogDTO>> GetAllCatalogs();
        Task<int> GetCatalogsCount();
    }
}
