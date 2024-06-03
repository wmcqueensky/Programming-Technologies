using Service.API;

namespace Service.Implementation;

internal class ProductDTO : IProductDTO
{
    public ProductDTO(int id, string name)
    {
        this.ProductId = id;
        this.Name = name;
    }
    public int ProductId { get; set; }
    public string Name { get; set; }
}
