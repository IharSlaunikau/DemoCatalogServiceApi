using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Content
{
    public sealed class NortwindContext : DbContext
    {
        public NortwindContext(DbContextOptions<NortwindContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade); // Set the onDelete behavior to Cascade
        }
    }
}
