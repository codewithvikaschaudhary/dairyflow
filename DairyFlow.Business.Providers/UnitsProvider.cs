using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.UnitsDto;
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
    public class UnitsProvider : IUnitsProvider
    {

        private readonly IRepository<Units> _unitsRepository;
        private readonly IRepository<Users> _usersRepository;

        public UnitsProvider(IRepository<Units> unitsRepository, IRepository<Users> usersRepository)
        {
            _unitsRepository = unitsRepository;
            _usersRepository = usersRepository;
        }

        public UnitsResponse GetUnitsById(int id)
        {
            var query = (from unit in _unitsRepository.GetAll()
                         join createdUser in _usersRepository.GetAll() on unit.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on unit.ModifiedBy equals modifiedUser.Id
                         where unit.Id == id
                         select new UnitsResponse
                         {
                             Id = unit.Id,
                             Name = unit.Name,
                             ShortName = unit.ShortName,
                             CreatedBy = unit.CreatedBy,
                             CreatedByName = createdUser.FirstName,
                             ModifiedBy = unit.ModifiedBy,
                             ModifiedByName = modifiedUser.FirstName
                         });
            var result = query.FirstOrDefault();
            if (result == null)
            {
                throw new Exception($"Unit with ID {id} not found.");
            }
            return result;

        }

        public List<UnitsResponse> GetAllUnits(UnitsFilters filters)
        {
            var query = (from unit in _unitsRepository.GetAll()
                         join createdUser in _usersRepository.GetAll() on unit.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on unit.ModifiedBy equals modifiedUser.Id
                         select new UnitsResponse
                         {
                             Id = unit.Id,
                             Name = unit.Name,
                             ShortName = unit.ShortName,
                             CreatedBy = unit.CreatedBy,
                             CreatedByName = createdUser.FirstName,
                             ModifiedBy = unit.ModifiedBy,
                             ModifiedByName = modifiedUser.FirstName
                         });

            if (filters.Id.HasValue)
            {
                query = query.Where(u => u.Id == filters.Id.Value);
            }
            if (!string.IsNullOrEmpty(filters.Name))
            {
                query = query.Where(u => u.Name.Contains(filters.Name));
            }

            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);

        }

        public async Task<Units> CreateUnits(CreateUnitsRequest request)
        {
            var unit = new Units
            {
                Name = request.Name,
                ShortName = request.ShortName,
                CreatedBy = request.CreatedBy,
            };
            await _unitsRepository.AddAsync(unit);
            await _unitsRepository.SaveChangesAsync();
            return unit;
        }

        public async Task<Units> UpdateUnits(int id, UpdateUnitsRequest request)
        {
            var unit = _unitsRepository.GetById(id);
            if (unit == null)
            {
                throw new Exception($"Unit with ID {id} not found.");
            }
            unit.Name = request.Name;
            unit.ShortName = request.ShortName;
            unit.ModifiedBy = request.ModifiedBy;
            unit.ModifiedDate = DateTime.Now;
            _unitsRepository.Update(unit);
            await _unitsRepository.SaveChangesAsync();
            return unit;
        }

        public async Task<int> DeleteUnits(int id)
        {
            var unit = _unitsRepository.GetById(id);
            if (unit == null)
            {
                throw new Exception($"Unit with ID {id} not found.");
            }
            _unitsRepository.Delete(unit);
            await _unitsRepository.SaveChangesAsync();
            return id;
        }




    }
}
