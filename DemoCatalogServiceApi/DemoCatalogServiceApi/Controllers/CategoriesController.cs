using AutoMapper;
using DemoCatalogServiceApi.DataAccess.Nortwind.Entities;
using DemoCatalogServiceApi.DataAccess.Nortwind.Interfaces;
using DemoCatalogServiceApi.Models.Requests;
using DemoCatalogServiceApi.Models.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoCatalogServiceApi.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private const string JsonContentType = "application/json";

        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoriesController
            (
                IRepository<Category> repository,
                IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Produces(JsonContentType)]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            return Ok(new GetCategoryResponse { Category = category });
        }

        [HttpGet]
        [Produces(JsonContentType)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repository.GetAllAsync();

            return Ok(new GetCategoriesResponse { Categories = categories });
        }

        [HttpPost]
        [Produces(JsonContentType)]
        public async Task<IActionResult> AddCategory([FromForm] PostAddCategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);

            await _repository.CreateAsync(category);

            return Ok(new GetCategoryResponse { Category = category });
        }

        [HttpPut("{id}")]
        [Produces(JsonContentType)]
        public async Task<IActionResult> EditById(int id, [FromForm] PutEditCategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            category.CategoryID = id;

            await _repository.UpdateByIdAsync(id, category);

            return Ok(new GetCategoryResponse { Category = category });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(category);

            return Ok(new GetCategoryResponse { Category = category });
        }
    }
}
