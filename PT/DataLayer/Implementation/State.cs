using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class State : IState
    {

        public State(int id, int catalogid, decimal price)
        {
            this.StateId = id;
            this.CatalogId = catalogid;
            this.Price = price;
        }

        public int StateId { get; set; }
        public int CatalogId { get; set; }
        public decimal Price { get; set; }
    }
}
