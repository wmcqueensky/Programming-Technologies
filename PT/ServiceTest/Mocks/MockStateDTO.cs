using Service.API;

namespace ServiceTest.FakeItems
{
    internal class MockStateDTO : IStateDTO
    {
        public int StateId { get; set; }
        public int CatalogId { get; set; }
        public int Quantity { get; set; }
        public MockStateDTO(int id, int catalogid, int quantity)
        {
            this.StateId = id;
            this.CatalogId = catalogid;
            this.Quantity = quantity;
        }

        
    }
}
