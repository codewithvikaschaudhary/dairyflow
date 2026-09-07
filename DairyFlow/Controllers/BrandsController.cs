using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.BrandsDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : Controller
    {

        private readonly ILogger<BrandsController> _logger;
        private readonly IBrandsProvider _brandsProvider;

        public BrandsController(ILogger<BrandsController> logger, IBrandsProvider brandsProvider)
        {
            _logger = logger;
            _brandsProvider = brandsProvider;
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var result = _brandsProvider.GetBrandsById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllBrands([FromQuery]BrandsFilters filters)
        {
            var result = _brandsProvider.GetAllBrands(filters);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrands([FromBody] CreateBrandsRequest request)
        {
            var result = await _brandsProvider.CreateBrands(request);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrands(int id, [FromBody] UpdateBrandsRequest request)
        {
            var result = await _brandsProvider.UpdateBrands(id, request);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBrands(int id)
        {
            var result = await _brandsProvider.DeleteBrands(id);
            return new OkObjectResult(result);
        }


    }

}
