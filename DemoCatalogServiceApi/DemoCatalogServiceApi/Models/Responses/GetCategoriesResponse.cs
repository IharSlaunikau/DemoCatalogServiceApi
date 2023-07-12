using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;

namespace DemoCatalogServiceApi.Models.Responses
{
    public class GetCategoriesResponse
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
