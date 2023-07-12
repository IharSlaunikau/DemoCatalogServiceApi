using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;

namespace DemoCatalogServiceApi.Models.Responses
{
    public class GetProductsResponse
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
