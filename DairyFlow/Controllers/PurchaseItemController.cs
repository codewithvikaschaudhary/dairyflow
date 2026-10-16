using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.PurchaseItemDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PurchaseItemController : Controller
    {
        
        private readonly ILogger<PurchaseItemController> _logger;
        private readonly IPurchaseItemsProvider _purchaseItemsProvider;

        public PurchaseItemController(ILogger<PurchaseItemController> logger, IPurchaseItemsProvider purchaseItemsProvider)
        {
            _logger = logger;
            _purchaseItemsProvider = purchaseItemsProvider;
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchaseItemById(int id)
        {
            var result = _purchaseItemsProvider.GetPurchaseItemById(id);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult GetAllPurchaseItems([FromQuery] PurchaseItemFilters filters)
        {
            var result = _purchaseItemsProvider.GetAllPurchaseItems(filters);
            return new OkObjectResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> CreatePurchaseItem([FromBody] CreatePurchaseItemRequest request)
        {
            var result = await _purchaseItemsProvider.CreatePurchaseItem(request);
            return new OkObjectResult(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdatePurchaseItem(int id, [FromBody] UpdatePurchaseItemRequest request)
        {
            var result = await _purchaseItemsProvider.UpdatePurchaseItem(id, request);
            return new OkObjectResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseItem(int id)
        {
            var result = await _purchaseItemsProvider.DeletePurchaseItem(id);
            return new OkObjectResult(result);

        }
    
    }
}
