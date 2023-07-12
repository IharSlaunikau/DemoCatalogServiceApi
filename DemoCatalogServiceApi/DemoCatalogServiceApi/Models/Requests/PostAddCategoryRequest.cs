using System.ComponentModel.DataAnnotations;

namespace DemoCatalogServiceApi.Models.Requests
{
    public class PostAddCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }
    }
}
