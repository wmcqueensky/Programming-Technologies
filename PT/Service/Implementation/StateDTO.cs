using Service.API;

namespace Service.Implementation;

internal class StateDTO : IStateDTO
{
    public StateDTO(int id, int catalogid, int quantity)
    {
        this.StateId = id;
        this.CatalogId = catalogid;
        this.Quantity = quantity;
    }

    public int StateId { get; set; }
    public int CatalogId { get; set; }
    public int Quantity { get; set; }
}
