using Presentation.Model.API;

namespace Presentation.Model.Implementation;

internal class ProductModel : IProductModel
{
    public ProductModel(int id, string name)
    {
        this.ProductId = id;
        this.Name = name;
    }
    public int ProductId { get; set; }
    public string Name { get; set; }
}
