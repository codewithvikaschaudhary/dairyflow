using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.InventoriesDto;
using DairyFlow.Data.Models;
using DairyFlow.Data.Repository;
using DairyFlow.Infrastructure.Commons;

namespace DairyFlow.Business.Providers
{
    public class InventoriesProvider : IInventoriesProvider
    {

        private readonly IRepository<Inventories> _inventoriesRepository;
        private readonly IRepository<Products> _productsRepository;
        private readonly IRepository<Users> _usersRepository;
        public InventoriesProvider(IRepository<Inventories> inventoriesRepository, IRepository<Products> productsRepository, IRepository<Users> usersRepository)
        {
            _inventoriesRepository = inventoriesRepository;
            _productsRepository = productsRepository;
            _usersRepository = usersRepository;
        }



        public InventoriesResponse GetInventoriesById(int id)
        {
            var data = (from inventory in _inventoriesRepository.GetAll()
                        join product in _productsRepository.GetAll() on inventory.ProductId equals product.Id
                        join createdUser in _usersRepository.GetAll() on inventory.CreatedBy equals createdUser.Id
                        join modifiedUser in _usersRepository.GetAll() on inventory.ModifiedBy equals modifiedUser.Id
                        where inventory.ProductId == id
                        select new InventoriesResponse
                        {
                            Id = inventory.Id,
                            ProductId = inventory.ProductId,
                            ProductName = product.Name,
                            CurrentStock = inventory.CurrentStock,
                            MinimumStock = inventory.MinimumStock,
                            CreatedBy = $"{createdUser.FirstName} {createdUser.LastName}",
                            ModifiedBy = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                        });
            var invResponse = data.FirstOrDefault();
            if (invResponse == null)
            {
                throw new Exception($"Inventories with ID {id} not found.");
            }
            return invResponse;
        }




        public List<InventoriesResponse> GetAllInventories(InventoriesFilters filters)
        {
            var query = (from inventory in _inventoriesRepository.GetAll()
                         join product in _productsRepository.GetAll() on inventory.ProductId equals product.Id
                         join createdUser in _usersRepository.GetAll() on inventory.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on inventory.ModifiedBy equals modifiedUser.Id
                         select new InventoriesResponse
                         {
                             Id = inventory.Id,
                             ProductId = inventory.ProductId,
                             ProductName = product.Name,
                             CurrentStock = inventory.CurrentStock,
                             MinimumStock = inventory.MinimumStock,
                             StockStatus = inventory.CurrentStock == 0 ? "Out Of Stock" : inventory.CurrentStock <= inventory.MinimumStock ? "Low Stock" : "In Stock",
                             CreatedBy = $"{createdUser.FirstName} {createdUser.LastName}",
                             ModifiedBy = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                         });


            if (filters.Id.HasValue)
            {
                query = query.Where(i => i.Id == filters.Id.Value);
            }
            if (filters.ProductId.HasValue)
            {
                query = query.Where(i => i.ProductId == filters.ProductId.Value);
            }
            if (!string.IsNullOrEmpty(filters.ProductName))
            {
                query = query.Where(i => i.ProductName.Contains(filters.ProductName));
            }
            if (filters.CurrentStock.HasValue)
            {
                query = query.Where(i => i.CurrentStock == filters.CurrentStock.Value);
            }
            if (filters.MinimumStock.HasValue)
            {
                query = query.Where(i => i.MinimumStock == filters.MinimumStock.Value);
            }
            if (!string.IsNullOrEmpty(filters.CreatedBy))
            {
                query = query.Where(i => i.CreatedBy.Contains(filters.CreatedBy));
            }
            if (!string.IsNullOrEmpty(filters.ModifiedBy))
            {
                query = query.Where(i => i.ModifiedBy.Contains(filters.ModifiedBy));
            }

            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }




        public async Task<Inventories> CreateInventories(CreateInventoriesRequest request)
        {
            var inventories = new Inventories
            {
                ProductId = request.ProductId,
                CurrentStock = request.CurrentStock,
                MinimumStock = request.MinimumStock,
                CreatedBy = request.CreatedBy,
                ModifiedBy = request.ModifiedBy,
            };
            await _inventoriesRepository.AddAsync(inventories);
            await _inventoriesRepository.SaveChangesAsync();
            return inventories;
        }




        public async Task<Inventories> UpdateInventories(int id, UpdateInventoriesRequest request)
        {
            var inventories = _inventoriesRepository.GetById(id);
            if (inventories == null)
            {
                throw new Exception($"Inventories with ID {id} not found.");
            }
            inventories.ProductId = request.ProductId;
            inventories.CurrentStock = request.CurrentStock;
            inventories.MinimumStock = request.MinimumStock;
            inventories.CreatedBy = request.CreatedBy;
            inventories.ModifiedBy = request.ModifiedBy;
            _inventoriesRepository.Update(inventories);
            await _inventoriesRepository.SaveChangesAsync();
            return inventories;
        }




        public async Task<int> DeleteInventories(int id)
        {
            var inventories = _inventoriesRepository.GetById(id);
            if (inventories == null)
            {
                throw new Exception($"Products with ID {id} not found.");
            }
            _inventoriesRepository.Delete(inventories);
            await _inventoriesRepository.SaveChangesAsync();
            return id;
        }




    }
}
