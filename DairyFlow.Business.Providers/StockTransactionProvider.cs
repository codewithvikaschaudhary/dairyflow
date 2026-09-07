using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.StockTransactionDto;
using DairyFlow.Data.Models;
using DairyFlow.Data.Repository;
using DairyFlow.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Providers
{
    public class StockTransactionProvider : IStockTransactionProvider
    {

        private readonly IRepository<StockTransaction> _stockTransactionRepository;
        private readonly IRepository<Products> _productsRepository;
        private readonly IRepository<Users> _usersRepository;
        public StockTransactionProvider(IRepository<StockTransaction> stockTransactionRepository, IRepository<Products> productsRepository, IRepository<Users> usersRepository)
        {
            _stockTransactionRepository = stockTransactionRepository;
            _productsRepository = productsRepository;
            _usersRepository = usersRepository;
        }


        public StockTransactionResponse GetStockTransactionById(int id)
        {
            var query = (from stockTransaction in _stockTransactionRepository.GetAll()
                         join product in _productsRepository.GetAll() on stockTransaction.ProductId equals product.Id
                         join user in _usersRepository.GetAll() on stockTransaction.CreatedBy equals user.Id
                         where stockTransaction.Id == id
                         select new StockTransactionResponse
                         {
                             Id = stockTransaction.Id,
                             ProductId = stockTransaction.ProductId,
                             ProductName = product.Name,
                             TransactionType = stockTransaction.TransactionType,
                             Quantity = stockTransaction.Quantity,
                             ReferenceId = stockTransaction.ReferenceId,
                             Notes = stockTransaction.Notes,
                             CreatedBy = $"{user.FirstName} {user.LastName}",
                         });
            var data = query.FirstOrDefault();
            if (data == null)
            {
                throw new Exception($"Stock Transaction with ID {id} not found.");
            }
            return data;
        }
        public List<StockTransactionResponse> GetAllStockTransaction(StockTransactionFilters filters)
        {
            var query = (from stockTransaction in _stockTransactionRepository.GetAll()
                         join product in _productsRepository.GetAll() on stockTransaction.ProductId equals product.Id
                         join user in _usersRepository.GetAll() on stockTransaction.CreatedBy equals user.Id
                         select new StockTransactionResponse
                         {
                             Id = stockTransaction.Id,
                             ProductId = stockTransaction.ProductId,
                             ProductName = product.Name,
                             TransactionType = stockTransaction.TransactionType,
                             Quantity = stockTransaction.Quantity,
                             ReferenceId = stockTransaction.ReferenceId,
                             Notes = stockTransaction.Notes,
                             CreatedBy = $"{user.FirstName} {user.LastName}",
                         });
            if (filters.Id.HasValue)
            {
                query = query.Where(x => x.Id == filters.Id.Value);
            }
            if (filters.ProductId.HasValue)
            {
                query = query.Where(x => x.ProductId == filters.ProductId.Value);
            }
            if (filters.TransactionType.HasValue)
            {
                query = query.Where(x => x.TransactionType == filters.TransactionType.Value);
            }
            
            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }

        public async Task<StockTransaction> CreateStockTransaction(CreateStockTransactionRequest request)
        {
            var stockTransaction = new StockTransaction
            {
                ProductId = request.ProductId,
                TransactionType = request.TransactionType,
                Quantity = request.Quantity,
                ReferenceId = request.ReferenceId,
                Notes = request.Notes,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.UtcNow
            };
            await _stockTransactionRepository.AddAsync(stockTransaction);
            await _stockTransactionRepository.SaveChangesAsync();
            return stockTransaction;
        }

        public async Task<StockTransaction> UpdateStockTransaction(int id, UpdateStockTransactionRequest request)
        {
            var stockTransaction = _stockTransactionRepository.GetById(id);
            if (stockTransaction == null)
            {
                throw new Exception($"Stock Transaction with ID {id} not found.");
            }
            stockTransaction.ProductId = request.ProductId;
            stockTransaction.TransactionType = request.TransactionType;
            stockTransaction.Quantity = request.Quantity;
            stockTransaction.ReferenceId = request.ReferenceId;
            stockTransaction.Notes = request.Notes;
            _stockTransactionRepository.Update(stockTransaction);
            await _stockTransactionRepository.SaveChangesAsync();
            return stockTransaction;
        }

        public async Task<int> DeleteStockTransaction(int id)
        {
            var stockTransaction = _stockTransactionRepository.GetById(id);
            if (stockTransaction == null)
            {
                throw new Exception($"Stock Transaction with ID {id} not found.");
            }
            _stockTransactionRepository.Delete(stockTransaction);
            await _stockTransactionRepository.SaveChangesAsync();
            return id;
        }

    }
}
