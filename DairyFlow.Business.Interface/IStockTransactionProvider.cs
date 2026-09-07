using DairyFlow.Data.Dtos.ProductsDto;
using DairyFlow.Data.Dtos.StockTransactionDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface IStockTransactionProvider
    {

        StockTransactionResponse GetStockTransactionById(int id);
        List<StockTransactionResponse> GetAllStockTransaction(StockTransactionFilters filters);
        Task<StockTransaction> CreateStockTransaction(CreateStockTransactionRequest  request);
        Task<StockTransaction> UpdateStockTransaction(int id, UpdateStockTransactionRequest request);
        Task<int> DeleteStockTransaction(int id);

    }
}
