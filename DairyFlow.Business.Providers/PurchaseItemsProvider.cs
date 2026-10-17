using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.PurchaseItemDto;
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
    public class PurchaseItemsProvider : IPurchaseItemsProvider
    {
        private readonly IRepository<PurchaseItem> _purchaseItemRepository;
        private readonly IRepository<Purchases> _purchasesRepository;
        private readonly IRepository<Products> _productsRepository;
        private readonly IRepository<Users> _usersRepository;

        public PurchaseItemsProvider(IRepository<PurchaseItem> purchaseItemRepository, IRepository<Purchases> purchasesRepository, IRepository<Products> productsRepository, IRepository<Users> usersRepository)
        {
            _purchaseItemRepository = purchaseItemRepository;
            _purchasesRepository = purchasesRepository;
            _productsRepository = productsRepository;
            _usersRepository = usersRepository;
        }

        public PurchaseItemResponse GetPurchaseItemById(int id)
        {
            var query = (from purchaseItem in _purchaseItemRepository.GetAll()
                        join purchase in _purchasesRepository.GetAll() on purchaseItem.PurchaseId equals purchase.Id
                        join product in _productsRepository.GetAll() on purchaseItem.ProductId equals product.Id
                        join createdUser in _usersRepository.GetAll() on purchaseItem.CreatedBy equals createdUser.Id
                        join modifiedUser in _usersRepository.GetAll() on purchaseItem.ModifiedBy equals modifiedUser.Id into modifiedUsers
                        from modifiedUser in modifiedUsers.DefaultIfEmpty()
                        where purchaseItem.Id == id
                         select new PurchaseItemResponse
                         {
                             Id = purchaseItem.Id,
                             PurchaseId = purchaseItem.PurchaseId,
                             InvoiceNumber = purchase.InvoiceNumber,
                             ProductId = purchaseItem.ProductId,
                             ProductName = product.Name,
                             Quantity = purchaseItem.Quantity,
                             UnitPrice = purchaseItem.UnitPrice,
                             Discount = purchaseItem.Discount,
                             TaxAmount = purchaseItem.TaxAmount,
                             TotalAmount = purchaseItem.TotalAmount,
                             CreatedByName = $"{createdUser.FirstName} {createdUser.LastName}",
                             ModifiedByName = modifiedUser != null ? $"{modifiedUser.FirstName} {modifiedUser.LastName}" : null
                         });

            var purchaseItems = query.FirstOrDefault();
            if (purchaseItems == null)
            {
                throw new Exception($"PurchaseItem with Id {id} not found.");
            }
            return purchaseItems;

        }

        public List<PurchaseItemResponse> GetAllPurchaseItems(PurchaseItemFilters filters)
        {
            var query = (from purchaseItem in _purchaseItemRepository.GetAll()
                         join purchase in _purchasesRepository.GetAll() on purchaseItem.PurchaseId equals purchase.Id
                         join product in _productsRepository.GetAll() on purchaseItem.ProductId equals product.Id
                         join createdUser in _usersRepository.GetAll() on purchaseItem.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on purchaseItem.ModifiedBy equals modifiedUser.Id into modifiedUsers
                         from modifiedUser in modifiedUsers.DefaultIfEmpty()
                         select new PurchaseItemResponse
                         {
                             Id = purchaseItem.Id,
                             PurchaseId = purchaseItem.PurchaseId,
                             InvoiceNumber = purchase.InvoiceNumber,
                             ProductId = purchaseItem.ProductId,
                             ProductName = product.Name,
                             Quantity = purchaseItem.Quantity,
                             UnitPrice = purchaseItem.UnitPrice,
                             Discount = purchaseItem.Discount,
                             TaxAmount = purchaseItem.TaxAmount,
                             TotalAmount = purchaseItem.TotalAmount,
                             CreatedByName = $"{createdUser.FirstName} {createdUser.LastName}",
                             ModifiedByName = modifiedUser != null ? $"{modifiedUser.FirstName} {modifiedUser.LastName}" : null,
                             ModifiedDate = purchaseItem.ModifiedDate
                         });
            if (filters.Id.HasValue)
            {
                query = query.Where(pi => pi.Id == filters.Id.Value);
            }
            if (filters.PurchaseId.HasValue)
            {
                query = query.Where(pi => pi.PurchaseId == filters.PurchaseId.Value);
            }
            if (filters.ProductId.HasValue)
            {
                query = query.Where(pi => pi.ProductId == filters.ProductId.Value);
            }
            if (!string.IsNullOrEmpty(filters.ProductName))
            {
                query = query.Where(pi => pi.ProductName.Contains(filters.ProductName));
            }

            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }

        public async Task<PurchaseItem> CreatePurchaseItem(CreatePurchaseItemRequest request)
        {
            var purchaseItem = new PurchaseItem
            {
                PurchaseId = request.PurchaseId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                Discount = request.Discount,
                TaxAmount = request.TaxAmount,
                TotalAmount = request.TotalAmount,
                CreatedBy = request.CreatedBy,
            };
            await _purchaseItemRepository.AddAsync(purchaseItem);
            await _purchaseItemRepository.SaveChangesAsync();
            return purchaseItem;
        }

        public async Task<PurchaseItem> UpdatePurchaseItem(int id, UpdatePurchaseItemRequest request)
        {
            var purchaseItem = _purchaseItemRepository.GetById(id);
            if (purchaseItem == null)
            {
                throw new Exception($"PurchaseItem with Id {id} not found.");
            }
            purchaseItem.PurchaseId = request.PurchaseId;
            purchaseItem.ProductId = request.ProductId;
            purchaseItem.Quantity = request.Quantity;
            purchaseItem.UnitPrice = request.UnitPrice;
            purchaseItem.Discount = request.Discount;
            purchaseItem.TaxAmount = request.TaxAmount;
            purchaseItem.TotalAmount = request.TotalAmount;
            purchaseItem.ModifiedBy = request.ModifiedBy;
            purchaseItem.ModifiedDate = DateTime.Now;
            _purchaseItemRepository.Update(purchaseItem);
            await _purchaseItemRepository.SaveChangesAsync();
            return purchaseItem;
        }

        public async Task<int> DeletePurchaseItem(int id)
        {
            var purchaseItem = _purchaseItemRepository.GetById(id);
            if (purchaseItem == null)
            {
                throw new Exception($"PurchaseItem with Id {id} not found.");
            }
            _purchaseItemRepository.Delete(purchaseItem);
            await _purchaseItemRepository.SaveChangesAsync();
            return id;
        }


    }
}
