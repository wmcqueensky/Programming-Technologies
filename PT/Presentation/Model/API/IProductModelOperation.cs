using DataLayer.API;
using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IProductModelOperation
{
    static IProductModelOperation CreateModelOperation(IProductCRUD? productCrud = null)
    {
        return new ProductModelOperation(productCrud ?? IProductCRUD.CreateProductCRUD());
    }

    Task AddProduct(int id, string name);
    Task UpdateProduct(int id, string name);

    Task DeleteProduct(int id);

    Task<Dictionary<int, IProductModel>> GetAllProducts();

    Task<int> GetProductsCount();
}
