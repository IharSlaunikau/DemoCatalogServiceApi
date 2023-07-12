using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Entities
{
    public class Category
    {
        [Column("CategoryID")]
        public int CategoryID { get; set; }

        [Column("CategoryName")]
        public string CategoryName { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Picture")]
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
