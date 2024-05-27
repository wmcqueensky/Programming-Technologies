using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class State : IState
    {

        public State(int id, int catalogid, int price)
        {
            this.StateId = id;
            this.CatalogId = catalogid;
            this.Quantity = price;
        }

        public int StateId { get; set; }
        public int CatalogId { get; set; }
        public int Quantity { get; set; }
    }
}
