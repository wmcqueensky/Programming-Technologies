using DataLayer.API;
using Service.Implementation;

namespace Service.API;

public interface IProductCRUD
{
    static IProductCRUD CreateProductCRUD(IDataRepository? dataRepository = null)
    {
        return new ProductCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
    }

    Task AddProduct(int id, string name);

    Task<IProductDTO> GetProduct(int id);

    Task UpdateProduct(int id, string name);

    Task DeleteProduct(int id);

    Task<Dictionary<int, IProductDTO>> GetAllProducts();

    Task<int> GetProductsCount();
}
