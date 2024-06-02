using Presentation.Model.API;

namespace PresentationTests.Mocks
{
    internal class MockProductDTO : IProductModel
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
