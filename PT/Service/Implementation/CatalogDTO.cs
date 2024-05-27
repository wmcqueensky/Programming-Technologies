using DataLayer.API;
using Service.API;


namespace Service.Implementation
{
    internal class CatalogDTO : ICatalogDTO
    {
        public CatalogDTO(int id, decimal price)
        {
            this.CatalogId = id;
            this.Price = price;
        }
        public int CatalogId { get; set; }
        public decimal Price { get; set; }
    }
}
