using DataLayer.API;
using Presentation.Model.API;
using Service.API;

namespace Presentation.Model.Implementation;

internal class ProductModelOperation : IProductModelOperation
{
    private IProductCRUD _productCRUD;

    public ProductModelOperation(IProductCRUD? stateCrud = null)
    {
        this._productCRUD = stateCrud ?? IProductCRUD.CreateProductCRUD();
    }

    private IProductModel Map(IProductDTO product)
    {
        return new ProductModel(product.ProductId, product.Name);
    }

    public async Task AddProduct(int id, string name)
    {
        await this._productCRUD.AddProduct(id, name);
    }

    public async Task UpdateProduct(int id, string name)
    {
        await this._productCRUD.UpdateProduct(id, name);
    }

    public async Task DeleteProduct(int id)
    {
        await this._productCRUD.DeleteProduct(id);
    }

    public async Task<IProductModel> GetProduct(int id)
    {
        return this.Map(await this._productCRUD.GetProduct(id));
    }

    public async Task<Dictionary<int, IProductModel>> GetAllProducts()
    {
        Dictionary<int, IProductModel> result = new Dictionary<int, IProductModel>();

        foreach (IProductDTO product in (await this._productCRUD.GetAllProducts()).Values)
        {
            result.Add(product.ProductId, this.Map(product));
        }

        return result;
    }

    public async Task<int> GetProductsCount()
    {
        return await this._productCRUD.GetProductsCount();
    }
}
