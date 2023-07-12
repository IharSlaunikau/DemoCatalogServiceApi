using AutoMapper;
using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces;
using DemoCatalogServiceApi.DataAccess.Nortwind.Model;
using DemoCatalogServiceApi.Models.Requests;
using DemoCatalogServiceApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoCatalogServiceApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string JsonContentType = "application/json";
        private const int DefaultPageSize = 10;
        private const int DefaultPageNumber = 1;

        private readonly IRepository<Product> _repository;
        private readonly IFilterService<Product, ProductCriteriaInput> _filterService;

        private readonly IMapper _mapper;

        public ProductsController
            (
                IRepository<Product> repository,
                IFilterService<Product, ProductCriteriaInput> filterService,
                IMapper mapper
            )
        {
            _repository = repository;
            _filterService = filterService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Produces(JsonContentType)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            return Ok(new GetProductResponse { Product = product });
        }

        [HttpGet]
        [Produces(JsonContentType)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            return Ok(new GetProductsResponse { Products = products });
        }

        [HttpGet("filtered")]
        [Produces(JsonContentType)]
        public async Task<IActionResult> GetFilteredAsync
            (
                [FromQuery] int? categoryId,
                [FromQuery] int pageNumber = DefaultPageNumber,
                [FromQuery] int pageSize = DefaultPageSize
            )
        {
            var input = new ProductCriteriaInput
            {
                CategoryId = categoryId,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };

            var products = await _filterService.GetDataAsync(input);

            return Accepted(new GetProductsResponse { Products = products });
        }

        [HttpPost]
        [Produces(JsonContentType)]
        public async Task<IActionResult> AddProduct([FromForm] PostAddProductRequest modelRequest)
        {
            var product = _mapper.Map<Product>(modelRequest);

            await _repository.CreateAsync(product);

            return Ok(new GetProductResponse { Product = product });
        }

        [HttpDelete("{id}")]
        [Produces(JsonContentType)]
        public async Task<IActionResult> EditById(int id, [FromForm] PutEditProductRequest modelRequest)
        {
            var product = _mapper.Map<Product>(modelRequest);
            product.ProductID = id;

            await _repository.UpdateByIdAsync(id, product);

            return Ok(new GetProductResponse { Product = product });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(product);

            return Ok(new GetProductResponse { Product = product });
        }
    }
}
