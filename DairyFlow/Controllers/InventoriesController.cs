using DairyFlow.Business.Interfaces;
using DairyFlow.Business.Providers;
using DairyFlow.Data.Dtos.InventoriesDto;
using DairyFlow.Data.Dtos.ProductsDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoriesController : Controller
    {

        private readonly ILogger<InventoriesController> _logger;
        private readonly IInventoriesProvider _inventoriesProvider;

        public InventoriesController(ILogger<InventoriesController> logger, IInventoriesProvider inventoriesProvider)
        {
            _logger = logger;
            _inventoriesProvider = inventoriesProvider;
        }

        [HttpGet("{id}")]
        public IActionResult GetInventoriesById(int id)
        {
            var result = _inventoriesProvider.GetInventoriesById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllInventories([FromQuery] InventoriesFilters filters)
        {
            var result = _inventoriesProvider.GetAllInventories(filters);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventories(CreateInventoriesRequest request)
        {
            var result = await _inventoriesProvider.CreateInventories(request);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventories(int id, UpdateInventoriesRequest request)
        {
            var result = await _inventoriesProvider.UpdateInventories(id, request);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventories(int id)
        {
            var result = await _inventoriesProvider.DeleteInventories(id);
            return new OkObjectResult(result);
        }
    }
}
 