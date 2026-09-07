using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.ProductsDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {

        private readonly ILogger<ProductsController> _logger;   
        private readonly IProductsProvider _productsProvider;

        public ProductsController(ILogger<ProductsController> logger, IProductsProvider productsProvider)
        {
            _logger = logger;
            _productsProvider = productsProvider;
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _productsProvider.GetProductsById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllProducts([FromQuery]ProductsFilters filters)
        {
            var result = _productsProvider.GetAllProducts(filters);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductsRequest request)
        {
            var result = await _productsProvider.CreateProducts(request);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductsRequest request)
        {
            var result = await _productsProvider.UpdateProducts(id, request);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productsProvider.DeleteProducts(id);
            return new OkObjectResult(result);
        }

    }
}
