using System.ComponentModel.DataAnnotations;

namespace DemoCatalogServiceApi.Models.Responses
{
    public class GetFilteredProductsResponse
    {
        public int? CategoryId { get; set; }
        [Required]
        public int PageNumber { get; set; }
        [Required]
        public int PageSize { get; set; }
    }
}
