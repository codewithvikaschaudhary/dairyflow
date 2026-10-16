using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.SuppliersDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : Controller
    {
        private readonly ILogger<SuppliersController> _logger;
        private readonly ISuppliersProvider _suppliersProvider;

        public SuppliersController(ILogger<SuppliersController> logger, ISuppliersProvider suppliersProvider)
        {
            _logger = logger;
            _suppliersProvider = suppliersProvider;
        }

        [HttpGet("{id}")]
        public IActionResult GetSuppliersById(int id)
        {
            var result = _suppliersProvider.GetSuppliersById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllSuppliers([FromQuery] SuppliersFilters filters)
        {
            var result = _suppliersProvider.GetAllSuppliers(filters);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuppliers([FromBody] CreateSuppliersRequest request)
        {
            var result = await _suppliersProvider.CreateSuppliers(request);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSuppliers(int id, [FromBody] UpdateSuppliersRequest request)
        {
            var result = await _suppliersProvider.UpdateSuppliers(id, request);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuppliers(int id)
        {
            var result = await _suppliersProvider.DeleteSuppliers(id);
            return new OkObjectResult(result);

        }

    }

}
