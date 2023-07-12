using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Entities
{
    public class Product
    {
        [Column("ProductID")]
        public int ProductID { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("SupplierID")]
        public int SupplierID { get; set; }

        [Column("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Column("UnitPrice", TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }

        [Column("UnitsInStock")]
        public short UnitsInStock { get; set; }

        [Column("UnitsOnOrder")]
        public short UnitsOnOrder { get; set; }

        [Column("ReorderLevel")]
        public short ReorderLevel { get; set; }

        [Column("Discontinued")]
        public bool Discontinued { get; set; }

        [Column("CategoryID")]
        public int? CategoryID { get; set; }


        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
