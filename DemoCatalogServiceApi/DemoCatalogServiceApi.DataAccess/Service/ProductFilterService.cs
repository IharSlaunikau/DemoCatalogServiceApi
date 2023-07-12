using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces;
using DemoCatalogServiceApi.DataAccess.Nortwind.Model;
using DemoCatalogServiceApi.DataAccess.Nortwind.Specification;

namespace DemoCatalogServiceApi.DataAccess.Nortwind.Service
{
    public class ProductFilterService : IFilterService<Product, ProductCriteriaInput>
    {
        private readonly IRepository<Product> _repository;

        public ProductFilterService(IRepository<Product> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Product>> GetDataAsync(ProductCriteriaInput criteriaFilterInput)
        {
            if (criteriaFilterInput == null)
                throw new ArgumentNullException(nameof(criteriaFilterInput));

            var specification = CreateSpecification(criteriaFilterInput);

            var products = await _repository.FindAsync(specification);

            return products;
        }

        private static ProductSpecification CreateSpecification(ProductCriteriaInput productCriteria)
        {
            var specifications = new ProductSpecification
            {
                Criteria = m => m.CategoryID == productCriteria.CategoryId,
                OrderBy = m => m.ProductName,
                PageNumber = productCriteria.PageNumber,
                PageSize = productCriteria.PageSize
            };

            return specifications;
        }
    }
}
