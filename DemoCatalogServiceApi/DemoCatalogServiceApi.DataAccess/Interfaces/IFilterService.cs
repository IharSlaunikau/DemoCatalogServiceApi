using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces
{
    public interface IFilterService<TEntity, in TCriteria>
        where TEntity : class
        where TCriteria : class
    {
        Task<IEnumerable<TEntity>> GetDataAsync(TCriteria criteriaFilterInfo);
    }
}
