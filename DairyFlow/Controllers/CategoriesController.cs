using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.CategoriesDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {

        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoriesProvider _categoriesProvider;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoriesProvider categoriesProvider)
        {
            _logger = logger;
            _categoriesProvider = categoriesProvider;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoriesById(int id)
        {
            var result = _categoriesProvider.GetCategoriesById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllCategories([FromQuery] CategoriesFilters filters)
        {
            var result = _categoriesProvider.GetAllCategories(filters);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategories([FromBody] CreateCategoriesRequest request)
        {
            var result = await _categoriesProvider.CreateCategories(request);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategories(int id, [FromBody] UpdateCategoriesRequest request)
        {
            var result = await _categoriesProvider.UpdateCategories(id, request);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategories(int id)
        {
            var result = await _categoriesProvider.DeleteCategories(id);
            return new OkObjectResult(result);
        }

    }
}
