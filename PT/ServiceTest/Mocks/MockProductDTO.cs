using Service.API;

namespace ServiceTest.FakeItems
{
    internal class MockProductDTO : IProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public MockProductDTO(int id, string name)
        {
            this.ProductId = id;
            this.Name = name;
        }
        
    }
}
