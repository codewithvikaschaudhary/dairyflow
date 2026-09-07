using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.StockTransactionDto;
using Microsoft.AspNetCore.Mvc;

namespace DairyFlow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockTransactionController : Controller
    {
        private readonly ILogger<StockTransactionController> _logger;
        private readonly IStockTransactionProvider _stockTransactionProvider;
        public StockTransactionController(ILogger<StockTransactionController> logger, IStockTransactionProvider stockTransactionProvider)
        {
            _logger = logger;
            _stockTransactionProvider = stockTransactionProvider;
        }


        [HttpGet("{id}")]
        public IActionResult GetStockTransactionById(int id)
        {
            var result = _stockTransactionProvider.GetStockTransactionById(id);
            return new OkObjectResult(result);
        }
        [HttpGet]
        public IActionResult GetAllStockTransactions([FromQuery] StockTransactionFilters filters)
        {
            var result = _stockTransactionProvider.GetAllStockTransaction(filters);
            return new OkObjectResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStockTransaction(CreateStockTransactionRequest request)
        {
            var result = await _stockTransactionProvider.CreateStockTransaction(request);
            return new OkObjectResult(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStockTransaction(int id, UpdateStockTransactionRequest request)
        {
            var result = await _stockTransactionProvider.UpdateStockTransaction(id, request);
            return new OkObjectResult(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockTransaction(int id)
        {
            var result = await _stockTransactionProvider.DeleteStockTransaction(id);
            return new OkObjectResult(result);
        }

    }
}
