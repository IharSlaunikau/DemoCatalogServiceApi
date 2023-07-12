using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces;
using DemoCatalogServiceApi.DataAccess.Nortwind.Specification;
using Microsoft.EntityFrameworkCore;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DbContext _nortwindContext;
        private bool _isDisposed;

        public CategoryRepository(DbContext dbcontext)
        {
            _nortwindContext = dbcontext;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _nortwindContext.Set<Category>().FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _nortwindContext.Set<Category>().ToArrayAsync();
        }

        public async Task<IEnumerable<Category>> FindAsync(ISpecification<Category> specification = null)
        {
            return await SpecificationEvaluator<Category>
                .GetQuery(_nortwindContext.Set<Category>()
                    .AsQueryable(), specification).ToArrayAsync();
        }

        public async Task CreateAsync(Category model)
        {
            await _nortwindContext.AddAsync(model);
            await _nortwindContext.SaveChangesAsync();
        }

        public async Task UpdateByIdAsync(int id, Category entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _nortwindContext.Entry(await GetByIdAsync(id)).CurrentValues.SetValues(entity);
            await _nortwindContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category model)
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
