using System;
using System.Linq.Expressions;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; set; }

        Expression<Func<T, object>> OrderBy { get; set; }

        Expression<Func<T, object>> OrderByDescending { get; set; }
    }
}
