using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.SuppliersDto;
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
    public class SuppliersProvider : ISuppliersProvider
    {
        private readonly IRepository<Suppliers> _suppliersRepository;
        private readonly IRepository<Users> _usersRepository;

        public SuppliersProvider(IRepository<Suppliers> suppliersRepository, IRepository<Users> usersRepository)
        {
            _suppliersRepository = suppliersRepository;
            _usersRepository = usersRepository;
        }

        public SuppliersResponse GetSuppliersById(int id)
        {
            var query = (from supplier in _suppliersRepository.GetAll()
                         join createdByUser in _usersRepository.GetAll() on supplier.CreatedBy equals createdByUser.Id
                         join modifiedByUser in _usersRepository.GetAll() on supplier.ModifiedBy equals modifiedByUser.Id
                         where supplier.Id == id
                         select new SuppliersResponse
                         {
                             Id = supplier.Id,
                             Name = supplier.Name,
                             Phone = supplier.Phone,
                             Email = supplier.Email,
                             Address = supplier.Address,
                             CreatedBy = supplier.CreatedBy,
                             CreatedByName = $"{createdByUser.FirstName} {createdByUser.LastName}",
                             ModifiedBy = supplier.ModifiedBy,
                             ModifiedByName = $"{modifiedByUser.FirstName} {modifiedByUser.LastName}",
                         });


            var data = query.FirstOrDefault();
            if (data == null)
            {
                throw new Exception($"Supplier with ID {id} not found.");
            }
            return data;

        }

        public List<SuppliersResponse> GetAllSuppliers(SuppliersFilters filters)
        {
            var query = (from supplier in _suppliersRepository.GetAll()
                         join createdByUser in _usersRepository.GetAll() on supplier.CreatedBy equals createdByUser.Id
                         join modifiedByUser in _usersRepository.GetAll() on supplier.ModifiedBy equals modifiedByUser.Id
                         select new SuppliersResponse
                         {
                             Id = supplier.Id,
                             Name = supplier.Name,
                             Phone = supplier.Phone,
                             Email = supplier.Email,
                             Address = supplier.Address,
                             CreatedBy = supplier.CreatedBy,
                             CreatedByName = $"{createdByUser.FirstName} {createdByUser.LastName}",
                             CreatedDate = supplier.CreatedDate,
                             ModifiedBy = supplier.ModifiedBy,
                             ModifiedByName = $"{modifiedByUser.FirstName} {modifiedByUser.LastName}",
                             ModifiedDate = supplier.ModifiedDate,
                         });
            if (filters.Id.HasValue)
            {
                query = query.Where(s => s.Id == filters.Id.Value);
            }
            if (!string.IsNullOrEmpty(filters.Name))
            {
                query = query.Where(s => s.Name.Contains(filters.Name));
            }
            if (!string.IsNullOrEmpty(filters.Phone))
            {
                query = query.Where(s => s.Phone.Contains(filters.Phone));
            }
            if (!string.IsNullOrEmpty(filters.Address))
            {
                query = query.Where(s => s.Address.Contains(filters.Address));
            }
            if (!string.IsNullOrEmpty(filters.CreatedByName))
            {
                query = query.Where(s => s.CreatedByName.Contains(filters.CreatedByName));
            }


            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }

        public async Task<Suppliers> CreateSuppliers(CreateSuppliersRequest request)
        {
            var supplier = new Suppliers
            {
                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email,
                Address = request.Address,
                CreatedBy = request.CreatedBy,
            };
            await _suppliersRepository.AddAsync(supplier);
            await _suppliersRepository.SaveChangesAsync();
            return supplier;
        }

        public async Task<Suppliers> UpdateSuppliers(int id, UpdateSuppliersRequest request)
        {
            var supplier = _suppliersRepository.GetById(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with ID {id} not found.");
            }
            supplier.Name = request.Name;
            supplier.Phone = request.Phone;
            supplier.Email = request.Email;
            supplier.Address = request.Address;
            supplier.ModifiedBy = request.ModifiedBy;
            supplier.ModifiedDate = DateTime.UtcNow;
            _suppliersRepository.Update(supplier);
            await _suppliersRepository.SaveChangesAsync();
            return supplier;
        }

        public async Task<int> DeleteSuppliers(int id)
        {
            var supplier = _suppliersRepository.GetById(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with ID {id} not found.");
            }
            _suppliersRepository.Delete(supplier);
            await _suppliersRepository.SaveChangesAsync();
            return id;
        }


    }
}
