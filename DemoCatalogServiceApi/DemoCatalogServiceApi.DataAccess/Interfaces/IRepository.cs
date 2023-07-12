using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(ISpecification<T> specification = null);

        Task CreateAsync(T entity);

        Task UpdateByIdAsync(int id, T entity);

        Task DeleteAsync(T entity);
    }
}
