using Presentation.Model.API;

namespace Presentation.Model.Implementation;

internal class StateModel : IStateModel
{
    public StateModel(int id, int catalogid, int quantity)
    {
        this.StateId = id;
        this.CatalogId = catalogid;
        this.Quantity = quantity;
    }

    public int StateId { get; set; }
    public int CatalogId { get; set; }
    public int Quantity { get; set; }
}
