using System;
using System.Linq.Expressions;
using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Specification
{
    internal class ProductSpecification : ISpecification<Product>
    {
        public Expression<Func<Product, bool>> Criteria { get; set; }
        public Expression<Func<Product, object>> OrderBy { get; set; }
        public Expression<Func<Product, object>> OrderByDescending { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
