using System;
using System.Linq;
using DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Specification
{
    internal static class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            if (inputQuery == null)
                throw new ArgumentNullException(nameof(inputQuery));

            var query = inputQuery;

            if (spec?.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec?.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec?.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            return query;
        }
    }
}
