namespace Presentation.Model.API;

public interface IStateModel
{
    int StateId { get; set; }
    int CatalogId { get; set; }
    int Quantity { get; set; }
}
