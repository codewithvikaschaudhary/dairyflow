using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.PurchaseDto;
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
    public class PurchasesProvider : IPurchasesProvider
    {

        private readonly IRepository<Purchases> _productRepository;
        private readonly IRepository<Suppliers> _suppliersRepository;
        private readonly IRepository<Users> _usersRepository;

        public PurchasesProvider(IRepository<Purchases> productRepository, IRepository<Suppliers> suppliersRepository, IRepository<Users> usersRepository)
        {
            _productRepository = productRepository;
            _suppliersRepository = suppliersRepository;
            _usersRepository = usersRepository;
        }

        public PurchasesResponse GetPurchasesById(int id)
        {
            var query = (from purchase in _productRepository.GetAll()
                         join supplier in _suppliersRepository.GetAll() on purchase.SupplierId equals supplier.Id
                         join createdUser in _usersRepository.GetAll() on purchase.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on purchase.ModifiedBy equals modifiedUser.Id
                         where purchase.Id == id
                         select new PurchasesResponse
                         {
                             Id = purchase.Id,
                             SupplierId = purchase.SupplierId,
                             SupplierName = supplier.Name,
                             InvoiceNumber = purchase.InvoiceNumber,
                             PurchaseDate = purchase.PurchaseDate,
                             TotalAmount = purchase.TotalAmount,
                             Discount = purchase.Discount,
                             TaxAmount = purchase.TaxAmount,
                             FinalAmount = purchase.FinalAmount,
                             Status = purchase.Status,
                             Notes = purchase.Notes,
                             CreatedBy = purchase.CreatedBy,
                             CreatedByName = $"{createdUser.FirstName} {createdUser.LastName}",
                             CreatedDate = purchase.CreatedDate,
                             ModifiedBy = purchase.ModifiedBy,
                             ModifiedByName = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                             ModifiedDate = purchase.ModifiedDate
                         });

            var purchases = query.FirstOrDefault();

            if (purchases == null)
            {
                throw new Exception($"Purchases with ID {id} not found.");
            }
            return purchases;

        }


        public List<PurchasesResponse> GetAllPurchases(PurchasesFilters filters)
        {
            var query = (from purchase in _productRepository.GetAll()
                         join supplier in _suppliersRepository.GetAll() on purchase.SupplierId equals supplier.Id
                         join createdUser in _usersRepository.GetAll() on purchase.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on purchase.ModifiedBy equals modifiedUser.Id
                         select new PurchasesResponse
                         {
                             Id = purchase.Id,
                             SupplierId = purchase.SupplierId,
                             SupplierName = supplier.Name,
                             InvoiceNumber = purchase.InvoiceNumber,
                             PurchaseDate = purchase.PurchaseDate,
                             TotalAmount = purchase.TotalAmount,
                             Discount = purchase.Discount,
                             TaxAmount = purchase.TaxAmount,
                             FinalAmount = purchase.FinalAmount,
                             Status = purchase.Status,
                             Notes = purchase.Notes,
                             CreatedBy = purchase.CreatedBy,
                             CreatedByName = $"{createdUser.FirstName} {createdUser.LastName}",
                             CreatedDate = purchase.CreatedDate,
                             ModifiedBy = purchase.ModifiedBy,
                             ModifiedByName = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                             ModifiedDate = purchase.ModifiedDate
                         });
            if (filters.Id.HasValue)
            {
                query = query.Where(p => p.Id == filters.Id.Value);
            }
            if (filters.SupplierId.HasValue)
            {
                query = query.Where(p => p.SupplierId == filters.SupplierId.Value);
            }
            if (!string.IsNullOrEmpty(filters.InvoiceNumber))
            {
                query = query.Where(p => p.InvoiceNumber.Contains(filters.InvoiceNumber));
            }
            if (filters.Status.HasValue)
            {
                query = query.Where(p => p.Status == filters.Status.Value);
            }
            if (filters.CreatedBy.HasValue)
            {
                query = query.Where(p => p.CreatedBy == filters.CreatedBy.Value);
            }
            if (filters.PurchaseDateFrom.HasValue)
            {
                query = query.Where(p => p.PurchaseDate >= filters.PurchaseDateFrom.Value);
            }
            if (filters.PurchaseDateTo.HasValue)
            {
                query = query.Where(p => p.PurchaseDate <= filters.PurchaseDateTo.Value);
            }


            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }

        public async Task<Purchases> CreatePurchases(CreatePurchasesRequest request)
        {
            var purchases = new Purchases
            {
                SupplierId = request.SupplierId,
                InvoiceNumber = request.InvoiceNumber,
                TotalAmount = request.TotalAmount,
                Discount = request.Discount,
                TaxAmount = request.TaxAmount,
                FinalAmount = request.FinalAmount,
                Status = request.Status,
                Notes = request.Notes,
                CreatedBy = request.CreatedBy,
            };
            await _productRepository.AddAsync(purchases);
            await _productRepository.SaveChangesAsync();
            return purchases;
        }
        public async Task<Purchases> UpdatePurchases(int id, UpdatePurchasesRequest request)
        {
            var purchases = _productRepository.GetById(id);
            if (purchases == null)
            {
                throw new Exception($"Purchases with ID {id} not found.");
            }
            purchases.SupplierId = request.SupplierId;
            purchases.InvoiceNumber = request.InvoiceNumber;
            purchases.TotalAmount = request.TotalAmount;
            purchases.Discount = request.Discount;
            purchases.TaxAmount = request.TaxAmount;
            purchases.FinalAmount = request.FinalAmount;
            purchases.Status = request.Status;
            purchases.Notes = request.Notes;
            purchases.ModifiedBy = request.ModifiedBy;
            purchases.ModifiedDate = DateTime.Now;

            _productRepository.Update(purchases);
            await _productRepository.SaveChangesAsync();
            return purchases;
        }

        public async Task<int> DeletePurchases(int id)
        {
            var purchases = _productRepository.GetById(id);
            if (purchases == null)
            {
                throw new Exception($"Purchases with ID {id} not found.");
            }
            _productRepository.Delete(purchases);
            await _productRepository.SaveChangesAsync();
            return id;
        }



    }
}
