using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.UnitsDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : Controller
    {
        private readonly ILogger<UnitsController> _logger;
        private readonly IUnitsProvider _unitsProvider;

        public UnitsController(ILogger<UnitsController> logger, IUnitsProvider unitsProvider)
        {
            _logger = logger;
            _unitsProvider = unitsProvider;
        }

        [HttpGet("{id}")]
        public IActionResult GetUnitById(int id)
        {
            var result = _unitsProvider.GetUnitsById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllUnit([FromQuery] UnitsFilters filters)
        {
            var result = _unitsProvider.GetAllUnits(filters);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnit([FromBody] CreateUnitsRequest request)
        {
            var result = await _unitsProvider.CreateUnits(request);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnit(int id, [FromBody] UpdateUnitsRequest request)
        {
            var result = await _unitsProvider.UpdateUnits(id, request);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            var result = await _unitsProvider.DeleteUnits(id);
            return new OkObjectResult(result);
        }


    }
}
