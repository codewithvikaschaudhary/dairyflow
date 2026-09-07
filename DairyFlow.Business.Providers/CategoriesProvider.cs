using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.CategoriesDto;
using DairyFlow.Data.Dtos.InventoriesDto;
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
    public class CategoriesProvider : ICategoriesProvider
    {

        private readonly IRepository<Categories> _categoriesRepository;
        private readonly IRepository<Users> _usersRepository;

        public CategoriesProvider(IRepository<Categories> categoriesRepository, IRepository<Users> usersRepository)
        {
            _categoriesRepository = categoriesRepository;
            _usersRepository = usersRepository;
        }

        public CategoriesResponse GetCategoriesById(int id)
        {
            var query = (from category in _categoriesRepository.GetAll()
                         join createdUser in _usersRepository.GetAll() on category.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on category.ModifiedBy equals modifiedUser.Id
                         where category.Id == id
                         select new CategoriesResponse
                         {
                             Id = category.Id,
                             Name = category.Name,
                             CreatedBy = $"{createdUser.FirstName} {createdUser.LastName}",
                             ModifiedBy = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                         });
            var categories = query.FirstOrDefault();
            if (categories == null)
            {
                throw new Exception($"Categories with ID {id} not found.");
            }
            return categories;
        }

        public List<CategoriesResponse> GetAllCategories(CategoriesFilters filters)
        {
            var query = (from category in _categoriesRepository.GetAll()
                         join createdUser in _usersRepository.GetAll() on category.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on category.ModifiedBy equals modifiedUser.Id
                         select new CategoriesResponse
                         {
                             Id = category.Id,
                             Name = category.Name,
                             CreatedBy = $"{createdUser.FirstName} {createdUser.LastName}",
                             ModifiedBy = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                         });


            if (filters.Id.HasValue)
            {
                query = query.Where(i => i.Id == filters.Id.Value);
            }
            if (!string.IsNullOrEmpty(filters.Name))
            {
                query = query.Where(i => i.Name.Contains(filters.Name));
            }if (!string.IsNullOrEmpty(filters.CreatedBy))
            {
                query = query.Where(i => i.CreatedBy.Contains(filters.CreatedBy));
            }
            if (!string.IsNullOrEmpty(filters.ModifiedBy))
            {
                query = query.Where(i => i.ModifiedBy.Contains(filters.ModifiedBy));
            }


            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }

        public async Task<Categories> CreateCategories(CreateCategoriesRequest request)
        {

            var categories = new Categories
            {
                Name = request.Name,
                CreatedBy = request.CreatedBy,
                ModifiedBy = request.ModifiedBy,
            };

            await _categoriesRepository.AddAsync(categories);
            await _categoriesRepository.SaveChangesAsync();
            return categories;
        }

        public async Task<Categories> UpdateCategories(int id, UpdateCategoriesRequest request)
        {
            var categories = _categoriesRepository.GetById(id);
            if (categories == null)
            {
                throw new Exception($"Categories with ID {id} not found.");
            }
            categories.Name = request.Name;
            categories.CreatedBy = request.CreatedBy;
            categories.ModifiedBy = request.ModifiedBy;
            _categoriesRepository.Update(categories);
            await _categoriesRepository.SaveChangesAsync();
            return categories;
        }

        public async Task<int> DeleteCategories(int id)
        {
            var categories = _categoriesRepository.GetById(id);
            if (categories == null)
            {
                throw new Exception($"Categories with ID {id} not found.");
            }
            _categoriesRepository.Delete(categories);
            await _categoriesRepository.SaveChangesAsync();
            return id;
        }

    }
}
