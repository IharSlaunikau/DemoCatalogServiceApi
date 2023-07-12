using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces;
using DemoCatalogServiceApi.DataAccess.Nortwind.Specification;
using Microsoft.EntityFrameworkCore;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private const int Offset = 1;

        private readonly DbContext _nortwindContext;
        private bool _isDisposed;

        public ProductRepository(DbContext dbcontext)
        {
            _nortwindContext = dbcontext;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _nortwindContext.Set<Product>().FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _nortwindContext.Set<Product>().ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> FindAsync(ISpecification<Product> specification = null)
        {
            var query = SpecificationEvaluator<Product>
                .GetQuery(_nortwindContext.Set<Product>().AsQueryable(), specification);

            if (specification is ProductSpecification productSpecification)
            {
                query = query.Skip((productSpecification.PageNumber - Offset) * productSpecification.PageSize)
                    .Take(productSpecification.PageSize);
            }

            return await query.ToListAsync();

        }

        public async Task CreateAsync(Product model)
        {
            await _nortwindContext.AddAsync(model);
            await _nortwindContext.SaveChangesAsync();
        }

        public async Task UpdateByIdAsync(int id, Product entity)
        {
            _nortwindContext.Entry(await GetByIdAsync(id)).CurrentValues.SetValues(entity);
            await _nortwindContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product model)
        {
            _nortwindContext.Remove(model);
            await _nortwindContext.SaveChangesAsync();
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                // free managed resources
                _nortwindContext.Dispose();
            }

            _isDisposed = true;
        }

        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
