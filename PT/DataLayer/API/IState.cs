namespace DataLayer.API
{
    public interface IState
    {
        int StateId { get; set; }
        int CatalogId { get; set; }
        int Quantity { get; set; }
    }
}
