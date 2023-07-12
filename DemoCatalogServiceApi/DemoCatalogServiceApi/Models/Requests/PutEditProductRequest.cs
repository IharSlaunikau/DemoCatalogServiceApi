using System.ComponentModel.DataAnnotations;

namespace DemoCatalogServiceApi.Models.Requests
{
    public class PutEditProductRequest
    {
        [Required]
        public string ProductName { get; set; }

        public int SupplierID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public short UnitsInStock { get; set; }

        public short UnitsOnOrder { get; set; }

        public short ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }

        public int? CategoryID { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
