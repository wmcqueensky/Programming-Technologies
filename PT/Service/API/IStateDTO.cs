namespace Service.API;

public interface IStateDTO
{
    int StateId { get; set; }
    int CatalogId { get; set; }
    int Quantity { get; set; }
}
