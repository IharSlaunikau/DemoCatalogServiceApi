namespace DemoCatalogServiceApi.DataAccess.Nortwind.Model
{
    public class ProductCriteriaInput
    {
        public int? CategoryId { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
