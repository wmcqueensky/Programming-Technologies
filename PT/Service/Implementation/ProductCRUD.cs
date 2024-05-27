using DataLayer.API;
using Service.API;

namespace Service.Implementation;

internal class ProductCRUD : IProductCRUD
{
    private IDataRepository _repository;

    public ProductCRUD(IDataRepository repository)
    {
        this._repository = repository;
    }

    private IProductDTO Map(IProduct product)
    {
        return new ProductDTO(product.ProductId, product.Name);
    }

    public async Task AddProduct(int id, string name)
    {
        await this._repository.AddProduct(id, name);
    }

    public async Task<IProductDTO> GetProduct(int id)
    {
        return this.Map(await this._repository.GetProduct(id));
    }

    public async Task UpdateProduct(int id, string name)
    {
        await this._repository.UpdateProduct(id, name);
    }

    public async Task DeleteProduct(int id)
    {
        await this._repository.DeleteProduct(id);
    }

    public async Task<Dictionary<int, IProductDTO>> GetAllProducts()
    {
        Dictionary<int, IProductDTO> result = new Dictionary<int, IProductDTO>();

        foreach (IProduct product in (await this._repository.GetAllProducts()).Values)
        {
            result.Add(product.ProductId, this.Map(product));
        }

        return result;
    }

    public async Task<int> GetProductsCount()
    {
        return await this._repository.GetProductsCount();
    }
}
