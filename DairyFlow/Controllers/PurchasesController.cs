using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.PurchaseDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchasesController : Controller
    {

        private readonly ILogger<PurchasesController> _logger;
        private readonly IPurchasesProvider _purchasesProvider;

        public PurchasesController(ILogger<PurchasesController> logger, IPurchasesProvider purchasesProvider)
        {
            _logger = logger;
            _purchasesProvider = purchasesProvider;
        }


        [HttpGet("{id}")]
        public IActionResult GetPurchaseById(int id)
        {
            var result = _purchasesProvider.GetPurchasesById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllPurchases([FromQuery] PurchasesFilters filters)
        {
            var result = _purchasesProvider.GetAllPurchases(filters);
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchase(CreatePurchasesRequest request)
        {
            var result = await _purchasesProvider.CreatePurchases(request);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, UpdatePurchasesRequest request)
        {
            var result = await _purchasesProvider.UpdatePurchases(id, request);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var result = await _purchasesProvider.DeletePurchases(id);
            return new OkObjectResult(result);
        }


    }
}
